using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using Rappen.XTB.Helpers;
using Rappen.XTB.Helpers.ControlItems;
using Rappen.XTB.Helpers.Extensions;
using System.Text;
using System.Windows.Forms;

namespace Rappen.XTB.EPV
{
    public class PermissionItem : EntityItem
    {
        private bool relationships;

        public bool DetailsLoaded { get; set; }
        public string TreeNodeText { get; internal set; }

        public PermissionItem(Entity entity, bool relationships, IOrganizationService organizationService) : base(entity, organizationService)
        {
            this.relationships = relationships;
            TreeNodeText = Entity.Substitute(organizationService, "{" + Entitypermission.PrimaryName + "}");
        }

        public void LoadDetails()
        {
            if (relationships)
            {
                var text = new StringBuilder();
                if (Entity.TryGetAttributeValue(Entitypermission.EntityLogicalName, out string entity) && !string.IsNullOrEmpty(entity) &&
                    Bag.Service.GetEntity(entity) is EntityMetadata entitymeta)
                {
                    var emdi = new EntityMetadataItem(entitymeta, true);
                    var rel = string.Empty;
                    switch (Scope)
                    {
                        case Entitypermission.Scope_OptionSet.Contact:
                            if (Entity.TryGetAttributeValue(Entitypermission.ContactRelationship, out string crel))
                            {
                                rel = crel;
                            }
                            break;

                        case Entitypermission.Scope_OptionSet.Account:
                            if (Entity.TryGetAttributeValue(Entitypermission.AccountRelationship, out string arel))
                            {
                                rel = arel;
                            }
                            break;

                        case Entitypermission.Scope_OptionSet.Parent:
                            if (Entity.TryGetAttributeValue(Entitypermission.ParentRelationship, out string prel))
                            {
                                rel = prel;
                            }
                            break;
                    }
                    text.Append(" ");
                    if (!string.IsNullOrEmpty(rel) && emdi.GetRelationship(rel) is OneToManyRelationshipMetadata relmeta)
                    {
                        var referencing = new EntityMetadataItem(Bag.Service.GetEntity(relmeta.ReferencingEntity), true);
                        var referenced = new EntityMetadataItem(Bag.Service.GetEntity(relmeta.ReferencedEntity), true);
                        if (relmeta.ReferencingEntity.Equals(entitymeta.LogicalName))
                        {
                            if (Bag.Service.GetAttribute(relmeta.ReferencingEntity, relmeta.ReferencingAttribute) is AttributeMetadata attrmeta)
                            {
                                var amdi = new AttributeMetadataItem(attrmeta, true);
                                text.Append($"{referencing.CollectionDisplayName} for {amdi}");
                            }
                            else
                            {
                                text.Append($"{referencing.CollectionDisplayName} for {referenced}");
                            }
                        }
                        else if (relmeta.ReferencedEntity.Equals(entitymeta.LogicalName))
                        {
                            text.Append($"{emdi} of {referencing}");
                        }
                    }
                    else
                    {
                        text.Append(emdi.DisplayName);
                    }
                }
                text.Append(" (");
                if (Entity.TryGetAttributeValue(Entitypermission.Create, out bool create) && create)
                {
                    text.Append("C");
                }
                if (Entity.TryGetAttributeValue(Entitypermission.Read, out bool read) && read)
                {
                    text.Append("R");
                }
                if (Entity.TryGetAttributeValue(Entitypermission.Write, out bool update) && update)
                {
                    text.Append("U");
                }
                if (Entity.TryGetAttributeValue(Entitypermission.Delete, out bool delete) && delete)
                {
                    text.Append("D");
                }
                if (Entity.TryGetAttributeValue(Entitypermission.Append, out bool append) && append)
                {
                    text.Append("A");
                }
                if (Entity.TryGetAttributeValue(Entitypermission.Appendto, out bool appendto) && appendto)
                {
                    text.Append("T");
                }
                text.Append(")");
                TreeNodeText = text.ToString().Replace("  ", " ").Replace("()", "").Trim();
            }
            DetailsLoaded = true;
        }

        public TreeNode ToNode()
        {
            var name = TreeNodeText;
            var image = ScopeValue - 756150000;
            var node = new TreeNode(name, image, image) { Tag = this };
            return node;
        }

        public string OrderBy
        {
            get
            {
                var result = ScopeValue.ToString("0000000000000");
                if (Entity.TryGetAttributeValue(Entitypermission.PrimaryName, out string name))
                {
                    result += name;
                }
                else
                {
                    result += Entity.Id.ToString();
                }
                return result;
            }
        }

        private Entitypermission.Scope_OptionSet Scope => (Entitypermission.Scope_OptionSet)ScopeValue;

        private int ScopeValue
        {
            get
            {
                if (Entity.TryGetAttributeValue(Entitypermission.Scope, out OptionSetValue scope))
                {
                    return scope.Value;
                }
                return (int)Entitypermission.Scope_OptionSet.Global;
            }
        }
    }
}