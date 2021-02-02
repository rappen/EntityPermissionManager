using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using Rappen.XTB.Helpers;
using Rappen.XTB.Helpers.ControlItems;
using Rappen.XTB.Helpers.Controls;
using Rappen.XTB.Helpers.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using XrmToolBox.Extensibility;
using Scope = Rappen.XTB.EPV.Entitypermission.Scope_OptionSet;

namespace Rappen.XTB.EPV
{
    public partial class EPVControl
    {
        #region Private Fields

        private IEnumerable<EntityMetadata> allentities;
        private Dictionary<string, EntityMetadataItem> entitydetails;
        private bool offmainthread;
        private IEnumerable<Entity> permissions;
        private string webappurl;

        #endregion Private Fields

        #region Private Methods

        private void AddWebRole()
        {
            var lkp = new XRMLookupDialog
            {
                Service = Service,
                LogicalName = Webrole.EntityName,
                Multiselect = true,
                ShowRemoveButton = false,
                Title = "Select webrole(s)"
            };
            if (lkp.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }
            WorkAsync(new WorkAsyncInfo
            {
                Message = $"Adding {lkp.Records.Count()} webrole(s)",
                Work = (w, a) =>
                {
                    Service.Associate(Entitypermission.EntityName, xrmPermission.Id, new Relationship(Entitypermission.RelMM_EntitypermissionWebrole), new EntityReferenceCollection(lkp.Records.Select(wr => wr.ToEntityReference()).ToList()));
                },
                PostWorkCallBack = (a) => HandleWorkAsync<object>(a, (obj) =>
                {
                    LoadWebroles();
                })
            });
        }

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
            entitydetails = null;
            xrmPermission.Record = null;
            webappurl = GetFullWebApplicationUrl(ConnectionDetail);
            cmbWebsite.Service = newService;
            xrmPermission.Service = newService;
            grdWebroles.Service = newService;
            LoadEntities();
        }

        private void CreateNewPermission(Entity parent)
        {
            btnItemSave.Text = "Create";
            btnItemUndo.Text = "Cancel";
            xrmPermission.SuspendLayout();
            xrmPermission.Record = new Entity(Entitypermission.EntityName);
            xrmPermission.SetValue(Entitypermission.WebsiteId, cmbWebsite.SelectedRecord.ToEntityReference());
            if (parent != null)
            {
                xrmPermission.SetValue(Entitypermission.ParentEntitypermission, parent.ToEntityReference());
                xrmPermission.SetValue(Entitypermission.Scope, new OptionSetValue((int)Scope.Parent));
                cmbItemParent.Filter = new FilterExpression { Conditions = { new ConditionExpression(Entitypermission.PrimaryKey, ConditionOperator.Equal, parent.Id) } };
            }
            else
            {
                xrmPermission.SetValue(Entitypermission.Scope, new OptionSetValue((int)Scope.Global));
                cmbItemParent.Filter = null;
            }
            xrmPermission.ResumeLayout();
            grdWebroles.DataSource = null;
            panItem.Enabled = true;
            btnOpen.Enabled = false;
            btnNewChild.Enabled = false;
            btnDelete.Enabled = false;
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

        private void DeleteWebRoles()
        {
            var webroles = grdWebroles.SelectedCellRecords;
            if (webroles.Count() == 0)
            {
                return;
            }
            var msg = grdWebroles.SelectedCellRecords.Count() > 1
                ? $"Delete {webroles.Count()} webroles?"
                : $"Delete webrole {grdWebroles.SelectedCellRecords.First().GetAttributeValue<string>(Webrole.PrimaryName)}?";
            if (MessageBox.Show(msg, "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                return;
            }
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Deleting webrole",
                Work = (w, a) =>
                {
                    Service.Disassociate(Entitypermission.EntityName, xrmPermission.Id, new Relationship(Entitypermission.RelMM_EntitypermissionWebrole), new EntityReferenceCollection(webroles.Select(wr => wr.ToEntityReference()).ToList()));
                },
                PostWorkCallBack = (a) => HandleWorkAsync<object>(a, (obj) =>
                {
                    LoadWebroles();
                })
            });
        }

