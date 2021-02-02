﻿using McTools.Xrm.Connection;
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
        #region Private Fields

        private const string aiEndpoint = "https://dc.services.visualstudio.com/v2/track";
        private const string aiKey = "eed73022-2444-45fd-928b-5eebd8fa46a6";    // jonas@rappen.net tenant, XrmToolBox
        private AppInsights ai;

        #endregion Private Fields

        #region Public Properties

        public string RepositoryName => "EntityPermissionVisualizer";

        public string UserName => "rappen";

        #endregion Public Properties

        #region Public Constructors

        public EPVControl()
        {
            InitializeComponent();
            ai = new AppInsights(aiEndpoint, aiKey, Assembly.GetExecutingAssembly(), "Entity Permission Visualizer");
            MetadataExtensions.entityProperties = MetadataExtensions.entityProperties.Concat(new string[] { "ManyToOneRelationships", "OneToManyRelationships", "ManyToManyRelationships" }).ToArray();
        }

        #endregion Public Constructors

        #region Public Methods

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

        private void btnItemSave_Click(object sender, EventArgs e)
        {
            xrmPermission.SaveChanges();
        }

        private void btnItemUndo_Click(object sender, EventArgs e)
        {
            xrmPermission.UndoChanges();
            PermissionSelected(tvPermissions.SelectedNode);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            CreateNewPermission(null);
        }

        private void btnNewChild_Click(object sender, EventArgs e)
        {
            CreateNewPermission(xrmPermission.Record);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenPermission(xrmPermission.Record);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadPermissions();
        }

        private void cmbItemEntity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!panItem.Enabled)
            {
                return;
            }
            PermissionEntityUpdated();
        }

        private void cmbItemParent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!panItem.Enabled)
            {
                return;
            }
            PopulatePermissionEntities();
        }

        private void cmbItemRelationship_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!panItem.Enabled)
            {
                return;
            }
            PermissionRelationshipUpdated();
        }

        private void cmbItemScope_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!panItem.Enabled)
            {
                return;
            }
            PermissionScopeUpdated();
        }

        private void cmbWebsite_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPermissions();
        }

        private void EPVControl_Load(object sender, EventArgs e)
        {
            ai.WriteEvent("Load");
        }

        private void lblAbout_Click(object sender, EventArgs e)
        {
            ShowAboutDialog();
        }

        private void rbTreeNames_CheckedChanged(object sender, EventArgs e)
        {
            PopulatePermissionsTree();
        }

        private void tvPermissions_AfterSelect(object sender, TreeViewEventArgs e)
        {
            PermissionSelected(e.Node);
        }

        private void tvPermissions_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            GetChildNodeDetails(e.Node.Nodes);
        }

        private void xrmPermission_RecordColumnUpdated(object sender, Helpers.Controls.XRMRecordEventArgs e)
        {
            LogPendingChanges();
        }

        #endregion Private Methods
    }
}