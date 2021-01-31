using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using Rappen.XTB.Helpers.Extensions;
using System;
using System.Diagnostics;
using System.Linq;
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
            ConnectionUpdated(newService);
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
            OpenNewPermission(xrmPermission.Record);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenPermission(xrmPermission.Record);
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

        private void xrmPermission_RecordColumnUpdated(object sender, Helpers.Controls.XRMRecordEventArgs e)
        {
            btnItemSave.Enabled = xrmPermission.ChangedColumns?.Count() > 0;
            btnItemUndo.Enabled = btnItemSave.Enabled;
            listLog.Items.Clear();
            if (xrmPermission?.ChangedColumns != null)
            {
                foreach (var key in xrmPermission.ChangedColumns)
                {
                    var value = xrmPermission[key];
                    xrmPermission.Record.TryGetAttributeValue(key, out object oldvalue);
                    var log = listLog.Items.Add(key);
                    log.SubItems.Add(value != null ? EntityExtensions.AttributeToBaseType(value).ToString() : "null");
                    log.SubItems.Add(value != null ? value.GetType().ToString() : oldvalue != null ? oldvalue.GetType().ToString() : "null");
                    log.SubItems.Add(oldvalue != null ? EntityExtensions.AttributeToBaseType(oldvalue).ToString() : "null");
                }
            }
        }

        private void btnItemSave_Click(object sender, EventArgs e)
        {
            xrmPermission.SaveChanges();
        }

        private void btnItemUndo_Click(object sender, EventArgs e)
        {
            xrmPermission.UndoChanges();
        }
    }
}