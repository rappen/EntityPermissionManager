using Microsoft.Xrm.Sdk.Metadata;

namespace Rappen.XTB.EPV
{
    public class RelationshipItem
    {
        private string name;

        public RelationshipMetadataBase Metadata { get; }

        public RelationshipItem(RelationshipMetadataBase metadata, string name)
        {
            Metadata = metadata;
            this.name = name;
        }

        public override string ToString() => name;
    }
}