        private TreeNode FindNodeByRecordId(IEnumerable<TreeNode> nodes, Guid id)
        {
            if (nodes.FirstOrDefault(n => n.Tag is PermissionItem item && item.Entity.Id.Equals(id)) is TreeNode node)
            {
                return node;
            }
            foreach (var childnode in nodes)
            {
                if (childnode.Nodes?.Count > 0 && FindNodeByRecordId(childnode.Nodes.OfType<TreeNode>(), id) is TreeNode foundnode)
                {
                    return foundnode;
                }
            }
            return null;
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
                    childpermissions = permissions.Where(p => p.TryGetAttributeValue(Entitypermission.Scope, out OptionSetValue scope) ? scope.Value != (int)Scope.Parent : true);
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
            if (entitydetails == null)
            {
                entitydetails = new Dictionary<string, EntityMetadataItem>();
            }
            if (entitydetails.TryGetValue(entityname, out EntityMetadataItem meta))
            {
                return meta;
            }
            if (Service.GetEntity(entityname) is EntityMetadata entitymeta)
            {
                meta = new EntityMetadataItem(entitymeta, true);
                entitydetails.Add(entityname, meta);
                return meta;
            }
            return null;
        }

        private EntityMetadataItem GetFromEntity()
        {
            var fromentityname = string.Empty;
            switch (GetScope())
            {
                case Scope.Contact:
                    fromentityname = "contact";
                    break;

                case Scope.Account:
                    fromentityname = "account";
                    break;

                case Scope.Parent:
                    fromentityname = GetParentPermissionEntityName();
                    break;
            }
            if (string.IsNullOrEmpty(fromentityname) || !(Service.GetEntity(fromentityname) is EntityMetadata meta))
            {
                return null;
            }
            return new EntityMetadataItem(meta, true);
        }

