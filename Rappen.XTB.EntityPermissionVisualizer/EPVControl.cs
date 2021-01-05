using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Rappen.XTB.Helpers;
using Rappen.XTB.Helpers.ControlItems;
using Rappen.XTB.Helpers.Interfaces;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using xrmtb.XrmToolBox.Controls.Controls;
using XrmToolBox.Extensibility;

namespace Rappen.XTB.EPV
{
    public partial class EPVControl : PluginControlBase, ILogger
    {
        private Settings mySettings;

        public EPVControl()
        {
            InitializeComponent();
        }

        private void MyPluginControl_Load(object sender, EventArgs e)
        {
            if (!SettingsManager.Instance.TryLoad(GetType(), out mySettings))
            {
                mySettings = new Settings();
            }
        }

        public override void ClosingPlugin(PluginCloseInfo info)
        {
            base.ClosingPlugin(info);
            if (!info.Cancel)
            {
                SettingsManager.Instance.Save(GetType(), mySettings);
            }
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }

        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);
            cmbWebsite.OrganizationService = newService;
            txtItemName.OrganizationService = newService;
            txtItemEntity.OrganizationService = newService;
            txtItemScope.OrganizationService = newService;
            txtItemParent.OrganizationService = newService;
            txtItemRelationship.OrganizationService = newService;
            txtItemPrivileges.OrganizationService = newService;
            LoadWebsites();
        }

        private void HandleWorkAsync<T>(RunWorkerCompletedEventArgs args, Action<T> nextMethod)
        {
            if (args.Error != null)
            {
                MessageBox.Show(args.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (args.Result is T)
            {
                nextMethod.Invoke((T)args.Result);
            }
            else if (args.Result == null)
            {
                MessageBox.Show("No result from caller", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"Expected result of {typeof(T)}\nGot result of {args.Result.GetType()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadWebsites()
        {
            var query = new QueryExpression("adx_website");
            query.Distinct = true;
            query.ColumnSet.AddColumns("adx_websiteid", "adx_name", "adx_primarydomainname");
            query.AddLink("adx_entitypermission", "adx_websiteid", "adx_websiteid");
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading websites",
                Work = (worker, args) =>
                {
                    args.Result = Service.RetrieveMultiple(query);
                },
                PostWorkCallBack = (args) => HandleWorkAsync<EntityCollection>(args, (websites) =>
                {
                    cmbWebsite.DataSource = websites;
                })
            });
        }

        private void cmbWebsite_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPermissions();
        }

        private void LoadPermissions()
        {
            tvPermissions.Nodes.Clear();
            if (cmbWebsite.SelectedEntity == null)
            {
                return;
            }
            var query = new QueryExpression("adx_entitypermission");
            query.ColumnSet.AddColumns("adx_entityname", "adx_entitylogicalname", "adx_scope", "adx_parententitypermission", "adx_contactrelationship", "adx_accountrelationship", "adx_parentrelationship", "adx_read", "adx_create", "adx_write", "adx_delete", "adx_append", "adx_appendto", "adx_websiteid");
            query.Criteria.AddCondition("adx_websiteid", ConditionOperator.Equal, cmbWebsite.SelectedEntity.Id);
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading Entity Permissions",
                Work = (worker, args) =>
                {
                    args.Result = Service.RetrieveMultiple(query);
                },
                PostWorkCallBack = (args) => HandleWorkAsync<EntityCollection>(args, PopulatePermissions)
            });
        }

        private void PopulatePermissions(EntityCollection permissions)
        {
            var bag = new GenericBag(Service, this);
            bool ChildOf(Guid parentid, Entity permission)
            {
                return permission.TryGetAttributeValue("adx_parententitypermission", out EntityReference parent) ? parent.Id.Equals(parentid) : false;
            }
            TreeNode EntityToNode(Entity permission)
            {
                var item = new EntityItem(permission, string.Empty, Service);
                var name = permission.Substitute(bag, "{adx_scope} - {adx_entityname}");
                var image = permission.TryGetAttributeValue("adx_scope", out OptionSetValue scope) ? scope.Value - 756150000 : -1;
                var children = permissions.Entities.Where(p => ChildOf(permission.Id, p)).OrderBy(PermissionOrder).Select(EntityToNode).ToArray();
                var node = new TreeNode(name, image, image, children) { Tag = item };
                return node;
            }
            bool PermissionIsRoot(Entity permission)
            {
                return !permission.TryGetAttributeValue("adx_scope", out OptionSetValue scope) ? true : scope.Value != 756150003;
            }
            string PermissionOrder(Entity permission)
            {
                var result = string.Empty;
                if (permission.TryGetAttributeValue("adx_scope", out OptionSetValue scope))
                {
                    result = scope.Value.ToString("0000000000000");
                }
                if (permission.TryGetAttributeValue("adx_entityname", out string name))
                {
                    result += name;
                }
                else
                {
                    result += permission.Id.ToString();
                }
                return result;
            }
            var rootnodes = permissions.Entities
                .Where(PermissionIsRoot)
                .OrderBy(PermissionOrder)
                .Select(EntityToNode);
            tvPermissions.Nodes.AddRange(rootnodes.ToArray());
        }

        private void tvPermissions_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var item = e.Node?.Tag as EntityItem;
            panItem.Controls.OfType<CDSDataTextBox>().ToList().ForEach(c => c.Entity = item?.Entity);
            btnItemOpen.Enabled = item != null;
        }

        public void EndSection() { }

        public void Log(string message) { }

        public void Log(Exception ex) { }

        public void StartSection(string name = null) { }

        private void btnItemOpen_Click(object sender, EventArgs e)
        {
            if (txtItemName.Entity != null)
            {
                string url = GetEntityUrl(txtItemName.Entity);
                if (!string.IsNullOrEmpty(url))
                {
                    Process.Start(url);
                }
            }
        }

        private string GetEntityUrl(Entity entity)
        {
            var entref = entity.ToEntityReference();
            switch (entref.LogicalName)
            {
                case "activitypointer":
                    if (!entity.Contains("activitytypecode"))
                    {
                        MessageBox.Show("To open records of type activitypointer, attribute 'activitytypecode' must be included in the query.", "Open Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        entref.LogicalName = string.Empty;
                    }
                    else
                    {
                        entref.LogicalName = entity["activitytypecode"].ToString();
                    }
                    break;
                case "activityparty":
                    if (!entity.Contains("partyid"))
                    {
                        MessageBox.Show("To open records of type activityparty, attribute 'partyid' must be included in the query.", "Open Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        entref.LogicalName = string.Empty;
                    }
                    else
                    {
                        var party = (EntityReference)entity["partyid"];
                        entref.LogicalName = party.LogicalName;
                        entref.Id = party.Id;
                    }
                    break;
            }
            return GetEntityReferenceUrl(entref);
        }

        private string GetEntityReferenceUrl(EntityReference entref)
        {
            if (!string.IsNullOrEmpty(entref.LogicalName) && !entref.Id.Equals(Guid.Empty))
            {
                var url = GetFullWebApplicationUrl();
                url = string.Concat(url,
                    url.EndsWith("/") ? "" : "/",
                    "main.aspx?etn=",
                    entref.LogicalName,
                    "&pagetype=entityrecord&id=",
                    entref.Id.ToString());
                return url;
            }
            return string.Empty;
        }

        public string GetFullWebApplicationUrl()
        {
            var url = ConnectionDetail.WebApplicationUrl;
            if (string.IsNullOrEmpty(url))
            {
                url = ConnectionDetail.ServerName;
            }
            if (!url.ToLower().StartsWith("http"))
            {
                url = string.Concat("http://", url);
            }
            var uri = new Uri(url);
            if (!uri.Host.EndsWith(".dynamics.com"))
            {
                if (string.IsNullOrEmpty(uri.AbsolutePath.Trim('/')))
                {
                    uri = new Uri(uri, ConnectionDetail.Organization);
                }
            }
            return uri.ToString();
        }
    }
}