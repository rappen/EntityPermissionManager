using Microsoft.Xrm.Sdk.Metadata;

namespace Rappen.XTB.EPV
{
    public class RelationshipItem
    {
        #region Private Fields

        private string name;

        #endregion Private Fields

        #region Public Constructors

        public RelationshipItem(RelationshipMetadataBase metadata, string name)
        {
            Metadata = metadata;
            this.name = name;
        }

        #endregion Public Constructors

        #region Public Properties

        public RelationshipMetadataBase Metadata { get; }

        #endregion Public Properties

        #region Public Methods

        public override string ToString() => name;

        #endregion Public Methods
    }
}