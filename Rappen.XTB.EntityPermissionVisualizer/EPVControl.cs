using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using Rappen.XTB.Helpers.ControlItems;
using System;
using System.Windows.Forms;
using XrmToolBox.Extensibility;

namespace Rappen.XTB.EPV
{
    public partial class EPVControl : PluginControlBase
    {
        #region Public Constructors

        public EPVControl()
        {
            InitializeComponent();
        }

        #endregion Public Constructors

        #region Public Methods

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

        #endregion Public Methods

        #region Private Methods

        private void btnItemNewChild_Click(object sender, EventArgs e)
        {
            OpenNewPermission(txtItemName.Entity);
        }

        private void btnItemOpen_Click(object sender, EventArgs e)
        {
            OpenPermission(txtItemName.Entity);
        }

        private void cmbWebsite_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPermissions();
        }

        private void MyPluginControl_Load(object sender, EventArgs e)
        {
            if (!SettingsManager.Instance.TryLoad(GetType(), out mySettings))
            {
                mySettings = new Settings();
            }
        }

        private void rbTreeNames_CheckedChanged(object sender, EventArgs e)
        {
            PopulatePermissions();
        }

        private void tvPermissions_AfterSelect(object sender, TreeViewEventArgs e)
        {
            PermissionSelected(e.Node.Tag as EntityItem);
        }

        private void tvPermissions_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            GetChildNodeDetails(e.Node.Nodes);
        }

        #endregion Private Methods
    }
}