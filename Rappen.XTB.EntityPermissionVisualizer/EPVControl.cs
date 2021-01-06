using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Rappen.XTB.Helpers;
using Rappen.XTB.Helpers.ControlItems;
using Rappen.XTB.Helpers.Controls;
using Rappen.XTB.Helpers.Interfaces;
using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Windows.Forms;
using xrmtb.XrmToolBox.Controls.Controls;
using XrmToolBox.Extensibility;

namespace Rappen.XTB.EPV
{
    public partial class EPVControl : PluginControlBase
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
            #region Local methods
            bool ChildOf(Guid parentid, Entity permission)
            {
                return permission.TryGetAttributeValue("adx_parententitypermission", out EntityReference parent) ? parent.Id.Equals(parentid) : false;
            }
            TreeNode EntityToNode(Entity permission)
            {
                var item = new EntityItem(permission, Service);
                var name = permission.Substitute(Service, "{adx_entityname}");
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
            #endregion Local methods
            var rootnodes = permissions.Entities
                .Where(PermissionIsRoot)
                .OrderBy(PermissionOrder)
                .Select(EntityToNode);
            tvPermissions.Nodes.AddRange(rootnodes.ToArray());
            tvPermissions.ExpandAll();
        }

        private void tvPermissions_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var item = e.Node?.Tag as EntityItem;
            PermissionSelected(item);
        }

        private void PermissionSelected(EntityItem permissionitem)
        {
            panItem.Controls.OfType<CDSDataTextBox>().ToList().ForEach(c => c.Entity = permissionitem?.Entity);
            panItem.Controls.OfType<XRMDataTextBox>().ToList().ForEach(c => c.Entity = permissionitem?.Entity);
            btnItemOpen.Enabled = permissionitem != null;
            btnItemNewChild.Enabled = permissionitem != null;
        }

        private void btnItemOpen_Click(object sender, EventArgs e)
        {
            if (txtItemName.Entity != null)
            {
                string url = GetEntityUrl(GetFullWebApplicationUrl(ConnectionDetail), txtItemName.Entity);
                if (!string.IsNullOrEmpty(url))
                {
                    Process.Start(url);
                }
            }
        }

        private static string GetEntityUrl(string webappurl, Entity entity)
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
            return GetDeepLink(webappurl, entref.LogicalName, entref.Id, Guid.Empty, null);
        }

        private static string GetDeepLink(string webappurl, string entity, Guid recordid, Guid viewid, NameValueCollection extraqs)
        {
            if (string.IsNullOrEmpty(entity))
            {
                return string.Empty;
            }
            var uri = new UriBuilder(webappurl);
            uri.Path = "main.aspx";
            var query = HttpUtility.ParseQueryString(uri.Query);
            if (!string.IsNullOrWhiteSpace(entity))
            {
                query["etn"] = entity;
            }
            if (!viewid.Equals(Guid.Empty))
            {
                query["pagetype"] = "entitylist";
                query["id"] = viewid.ToString();
            }
            else
            {
                query["pagetype"] = "entityrecord";
                if (!recordid.Equals(Guid.Empty))
                {
                    query["id"] = recordid.ToString();
                }
            }
            if (extraqs != null)
            {
                var eq = extraqs.AllKeys.Select(k => k + "=" + Safe(extraqs[k]));
                var extraquerystring = string.Join("&", eq);
                query["extraqs"] = extraquerystring;
            }
            uri.Query = query.ToString();
            return uri.ToString();
        }

        private static string Safe(string unsafestring)
        {
            return unsafestring
                .Replace('å', 'a')
                .Replace('ä', 'a')
                .Replace('ö', 'o')
                .Replace('ü', 'u')
                .Replace('Å', 'A')
                .Replace('Ä', 'A')
                .Replace('Ö', 'O')
                .Replace('Ü', 'U');
        }

        public static string GetFullWebApplicationUrl(ConnectionDetail connectionDetail)
        {
            var url = connectionDetail.WebApplicationUrl;
            if (string.IsNullOrEmpty(url))
            {
                url = connectionDetail.ServerName;
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
                    uri = new Uri(uri, connectionDetail.Organization);
                }
            }
            return uri.ToString();
        }

        private void btnItemNewChild_Click(object sender, EventArgs e)
        {
            if (!(txtItemName.Entity is Entity permission))
            {
                return;
            }
            var url = GetDeepLink(GetFullWebApplicationUrl(ConnectionDetail), "adx_entitypermission", Guid.Empty, Guid.Empty,
                new NameValueCollection {
                    { "adx_scope", "756150003" },
                    { "adx_parententitypermission", permission.Id.ToString() },
                    { "adx_parententitypermissionname", txtItemName.Text }
                });
            if (!string.IsNullOrEmpty(url))
            {
                Process.Start(url);
            }
        }
    }
}