        private string GetParentPermissionEntityName()
        {
            if (xrmPermission[Entitypermission.ParentEntitypermission] is EntityReference parentref &&
                permissions.FirstOrDefault(p => p.Id.Equals(parentref.Id)) is Entity parentperm &&
                parentperm.TryGetAttributeValue(Entitypermission.EntityLogicalName, out string parentname))
            {
                return parentname;
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

        private string GetRelationshipColumn()
        {
            switch (GetScope())
            {
                case Scope.Contact:
                    return Entitypermission.ContactRelationship;

                case Scope.Account:
                    return Entitypermission.AccountRelationship;

                case Scope.Parent:
                    return Entitypermission.ParentRelationship;
            }
            return null;
        }

        private Scope GetScope()
        {
            if (xrmPermission[Entitypermission.Scope] is OptionSetValue scope)
            {
                return (Scope)scope.Value;
            }
            return Scope.Self;
        }

        private EntityMetadataItem GetToEntity()
        {
            var toentityname = xrmPermission[Entitypermission.EntityLogicalName] as string;
            if (string.IsNullOrEmpty(toentityname) || !(Service.GetEntity(toentityname) is EntityMetadata meta))
            {
                return null;
            }
            return new EntityMetadataItem(meta, true);
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

        private void LoadEntities()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading tables",
                Work = (worker, args) =>
                {
                    args.Result = Service.LoadEntities();
                },
                PostWorkCallBack = (args) => HandleWorkAsync<RetrieveMetadataChangesResponse>(args, (entities) =>
                {
                    allentities = entities.EntityMetadata;
                    LoadWebsites();
                })
            });
            allentities = Service.LoadEntities().EntityMetadata;
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
                PostWorkCallBack = (args) => HandleWorkAsync<EntityCollection>(args, PopulatePermissionsTree)
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
                    lblNoRoles.Visible = webroles.Entities.Count == 0;
                    var rowheights = grdWebroles.Rows.OfType<DataGridViewRow>().Sum(r => r.Height);
                    panWebroles.Height = Math.Max(40, grdWebroles.Top + rowheights + 10);
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
                    if (cmbWebsite.Items.Count > 0 && cmbWebsite.SelectedIndex == -1)
                    {
                        cmbWebsite.SelectedIndex = 0;
                    }
                })
            });
        }

        private void LogPendingChanges()
        {
            btnItemSave.Enabled = xrmPermission.ChangedColumns?.Count() > 0;
            btnItemUndo.Enabled = btnItemSave.Enabled;
            listLog.Items.Clear();
            if (xrmPermission?.ChangedColumns != null)
            {
                foreach (var key in xrmPermission.ChangedColumns)
                {
                    var value = xrmPermission[key];
                    var basevalue = EntityExtensions.AttributeToBaseType(value);
                    xrmPermission.Record.TryGetAttributeValue(key, out object oldvalue);
                    var baseold = EntityExtensions.AttributeToBaseType(oldvalue);
                    var log = listLog.Items.Add(key);
                    log.SubItems.Add(basevalue != null ? basevalue.ToString() : "null");
                    log.SubItems.Add(value != null ? value.GetType().ToString() : oldvalue != null ? oldvalue.GetType().ToString() : "null");
                    log.SubItems.Add(baseold != null ? baseold.ToString() : "null");
                }
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

        private void PermissionEntityUpdated()
        {
            xrmPermission.SetValue(Entitypermission.EntityLogicalName, cmbItemEntity.SelectedEntity?.LogicalName);
            PopulatePermissionRelationships();
        }

        private void PermissionRelationshipUpdated()
        {
            var relattr = GetRelationshipColumn();
            if (!string.IsNullOrEmpty(relattr) &&
                cmbItemRelationship.SelectedItem is RelationshipItem rel)
            {
                xrmPermission.SetValue(relattr, rel.Metadata.SchemaName);
            }
        }

        private void PermissionScopeUpdated()
        {
            cmbItemParent.Visible = GetScope() == Scope.Parent;
            lblNoParent.Visible = !cmbItemParent.Visible;
            if (!cmbItemParent.Visible)
            {
                cmbItemParent.SelectedItem = null;
            }
            txtItemRelationship.Column = GetRelationshipColumn() ?? "not a valid column";
            PopulatePermissionEntities();
        }

        private void PermissionSelected(TreeNode node)
        {
            panItem.Enabled = false;
            var permissionitem = node.Tag as EntityItem;
            xrmPermission.SuspendLayout();
            xrmPermission.Record = permissionitem?.Entity;
            if (xrmPermission.Record != null)
            {
                btnItemSave.Text = "Save";
                btnItemUndo.Text = "Undo";
                cmbItemParent.Filter = new FilterExpression()
                {
                    Conditions = { new ConditionExpression(Entitypermission.PrimaryKey, ConditionOperator.NotEqual, xrmPermission.Record.Id) }
                };
            }
            txtItemRelationship.Column = GetRelationshipColumn() ?? "not a valid column";
            PermissionScopeUpdated();
            xrmPermission.ResumeLayout();
            LoadWebroles();
            panItem.Enabled = xrmPermission.Record != null;
            btnOpen.Enabled = !Guid.Empty.Equals(xrmPermission.Record?.Id);
            btnNewChild.Enabled = !Guid.Empty.Equals(xrmPermission.Record?.Id);
            btnDelete.Enabled = !Guid.Empty.Equals(xrmPermission.Record?.Id) && node.Nodes.Count == 0;
            UpdateWebroleButtons();
        }

        private void PopulatePermissionEntities()
        {
            var entities = allentities.Where(e => e.IsIntersect != true);
            var fromentity = string.Empty;
            switch (GetScope())
            {
                case Scope.Parent:
                    fromentity = GetParentPermissionEntityName();
                    break;

                case Scope.Account:
                    fromentity = "account";
                    break;

                case Scope.Contact:
                    fromentity = "contact";
                    break;

                case Scope.Self:
                    entities = entities.Where(e => e.LogicalName == "contact");
                    break;

                case Scope.Global:
                    break;
            }
            if (!string.IsNullOrEmpty(fromentity))
            {
                entities = entities.Where(e =>
                    e.OneToManyRelationships?.Any(r => r.ReferencingEntity.Equals(fromentity)) == true ||
                    e.ManyToOneRelationships?.Any(r => r.ReferencedEntity.Equals(fromentity)) == true ||
                    e.ManyToManyRelationships?.Any(r => r.Entity1LogicalName.Equals(fromentity)) == true ||
                    e.ManyToManyRelationships?.Any(r => r.Entity2LogicalName.Equals(fromentity)) == true);
            }
            var entityname = xrmPermission[Entitypermission.EntityLogicalName] as string;
            cmbItemEntity.DataSource = entities;
            cmbItemEntity.SetSelected(entityname);
            cmbItemEntity.Enabled = cmbItemEntity.Items.Count > 0;
            cmbItemEntity.DropDownStyle = cmbItemEntity.Items.Count > 100 ? ComboBoxStyle.DropDown : ComboBoxStyle.DropDownList;
            if (cmbItemEntity.Items.Count == 1 && cmbItemEntity.SelectedEntity == null)
            {
                cmbItemEntity.SelectedIndex = 0;
            }
            PopulatePermissionRelationships();
        }

        private void PopulatePermissionRelationships()
        {
            var fromentity = GetFromEntity();
            var toentity = GetToEntity();
            if (fromentity == null || toentity == null)
            {
                cmbItemRelationship.SelectedItem = null;
                cmbItemRelationship.SelectedIndex = -1;
                cmbItemRelationship.DataSource = null;
                lblNoRelationships.Text = "Not applicable";
                lblNoRelationships.Visible = true;
                cmbItemRelationship.Visible = false;
                return;
            }
            var fromname = fromentity.Metadata.LogicalName;
            var toname = toentity.Metadata.LogicalName;
            var rel1m = toentity.Metadata.OneToManyRelationships.Where(r => r.ReferencingEntity.Equals(fromname));
            var relm1 = toentity.Metadata.ManyToOneRelationships.Where(r => r.ReferencedEntity.Equals(fromname));
            var relmm = toentity.Metadata.ManyToManyRelationships.Where(r =>
                (r.Entity1LogicalName.Equals(fromname) && r.Entity2LogicalName.Equals(toname)) ||
                (r.Entity1LogicalName.Equals(toname) && r.Entity2LogicalName.Equals(fromname)));
            var rels = rel1m.Select(r => new RelationshipItem(r, $"1:M {r.ReferencingEntity} {r.ReferencingAttribute}"))
                .Concat(relm1.Select(r => new RelationshipItem(r, $"M:1 {r.ReferencingAttribute} {r.ReferencedEntity}")))
                .Concat(relmm.Select(r => new RelationshipItem(r, $"M:M {(r.Entity1LogicalName != toname ? r.Entity1LogicalName : r.Entity2LogicalName)}")));

            // Kommer hit massor med gånger när bara en post valts.

            var relationship = xrmPermission[GetRelationshipColumn()] as string;
            cmbItemRelationship.DataSource = rels.ToList();
            if (!string.IsNullOrEmpty(relationship) &&
                cmbItemRelationship.DataSource is IEnumerable<RelationshipItem> ds &&
                ds?.FirstOrDefault(e => e.Metadata.SchemaName.Equals(relationship)) is RelationshipItem newselected)
            {
                cmbItemRelationship.SelectedItem = newselected;
            }
            else
            {
                cmbItemRelationship.SelectedItem = null;
                cmbItemRelationship.SelectedIndex = -1;
            }

            lblNoRelationships.Text = $"No relationships available between {fromentity} and {toentity}";
            lblNoRelationships.Visible = rels.Count() == 0;
            cmbItemRelationship.Visible = !lblNoRelationships.Visible;
            txtItemRelationship.Visible = !lblNoRelationships.Visible;
        }

        private void PopulatePermissionsTree(EntityCollection newpermissions)
        {
            permissions = newpermissions.Entities;
            PopulatePermissionsTree();
        }

        private void PopulatePermissionsTree()
        {
            tvPermissions.Nodes.Clear();
            tvPermissions.Nodes.AddRange(GetChildPermissions(null).ToArray());
            GetChildNodeDetails(tvPermissions.Nodes);
            //tvPermissions.ExpandAll();
        }

        private void SavePermissionItem()
        {
            var isnew = xrmPermission.Record.Id.Equals(Guid.Empty);
            var parentchanged = xrmPermission.ChangedColumns.ToList().Contains(Entitypermission.ParentEntitypermission);
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Saving Entity Permission",
                Work = (worker, args) =>
                {
                    offmainthread = true;
                    xrmPermission.SaveChanges();
                    args.Result = xrmPermission.Record;
                    offmainthread = false;
                },
                PostWorkCallBack = (args) => HandleWorkAsync<Entity>(args, (savedpermission) =>
                {
                    var permissionitem = new PermissionItem(savedpermission, rbTreeRels.Checked, Service);
                    if (isnew)
                    {
                        var node = permissionitem.ToNode();
                        var parentnode = GetScope() == Scope.Parent ? isnew ? tvPermissions.SelectedNode : node.Parent : null;
                        if (parentnode != null)
                        {
                            parentnode.Nodes.Add(node);
                        }
                        else
                        {
                            tvPermissions.Nodes.Add(node);
                        }
                    }
                    else
                    {
                        var node = tvPermissions.SelectedNode;
                        permissionitem.DefineNode(node);
                        if (parentchanged)
                        {
                            if (savedpermission.TryGetAttributeValue(Entitypermission.ParentEntitypermission, out EntityReference parentref) &&
                                FindNodeByRecordId(tvPermissions.Nodes.OfType<TreeNode>(), parentref.Id) is TreeNode parentnode &&
                                node.Parent != parentnode)
                            {
                                node.Parent.Nodes.Remove(node);
                                parentnode.Nodes.Add(node);
                            }
                        }
                    }
                    LogPendingChanges();
                })
            });
        }

        private void UpdateWebroleButtons()
        {
            btnWebroleAdd.Enabled = xrmPermission.Record != null && !xrmPermission.Id.Equals(Guid.Empty);
            btnWebroleRemove.Enabled = btnWebroleAdd.Enabled && grdWebroles.SelectedCellRecords?.Count() > 0;
        }

        #endregion Private Methods
    }
}