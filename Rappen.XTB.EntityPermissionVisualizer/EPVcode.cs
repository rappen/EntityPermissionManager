using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using Rappen.XTB.Helpers.ControlItems;
using Rappen.XTB.Helpers.Controls;
using Rappen.XTB.Helpers.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Web;
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

        #endregion Private Fields

        #region Private Methods

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
                    { EntitypeRmission.Scope, ((int)EntitypeRmission.Scope_OptionSet.Overordnad).ToString() },
                    { EntitypeRmission.WebsiteId, cmbWebsite.SelectedEntity.Id.ToString() },
                    { EntitypeRmission.WebsiteId + "name", cmbWebsite.Text }
                };
            if (parent != null)
            {
                extraqs.Add(EntitypeRmission.ParentEntitypeRmission, parent.Id.ToString());
                extraqs.Add(EntitypeRmission.ParentEntitypeRmission + "name", txtItemName.Text);
            }
            var url = GetDeepLink(GetFullWebApplicationUrl(ConnectionDetail), EntitypeRmission.EntityName, Guid.Empty, Guid.Empty, extraqs);
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
            string url = GetEntityUrl(GetFullWebApplicationUrl(ConnectionDetail), entity);
            if (!string.IsNullOrEmpty(url))
            {
                Process.Start(url);
            }
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
