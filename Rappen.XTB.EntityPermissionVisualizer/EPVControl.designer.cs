namespace Rappen.XTB.EPV
{
    partial class EPVControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EPVControl));
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvPermissions = new System.Windows.Forms.TreeView();
            this.imgScope = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbWebsite = new xrmtb.XrmToolBox.Controls.Controls.CDSDataComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panItem = new System.Windows.Forms.Panel();
            this.btnItemNewChild = new System.Windows.Forms.Button();
            this.btnItemOpen = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtItemName = new xrmtb.XrmToolBox.Controls.Controls.CDSDataTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtItemEntity = new xrmtb.XrmToolBox.Controls.Controls.CDSDataTextBox();
            this.txtItemRelationship = new xrmtb.XrmToolBox.Controls.Controls.CDSDataTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtItemScope = new xrmtb.XrmToolBox.Controls.Controls.CDSDataTextBox();
            this.txtItemParent = new xrmtb.XrmToolBox.Controls.Controls.CDSDataTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.grdWebroles = new xrmtb.XrmToolBox.Controls.CRMGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.txtItemPrivileges = new Rappen.XTB.Helpers.Controls.XRMDataTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panItem.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdWebroles)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Size = new System.Drawing.Size(983, 25);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvPermissions);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2.Controls.Add(this.panItem);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(983, 778);
            this.splitContainer1.SplitterDistance = 327;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 5;
            // 
            // tvPermissions
            // 
            this.tvPermissions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvPermissions.ImageIndex = 0;
            this.tvPermissions.ImageList = this.imgScope;
            this.tvPermissions.Location = new System.Drawing.Point(0, 56);
            this.tvPermissions.Name = "tvPermissions";
            this.tvPermissions.SelectedImageIndex = 0;
            this.tvPermissions.Size = new System.Drawing.Size(327, 722);
            this.tvPermissions.TabIndex = 1;
            this.tvPermissions.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvPermissions_AfterSelect);
            // 
            // imgScope
            // 
            this.imgScope.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgScope.ImageStream")));
            this.imgScope.TransparentColor = System.Drawing.Color.Transparent;
            this.imgScope.Images.SetKeyName(0, "earth.png");
            this.imgScope.Images.SetKeyName(1, "user2.png");
            this.imgScope.Images.SetKeyName(2, "folder.png");
            this.imgScope.Images.SetKeyName(3, "arrow_up_blue.png");
            this.imgScope.Images.SetKeyName(4, "bullet_ball_glass_red.png");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbWebsite);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(327, 56);
            this.panel1.TabIndex = 0;
            // 
            // cmbWebsite
            // 
            this.cmbWebsite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbWebsite.DisplayFormat = "";
            this.cmbWebsite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWebsite.FormattingEnabled = true;
            this.cmbWebsite.Location = new System.Drawing.Point(76, 16);
            this.cmbWebsite.Name = "cmbWebsite";
            this.cmbWebsite.OrganizationService = null;
            this.cmbWebsite.Size = new System.Drawing.Size(235, 21);
            this.cmbWebsite.TabIndex = 1;
            this.cmbWebsite.SelectedIndexChanged += new System.EventHandler(this.cmbWebsite_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Website";
            // 
            // panItem
            // 
            this.panItem.Controls.Add(this.txtItemPrivileges);
            this.panItem.Controls.Add(this.label7);
            this.panItem.Controls.Add(this.txtItemName);
            this.panItem.Controls.Add(this.label2);
            this.panItem.Controls.Add(this.label6);
            this.panItem.Controls.Add(this.txtItemEntity);
            this.panItem.Controls.Add(this.txtItemRelationship);
            this.panItem.Controls.Add(this.label3);
            this.panItem.Controls.Add(this.label5);
            this.panItem.Controls.Add(this.txtItemScope);
            this.panItem.Controls.Add(this.txtItemParent);
            this.panItem.Controls.Add(this.label4);
            this.panItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.panItem.Location = new System.Drawing.Point(0, 56);
            this.panItem.Name = "panItem";
            this.panItem.Size = new System.Drawing.Size(648, 165);
            this.panItem.TabIndex = 12;
            // 
            // btnItemNewChild
            // 
            this.btnItemNewChild.Enabled = false;
            this.btnItemNewChild.Location = new System.Drawing.Point(290, 7);
            this.btnItemNewChild.Name = "btnItemNewChild";
            this.btnItemNewChild.Size = new System.Drawing.Size(152, 36);
            this.btnItemNewChild.TabIndex = 13;
            this.btnItemNewChild.Text = "New Child Permission";
            this.btnItemNewChild.UseVisualStyleBackColor = true;
            this.btnItemNewChild.Click += new System.EventHandler(this.btnItemNewChild_Click);
            // 
            // btnItemOpen
            // 
            this.btnItemOpen.Enabled = false;
            this.btnItemOpen.Location = new System.Drawing.Point(132, 7);
            this.btnItemOpen.Name = "btnItemOpen";
            this.btnItemOpen.Size = new System.Drawing.Size(152, 36);
            this.btnItemOpen.TabIndex = 12;
            this.btnItemOpen.Text = "Open Entity Permission";
            this.btnItemOpen.UseVisualStyleBackColor = true;
            this.btnItemOpen.Click += new System.EventHandler(this.btnItemOpen_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Privileges";
            // 
            // txtItemName
            // 
            this.txtItemName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemName.BackColor = System.Drawing.SystemColors.Window;
            this.txtItemName.DisplayFormat = "adx_entityname";
            this.txtItemName.Entity = null;
            this.txtItemName.EntityReference = null;
            this.txtItemName.Id = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.txtItemName.Location = new System.Drawing.Point(132, 13);
            this.txtItemName.LogicalName = null;
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.OrganizationService = null;
            this.txtItemName.Size = new System.Drawing.Size(494, 20);
            this.txtItemName.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Relationship";
            // 
            // txtItemEntity
            // 
            this.txtItemEntity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemEntity.BackColor = System.Drawing.SystemColors.Window;
            this.txtItemEntity.DisplayFormat = "adx_entitylogicalname";
            this.txtItemEntity.Entity = null;
            this.txtItemEntity.EntityReference = null;
            this.txtItemEntity.Id = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.txtItemEntity.Location = new System.Drawing.Point(132, 39);
            this.txtItemEntity.LogicalName = null;
            this.txtItemEntity.Name = "txtItemEntity";
            this.txtItemEntity.OrganizationService = null;
            this.txtItemEntity.Size = new System.Drawing.Size(494, 20);
            this.txtItemEntity.TabIndex = 2;
            // 
            // txtItemRelationship
            // 
            this.txtItemRelationship.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemRelationship.BackColor = System.Drawing.SystemColors.Window;
            this.txtItemRelationship.DisplayFormat = "{{adx_contactrelationship}}{{adx_accountrelationship}}{{adx_parentrelationship}}";
            this.txtItemRelationship.Entity = null;
            this.txtItemRelationship.EntityReference = null;
            this.txtItemRelationship.Id = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.txtItemRelationship.Location = new System.Drawing.Point(132, 117);
            this.txtItemRelationship.LogicalName = null;
            this.txtItemRelationship.Name = "txtItemRelationship";
            this.txtItemRelationship.OrganizationService = null;
            this.txtItemRelationship.Size = new System.Drawing.Size(494, 20);
            this.txtItemRelationship.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Entity";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Parent";
            // 
            // txtItemScope
            // 
            this.txtItemScope.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemScope.BackColor = System.Drawing.SystemColors.Window;
            this.txtItemScope.DisplayFormat = "adx_scope";
            this.txtItemScope.Entity = null;
            this.txtItemScope.EntityReference = null;
            this.txtItemScope.Id = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.txtItemScope.Location = new System.Drawing.Point(132, 65);
            this.txtItemScope.LogicalName = null;
            this.txtItemScope.Name = "txtItemScope";
            this.txtItemScope.OrganizationService = null;
            this.txtItemScope.Size = new System.Drawing.Size(494, 20);
            this.txtItemScope.TabIndex = 4;
            // 
            // txtItemParent
            // 
            this.txtItemParent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemParent.BackColor = System.Drawing.SystemColors.Window;
            this.txtItemParent.DisplayFormat = "adx_parententitypermission";
            this.txtItemParent.Entity = null;
            this.txtItemParent.EntityReference = null;
            this.txtItemParent.Id = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.txtItemParent.Location = new System.Drawing.Point(132, 91);
            this.txtItemParent.LogicalName = null;
            this.txtItemParent.Name = "txtItemParent";
            this.txtItemParent.OrganizationService = null;
            this.txtItemParent.Size = new System.Drawing.Size(494, 20);
            this.txtItemParent.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Scope";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnItemOpen);
            this.panel2.Controls.Add(this.btnItemNewChild);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(648, 56);
            this.panel2.TabIndex = 13;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 221);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.label8);
            this.splitContainer2.Panel1.Controls.Add(this.grdWebroles);
            this.splitContainer2.Size = new System.Drawing.Size(648, 557);
            this.splitContainer2.SplitterDistance = 243;
            this.splitContainer2.SplitterWidth = 8;
            this.splitContainer2.TabIndex = 14;
            // 
            // grdWebroles
            // 
            this.grdWebroles.AllowUserToOrderColumns = true;
            this.grdWebroles.AllowUserToResizeRows = false;
            this.grdWebroles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdWebroles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdWebroles.BackgroundColor = System.Drawing.SystemColors.Window;
            this.grdWebroles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdWebroles.ColumnHeadersVisible = false;
            this.grdWebroles.ColumnOrder = "";
            this.grdWebroles.FilterColumns = "";
            this.grdWebroles.Location = new System.Drawing.Point(132, 3);
            this.grdWebroles.Name = "grdWebroles";
            this.grdWebroles.OrganizationService = null;
            this.grdWebroles.RowHeadersVisible = false;
            this.grdWebroles.ShowFriendlyNames = true;
            this.grdWebroles.ShowIdColumn = false;
            this.grdWebroles.ShowIndexColumn = false;
            this.grdWebroles.Size = new System.Drawing.Size(494, 237);
            this.grdWebroles.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Webroles";
            // 
            // txtItemPrivileges
            // 
            this.txtItemPrivileges.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemPrivileges.BackColor = System.Drawing.SystemColors.Window;
            this.txtItemPrivileges.DisplayFormat = resources.GetString("txtItemPrivileges.DisplayFormat");
            this.txtItemPrivileges.Entity = null;
            this.txtItemPrivileges.EntityReference = null;
            this.txtItemPrivileges.Id = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.txtItemPrivileges.Location = new System.Drawing.Point(132, 143);
            this.txtItemPrivileges.LogicalName = null;
            this.txtItemPrivileges.Name = "txtItemPrivileges";
            this.txtItemPrivileges.OrganizationService = null;
            this.txtItemPrivileges.Size = new System.Drawing.Size(494, 20);
            this.txtItemPrivileges.TabIndex = 14;
            // 
            // EPVControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStripMenu);
            this.Name = "EPVControl";
            this.Size = new System.Drawing.Size(983, 803);
            this.Load += new System.EventHandler(this.MyPluginControl_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panItem.ResumeLayout(false);
            this.panItem.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdWebroles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private xrmtb.XrmToolBox.Controls.Controls.CDSDataComboBox cmbWebsite;
        private System.Windows.Forms.TreeView tvPermissions;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private xrmtb.XrmToolBox.Controls.Controls.CDSDataTextBox txtItemRelationship;
        private System.Windows.Forms.Label label5;
        private xrmtb.XrmToolBox.Controls.Controls.CDSDataTextBox txtItemParent;
        private System.Windows.Forms.Label label4;
        private xrmtb.XrmToolBox.Controls.Controls.CDSDataTextBox txtItemScope;
        private System.Windows.Forms.Label label3;
        private xrmtb.XrmToolBox.Controls.Controls.CDSDataTextBox txtItemEntity;
        private System.Windows.Forms.Label label2;
        private xrmtb.XrmToolBox.Controls.Controls.CDSDataTextBox txtItemName;
        private System.Windows.Forms.Panel panItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ImageList imgScope;
        private System.Windows.Forms.Button btnItemOpen;
        private System.Windows.Forms.Button btnItemNewChild;
        private Helpers.Controls.XRMDataTextBox txtItemPrivileges;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private xrmtb.XrmToolBox.Controls.CRMGridView grdWebroles;
        private System.Windows.Forms.Label label8;
    }
}
