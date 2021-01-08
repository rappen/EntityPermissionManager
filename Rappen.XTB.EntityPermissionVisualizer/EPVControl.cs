using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using Rappen.XTB.Helpers.ControlItems;
using Rappen.XTB.Helpers.Controls;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Windows.Forms;
using xrmtb.XrmToolBox.Controls;
using xrmtb.XrmToolBox.Controls.Controls;
using XrmToolBox.Extensibility;

namespace Rappen.XTB.EPV
{
    public partial class EPVControl : PluginControlBase
    {
        private Settings mySettings;
        private IEnumerable<Entity> permissions;
        private Dictionary<string, EntityMetadataItem> entities;

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
            permissions = null;
            entities = null;
            cmbWebsite.OrganizationService = newService;
            txtItemName.OrganizationService = newService;
            txtItemEntity.OrganizationService = newService;
            txtItemScope.OrganizationService = newService;
            txtItemParent.OrganizationService = newService;
            txtItemRelationship.OrganizationService = newService;
            txtItemPrivileges.OrganizationService = newService;
            grdWebroles.OrganizationService = newService;
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
                // MessageBox.Show("No result from caller", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            var webroleid = Guid.Empty; // Prep for filtering/grouping by webrole
            if (!webroleid.Equals(Guid.Empty))
            {
                var wr = query.AddLink("adx_entitypermission_webrole", "adx_entitypermissionid", "adx_entitypermissionid");
                wr.LinkCriteria.AddCondition("adx_webroleid", ConditionOperator.Equal, webroleid);
            }

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

        private void PopulatePermissions(EntityCollection newpermissions)
        {
            permissions = newpermissions.Entities;
            PopulatePermissions();
        }

        private void PopulatePermissions()
        {
            tvPermissions.Nodes.Clear();
            tvPermissions.Nodes.AddRange(GetChildPermissions(null).ToArray());
            GetChildNodeDetails(tvPermissions.Nodes);
            //tvPermissions.ExpandAll();
        }

        private List<TreeNode> GetChildPermissions(TreeNode parentnode)
        {
            IEnumerable<Entity> childpermissions = null;
            if (parentnode == null)
            {   // All but parental permissions
                childpermissions = permissions.Where(p => p.TryGetAttributeValue("adx_scope", out OptionSetValue scope) ? scope.Value != 756150003 : true);
            }
            else if (parentnode.Tag is EntityItem parentitem)
            {
                childpermissions = permissions.Where(p => p.TryGetAttributeValue("adx_parententitypermission", out EntityReference parent) ? parent.Id.Equals(parentitem.Entity.Id) : false);
            }
            else
            {
                return new List<TreeNode>();
            }
            var childitems = childpermissions
                .Select(e => new PermissionItem(e, rbTreeRels.Checked, Service))
                .OrderBy(p => p.OrderBy);
            var childnodes = childitems
                .Select(p => p.ToNode()).ToList();
            childnodes.ForEach(c => c.Nodes.AddRange(GetChildPermissions(c).ToArray()));
            return childnodes;
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
            txtItemEntityName.Text = GetPermissionEntityName(permissionitem);
            LoadWebroles();
        }

        private string GetPermissionEntityName(EntityItem permissionitem)
        {
            if (permissionitem == null)
            {
                return string.Empty;
            }
            if (permissionitem.Entity.TryGetAttributeValue("adx_entitylogicalname", out string itementity))
            {
                if (GetEntityMetadataItem(itementity) is EntityMetadataItem emdi)
                {
                    return emdi.DisplayName;
                }
                return itementity;
            }
            return string.Empty;
        }

        private void LoadWebroles()
        {
            var permission = txtItemName.Entity;
            var query = new QueryExpression("adx_webrole");
            query.ColumnSet.AddColumns("adx_name", "adx_description");
            query.AddOrder("adx_name", OrderType.Ascending);
            var mm = query.AddLink("adx_entitypermission_webrole", "adx_webroleid", "adx_webroleid");
            mm.LinkCriteria.AddCondition("adx_entitypermissionid", ConditionOperator.Equal, permission.Id);
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading webroles",
                Work = (worker, args) =>
                {
                    args.Result = Service.RetrieveMultiple(query);
                },
                PostWorkCallBack = (args) => HandleWorkAsync<EntityCollection>(args, (webroles) =>
                {
                    grdWebroles.DataSource = webroles;
                })
            });
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
                var eq = extraqs.AllKeys.Select(k => k + "=" + HttpUtility.UrlEncode(extraqs[k]));
                var extraquerystring = string.Join("&", eq);
                query["extraqs"] = extraquerystring;
            }
            uri.Query = query.ToString();
            return uri.ToString();
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
                    { EntitypeRmission.Scope, ((int)EntitypeRmission.Scope_OptionSet.Overordnad).ToString() },
                    { EntitypeRmission.WebsiteId, cmbWebsite.SelectedEntity.Id.ToString() },
                    { EntitypeRmission.WebsiteId + "name", cmbWebsite.Text },
                    { EntitypeRmission.ParentEntitypeRmission, permission.Id.ToString() },
                    { EntitypeRmission.ParentEntitypeRmission + "name", txtItemName.Text }
                });
            if (!string.IsNullOrEmpty(url))
            {
                Process.Start(url);
            }
        }

        internal EntityMetadataItem GetEntityMetadataItem(string entityname)
        {
            if (entities == null)
            {
                entities = new Dictionary<string, EntityMetadataItem>();
            }
            if (entities.TryGetValue(entityname, out EntityMetadataItem meta))
            {
                return meta;
            }
            if (Service.GetEntity(entityname) is EntityMetadata entitymeta)
            {
                meta = new EntityMetadataItem(entitymeta, true);
                entities.Add(entityname, meta);
                return meta;
            }
            return null;
        }

        private void rbTreeNames_CheckedChanged(object sender, EventArgs e)
        {
            PopulatePermissions();
        }

        private void tvPermissions_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            GetChildNodeDetails(e.Node.Nodes);
        }

        private void GetChildNodeDetails(TreeNodeCollection nodes)
        {
            if (nodes.OfType<TreeNode>().Any(n => n.Tag is PermissionItem item && !item.DetailsLoaded))
            {
                WorkAsync(new WorkAsyncInfo
                {
                    Message = "Loading details",
                    Work = (w, args) =>
                    {
                        var items = nodes.OfType<TreeNode>()
                            .Where(n => n.Tag is PermissionItem item && !item.DetailsLoaded)
                            .Select(n => n.Tag as PermissionItem);
                        var total = items.Count();
                        var current = 0;
                        foreach (var item in items)
                        {
                            current++;
                            w.ReportProgress(current * 100 / total, $"Loading details\n{current} / {total}");
                            item.LoadDetails();
                        }
                        args.Result = nodes.OfType<TreeNode>();
                    },
                    ProgressChanged = (args) =>
                    {
                        SetWorkingMessage(args.UserState.ToString());
                    },
                    PostWorkCallBack = (args) => HandleWorkAsync<IEnumerable<TreeNode>>(args, (childnodes) =>
                    {
                        childnodes.ToList().ForEach(c => c.Text = (c.Tag is PermissionItem item) ? item.TreeNodeText : "?");
                    })
                });
            }
        }
    }
}