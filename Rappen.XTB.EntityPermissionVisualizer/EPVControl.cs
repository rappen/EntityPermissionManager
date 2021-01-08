using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace Rappen.XTB.EPV
{
    public partial class EPVControl : PluginControlBase, IAboutPlugin, IGitHubPlugin
    {
        private const string aiEndpoint = "https://dc.services.visualstudio.com/v2/track";
        private const string aiKey = "eed73022-2444-45fd-928b-5eebd8fa46a6";    // jonas@rappen.net tenant, XrmToolBox
        private AppInsights ai;

        public string RepositoryName => "EntityPermissionVisualizer";

        public string UserName => "rappen";

        #region Public Constructors

        public EPVControl()
        {
            InitializeComponent();
            ai = new AppInsights(aiEndpoint, aiKey, Assembly.GetExecutingAssembly(), "Entity Permission Visualizer");
        }

        #endregion Public Constructors

        #region Public Methods

        public override void ClosingPlugin(PluginCloseInfo info)
        {
            base.ClosingPlugin(info);
            if (!info.Cancel)
            {
                SettingsManager.Instance.Save(GetType(), mySettings);
            }
        }

        public void ShowAboutDialog()
        {
            Process.Start("https://jonasr.app");
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeletePermission(tvPermissions.SelectedNode);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            OpenNewPermission(null);
        }

        private void btnNewChild_Click(object sender, EventArgs e)
        {
            OpenNewPermission(txtItemName.Entity);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenPermission(txtItemName.Entity);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadPermissions();
        }

        private void cmbWebsite_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPermissions();
        }

        private void EPVControl_Load(object sender, EventArgs e)
        {
            ai.WriteEvent("Load"); 
            if (!SettingsManager.Instance.TryLoad(GetType(), out mySettings))
            {
                mySettings = new Settings();
            }
        }

        private void lblAbout_Click(object sender, EventArgs e)
        {
            ShowAboutDialog();
        }

        private void rbTreeNames_CheckedChanged(object sender, EventArgs e)
        {
            PopulatePermissions();
        }

        private void tvPermissions_AfterSelect(object sender, TreeViewEventArgs e)
        {
            PermissionSelected(e.Node);
        }

        private void tvPermissions_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            GetChildNodeDetails(e.Node.Nodes);
        }

        #endregion Private Methods
    }
}