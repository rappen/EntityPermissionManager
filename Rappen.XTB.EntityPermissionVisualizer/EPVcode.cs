using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using Rappen.XTB.Helpers;
using Rappen.XTB.Helpers.ControlItems;
using Rappen.XTB.Helpers.Controls;
using Rappen.XTB.Helpers.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using xrmtb.XrmToolBox.Controls.Controls;
using XrmToolBox.Extensibility;

namespace Rappen.XTB.EPV
{
    public partial class EPVControl
    {
        #region Private Fields

        private Dictionary<string, EntityMetadataItem> entities;
        private Settings mySettings;
        private IEnumerable<Entity> permissions;
        private string webappurl;

        #endregion Private Fields

        #region Private Methods

        private static string GetFullWebApplicationUrl(ConnectionDetail connectionDetail)
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

        private void ConnectionUpdated(IOrganizationService newService)
        {
            permissions = null;
            entities = null;
            webappurl = GetFullWebApplicationUrl(ConnectionDetail);
            cmbWebsite.Service = newService;
            xrmPermission.Service = newService;
            grdWebroles.Service = newService;
            LoadWebsites();
        }

        private void DeletePermission(TreeNode node)
        {
            if (!(node.Tag is EntityItem permission))
            {
                return;
            }
            if (MessageBox.Show($"Confirm deletion of permission {permission}.\nThis can NOT be undone!", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
            {
                return;
            }
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Deleting",
                Work = (w, a) =>
                {
                    Service.Delete(permission.Entity.LogicalName, permission.Entity.Id);
                },
                PostWorkCallBack = (a) => HandleWorkAsync<object>(a, (obj) =>
                {
                    node.Remove();
                    permissions = permissions.Where(p => p != permission.Entity);
                })
            });
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

        private List<TreeNode> GetChildPermissions(TreeNode parentnode)
        {
            var childnodes = new List<TreeNode>();
            if (permissions != null)
            {
                IEnumerable<Entity> childpermissions = null;
                if (parentnode == null)
                {   // All but parental permissions
                    childpermissions = permissions.Where(p => p.TryGetAttributeValue(Entitypermission.Scope, out OptionSetValue scope) ? scope.Value != (int)Entitypermission.Scope_OptionSet.Parent : true);
                }
                else if (parentnode.Tag is EntityItem parentitem)
                {
                    childpermissions = permissions.Where(p => p.TryGetAttributeValue(Entitypermission.ParentEntitypermission, out EntityReference parent) ? parent.Id.Equals(parentitem.Entity.Id) : false);
                }
                if (childpermissions.Count() > 0)
                {
                    var childitems = childpermissions
                        .Select(e => new PermissionItem(e, rbTreeRels.Checked, Service))
                        .OrderBy(p => p.OrderBy);
                    childnodes = childitems
                        .Select(p => p.ToNode()).ToList();
                    childnodes.ForEach(c => c.Nodes.AddRange(GetChildPermissions(c).ToArray()));
                }
            }
            return childnodes;
        }

        private EntityMetadataItem GetEntityMetadataItem(string entityname)
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

        private string GetPermissionEntityName(EntityItem permissionitem)
        {
            if (permissionitem == null)
            {
                return string.Empty;
            }
            if (permissionitem.Entity.TryGetAttributeValue(Entitypermission.EntityLogicalName, out string itementity))
            {
                if (GetEntityMetadataItem(itementity) is EntityMetadataItem emdi)
                {
                    return emdi.DisplayName;
                }
                return itementity;
            }
            return string.Empty;
        }

        private void HandleWorkAsync<T>(RunWorkerCompletedEventArgs args, Action<T> nextMethod)
        {
            if (args.Error != null)
            {
                MessageBox.Show(args.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (args.Result is T || (args.Result == null && typeof(T) is object))
            {
                nextMethod.Invoke((T)args.Result);
            }
            else
            {
                MessageBox.Show($"Expected result of {typeof(T)}\nGot result of {args.Result.GetType()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPermissions()
        {
            btnNew.Enabled = cmbWebsite.SelectedRecord != null;
            btnRefresh.Enabled = cmbWebsite.SelectedRecord != null;
            tvPermissions.Nodes.Clear();
            if (cmbWebsite.SelectedRecord == null)
            {
                return;
            }
            var query = new QueryExpression("adx_entitypermission");
            query.ColumnSet.AddColumns("adx_entityname", "adx_entitylogicalname", "adx_scope", "adx_parententitypermission", "adx_contactrelationship", "adx_accountrelationship", "adx_parentrelationship", "adx_read", "adx_create", "adx_write", "adx_delete", "adx_append", "adx_appendto", "adx_websiteid");
            query.Criteria.AddCondition("adx_websiteid", ConditionOperator.Equal, cmbWebsite.SelectedRecord.Id);

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

        private void LoadWebroles()
        {
            var permission = xrmPermission.Record;
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

        private void OpenNewPermission(Entity parent)
        {
            var extraqs = new NameValueCollection {
                    { Entitypermission.WebsiteId, cmbWebsite.SelectedRecord.Id.ToString() },
                    { Entitypermission.WebsiteId + "name", cmbWebsite.Text }
                };
            if (parent != null)
            {
                extraqs.Add(Entitypermission.Scope, ((int)Entitypermission.Scope_OptionSet.Parent).ToString());
                extraqs.Add(Entitypermission.ParentEntitypermission, parent.Id.ToString());
                extraqs.Add(Entitypermission.ParentEntitypermission + "name", txtItemName.Text);
            }
            var url = Utils.GetRecordDeepLink(webappurl, Entitypermission.EntityName, Guid.Empty, extraqs);
            if (!string.IsNullOrEmpty(url))
            {
                Process.Start(url);
            }
        }

        private void OpenPermission(Entity entity)
        {
            if (entity == null)
            {
                return;
            }
            string url = Utils.GetRecordDeepLink(webappurl, entity, null);
            if (!string.IsNullOrEmpty(url))
            {
                Process.Start(url);
            }
        }

        private void PermissionSelected(TreeNode node)
        {
            var permissionitem = node.Tag as EntityItem;
            xrmPermission.SuspendLayout();
            xrmPermission.Record = permissionitem?.Entity;
            if (permissionitem != null)
            {
                cmbItemParent.Filter = new FilterExpression()
                {
                    Conditions = {
                        new ConditionExpression(Entitypermission.PrimaryKey, ConditionOperator.NotEqual, permissionitem.Entity.Id) }
                };
            }
            xrmPermission.ResumeLayout();
            btnOpen.Enabled = permissionitem != null;
            btnNewChild.Enabled = permissionitem != null;
            btnDelete.Enabled = permissionitem != null && node.Nodes.Count == 0;
            txtItemEntityName.Text = GetPermissionEntityName(permissionitem);
            LoadWebroles();
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

        #endregion Private Methods
    }
}