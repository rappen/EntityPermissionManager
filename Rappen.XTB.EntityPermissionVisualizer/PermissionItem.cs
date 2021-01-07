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
            var nodeformat = relationships ? "{adx_entitylogicalname} {adx_contactrelationship}{adx_accountrelationship}{adx_parentrelationship}" : "{adx_entityname}";
            TreeNodeText = Entity.Substitute(organizationService, nodeformat);
        }

        public void LoadDetails()
        {
            if (relationships)
            {
                var text = new StringBuilder();
                if (Entity.TryGetAttributeValue(EntitypeRmission.EntityLogicalName, out string entity) && !string.IsNullOrEmpty(entity) &&
                    Bag.Service.GetEntity(entity) is EntityMetadata entitymeta)
                {
                    var emdi = new EntityMetadataItem(entitymeta, true);
                    var rel = string.Empty;
                    switch (Scope)
                    {
                        case EntitypeRmission.Scope_OptionSet.Kontakt:
                            if (Entity.TryGetAttributeValue(EntitypeRmission.ContactRelationship, out string crel))
                            {
                                rel = crel;
                            }
                            break;
                        case EntitypeRmission.Scope_OptionSet.Konto:
                            if (Entity.TryGetAttributeValue(EntitypeRmission.AccountRelationship, out string arel))
                            {
                                rel = arel;
                            }
                            break;
                        case EntitypeRmission.Scope_OptionSet.Overordnad:
                            if (Entity.TryGetAttributeValue(EntitypeRmission.ParentRelationship, out string prel))
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
                if (Entity.TryGetAttributeValue(EntitypeRmission.Create, out bool create) && create)
                {
                    text.Append("C");
                }
                if (Entity.TryGetAttributeValue(EntitypeRmission.Read, out bool read) && read)
                {
                    text.Append("R");
                }
                if (Entity.TryGetAttributeValue(EntitypeRmission.Write, out bool update) && update)
                {
                    text.Append("U");
                }
                if (Entity.TryGetAttributeValue(EntitypeRmission.Delete, out bool delete) && delete)
                {
                    text.Append("D");
                }
                if (Entity.TryGetAttributeValue(EntitypeRmission.Append, out bool append) && append)
                {
                    text.Append("A");
                }
                if (Entity.TryGetAttributeValue(EntitypeRmission.Appendto, out bool appendto) && appendto)
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
                if (Entity.TryGetAttributeValue(EntitypeRmission.PrimaryName, out string name))
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

        private EntitypeRmission.Scope_OptionSet Scope => (EntitypeRmission.Scope_OptionSet)ScopeValue;

        private int ScopeValue
        {
            get
            {
                if (Entity.TryGetAttributeValue(EntitypeRmission.Scope, out OptionSetValue scope))
                {
                    return scope.Value;
                }
                return (int)EntitypeRmission.Scope_OptionSet.Global;
            }
        }
    }
}
