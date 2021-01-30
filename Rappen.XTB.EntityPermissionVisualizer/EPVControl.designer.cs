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
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.btnOpen = new System.Windows.Forms.ToolStripButton();
            this.btnNewChild = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.lblAbout = new System.Windows.Forms.ToolStripLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvPermissions = new System.Windows.Forms.TreeView();
            this.imgScope = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.rbTreeRels = new System.Windows.Forms.RadioButton();
            this.rbTreeNames = new System.Windows.Forms.RadioButton();
            this.cmbWebsite = new Rappen.XTB.Helpers.Controls.XRMColumnLookup();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label8 = new System.Windows.Forms.Label();
            this.grdWebroles = new Rappen.XTB.Helpers.Controls.XRMDataGridView();
            this.panItem = new System.Windows.Forms.Panel();
            this.txtItemEntityName = new System.Windows.Forms.TextBox();
            this.txtItemPrivileges = new Rappen.XTB.Helpers.Controls.XRMColumnText();
            this.xrmPermission = new Rappen.XTB.Helpers.Controls.XRMRecordHost();
            this.label7 = new System.Windows.Forms.Label();
            this.txtItemName = new Rappen.XTB.Helpers.Controls.XRMColumnText();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtItemEntity = new Rappen.XTB.Helpers.Controls.XRMColumnText();
            this.txtItemRelationship = new Rappen.XTB.Helpers.Controls.XRMColumnText();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbItemScope = new Rappen.XTB.Helpers.Controls.XRMColumnOptionSet();
            this.cmbItemParent = new Rappen.XTB.Helpers.Controls.XRMColumnLookup();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolStripMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdWebroles)).BeginInit();
            this.panItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNew,
            this.btnOpen,
            this.btnNewChild,
            this.btnDelete,
            this.toolStripSeparator1,
            this.btnRefresh,
            this.lblAbout});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Size = new System.Drawing.Size(983, 31);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // btnNew
            // 
            this.btnNew.Enabled = false;
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(59, 28);
            this.btnNew.Text = "New";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Enabled = false;
            this.btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnOpen.Image")));
            this.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(64, 28);
            this.btnOpen.Text = "Open";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnNewChild
            // 
            this.btnNewChild.Enabled = false;
            this.btnNewChild.Image = ((System.Drawing.Image)(resources.GetObject("btnNewChild.Image")));
            this.btnNewChild.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNewChild.Name = "btnNewChild";
            this.btnNewChild.Size = new System.Drawing.Size(90, 28);
            this.btnNewChild.Text = "New Child";
            this.btnNewChild.Click += new System.EventHandler(this.btnNewChild_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(68, 28);
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Enabled = false;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(71, 28);
            this.btnRefresh.Text = "Reload";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblAbout
            // 
            this.lblAbout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblAbout.Image = ((System.Drawing.Image)(resources.GetObject("lblAbout.Image")));
            this.lblAbout.IsLink = true;
            this.lblAbout.Name = "lblAbout";
            this.lblAbout.Size = new System.Drawing.Size(106, 28);
            this.lblAbout.Text = "by Jonas Rapp";
            this.lblAbout.Click += new System.EventHandler(this.lblAbout_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 31);
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
            this.splitContainer1.Size = new System.Drawing.Size(983, 772);
            this.splitContainer1.SplitterDistance = 421;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 5;
            // 
            // tvPermissions
            // 
            this.tvPermissions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvPermissions.ImageIndex = 0;
            this.tvPermissions.ImageList = this.imgScope;
            this.tvPermissions.Location = new System.Drawing.Point(16, 72);
            this.tvPermissions.Name = "tvPermissions";
            this.tvPermissions.SelectedImageIndex = 0;
            this.tvPermissions.Size = new System.Drawing.Size(389, 700);
            this.tvPermissions.TabIndex = 1;
            this.tvPermissions.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvPermissions_BeforeExpand);
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
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.rbTreeRels);
            this.panel1.Controls.Add(this.rbTreeNames);
            this.panel1.Controls.Add(this.cmbWebsite);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(421, 72);
            this.panel1.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Show";
            // 
            // rbTreeRels
            // 
            this.rbTreeRels.AutoSize = true;
            this.rbTreeRels.Location = new System.Drawing.Point(223, 43);
            this.rbTreeRels.Name = "rbTreeRels";
            this.rbTreeRels.Size = new System.Drawing.Size(121, 17);
            this.rbTreeRels.TabIndex = 3;
            this.rbTreeRels.TabStop = true;
            this.rbTreeRels.Text = "Actual Relationships";
            this.rbTreeRels.UseVisualStyleBackColor = true;
            // 
            // rbTreeNames
            // 
            this.rbTreeNames.AutoSize = true;
            this.rbTreeNames.Checked = true;
            this.rbTreeNames.Location = new System.Drawing.Point(76, 43);
            this.rbTreeNames.Name = "rbTreeNames";
            this.rbTreeNames.Size = new System.Drawing.Size(140, 17);
            this.rbTreeNames.TabIndex = 2;
            this.rbTreeNames.TabStop = true;
            this.rbTreeNames.Text = "Entity Permission Names";
            this.rbTreeNames.UseVisualStyleBackColor = true;
            this.rbTreeNames.CheckedChanged += new System.EventHandler(this.rbTreeNames_CheckedChanged);
            // 
            // cmbWebsite
            // 
            this.cmbWebsite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbWebsite.Column = null;
            this.cmbWebsite.DisplayFormat = "";
            this.cmbWebsite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWebsite.Filter = null;
            this.cmbWebsite.FormattingEnabled = true;
            this.cmbWebsite.Location = new System.Drawing.Point(76, 16);
            this.cmbWebsite.Name = "cmbWebsite";
            this.cmbWebsite.RecordHost = null;
            this.cmbWebsite.Service = null;
            this.cmbWebsite.Size = new System.Drawing.Size(329, 21);
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
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 237);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.label8);
            this.splitContainer2.Panel1.Controls.Add(this.grdWebroles);
            this.splitContainer2.Size = new System.Drawing.Size(554, 535);
            this.splitContainer2.SplitterDistance = 233;
            this.splitContainer2.SplitterWidth = 8;
            this.splitContainer2.TabIndex = 14;
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
            // grdWebroles
            // 
            this.grdWebroles.AllowUserToAddRows = false;
            this.grdWebroles.AllowUserToDeleteRows = false;
            this.grdWebroles.AllowUserToOrderColumns = true;
            this.grdWebroles.AllowUserToResizeRows = false;
            this.grdWebroles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdWebroles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdWebroles.BackgroundColor = System.Drawing.SystemColors.Window;
            this.grdWebroles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdWebroles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdWebroles.ColumnHeadersVisible = false;
            this.grdWebroles.ColumnOrder = "";
            this.grdWebroles.FilterColumns = "";
            this.grdWebroles.Location = new System.Drawing.Point(132, 3);
            this.grdWebroles.Name = "grdWebroles";
            this.grdWebroles.ReadOnly = true;
            this.grdWebroles.RowHeadersVisible = false;
            this.grdWebroles.Service = null;
            this.grdWebroles.ShowFriendlyNames = true;
            this.grdWebroles.ShowIdColumn = false;
            this.grdWebroles.ShowIndexColumn = false;
            this.grdWebroles.Size = new System.Drawing.Size(400, 227);
            this.grdWebroles.TabIndex = 0;
            // 
            // panItem
            // 
            this.panItem.Controls.Add(this.txtItemEntityName);
            this.panItem.Controls.Add(this.txtItemPrivileges);
            this.panItem.Controls.Add(this.label7);
            this.panItem.Controls.Add(this.txtItemName);
            this.panItem.Controls.Add(this.label2);
            this.panItem.Controls.Add(this.label6);
            this.panItem.Controls.Add(this.txtItemEntity);
            this.panItem.Controls.Add(this.txtItemRelationship);
            this.panItem.Controls.Add(this.label3);
            this.panItem.Controls.Add(this.label5);
            this.panItem.Controls.Add(this.cmbItemScope);
            this.panItem.Controls.Add(this.cmbItemParent);
            this.panItem.Controls.Add(this.label4);
            this.panItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.panItem.Location = new System.Drawing.Point(0, 72);
            this.panItem.Name = "panItem";
            this.panItem.Size = new System.Drawing.Size(554, 165);
            this.panItem.TabIndex = 12;
            // 
            // txtItemEntityName
            // 
            this.txtItemEntityName.Location = new System.Drawing.Point(132, 39);
            this.txtItemEntityName.Name = "txtItemEntityName";
            this.txtItemEntityName.Size = new System.Drawing.Size(234, 20);
            this.txtItemEntityName.TabIndex = 15;
            // 
            // txtItemPrivileges
            // 
            this.txtItemPrivileges.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemPrivileges.BackColor = System.Drawing.SystemColors.Window;
            this.txtItemPrivileges.Column = "";
            this.txtItemPrivileges.DisplayFormat = resources.GetString("txtItemPrivileges.DisplayFormat");
            this.txtItemPrivileges.Location = new System.Drawing.Point(132, 143);
            this.txtItemPrivileges.Name = "txtItemPrivileges";
            this.txtItemPrivileges.ReadOnly = true;
            this.txtItemPrivileges.RecordHost = this.xrmPermission;
            this.txtItemPrivileges.Size = new System.Drawing.Size(400, 20);
            this.txtItemPrivileges.TabIndex = 14;
            // 
            // xrmPermission
            // 
            this.xrmPermission.Id = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.xrmPermission.LogicalName = null;
            this.xrmPermission.Record = null;
            this.xrmPermission.Service = null;
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
            this.txtItemName.Column = "adx_entityname";
            this.txtItemName.DisplayFormat = "";
            this.txtItemName.Location = new System.Drawing.Point(132, 13);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.RecordHost = this.xrmPermission;
            this.txtItemName.Size = new System.Drawing.Size(400, 20);
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
            this.txtItemEntity.Column = "adx_entitylogicalname";
            this.txtItemEntity.DisplayFormat = "";
            this.txtItemEntity.Location = new System.Drawing.Point(372, 39);
            this.txtItemEntity.Name = "txtItemEntity";
            this.txtItemEntity.RecordHost = this.xrmPermission;
            this.txtItemEntity.Size = new System.Drawing.Size(160, 20);
            this.txtItemEntity.TabIndex = 2;
            // 
            // txtItemRelationship
            // 
            this.txtItemRelationship.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemRelationship.BackColor = System.Drawing.SystemColors.Window;
            this.txtItemRelationship.Column = "{adx_contactrelationship}{adx_accountrelationship}{adx_parentrelationship}";
            this.txtItemRelationship.DisplayFormat = "";
            this.txtItemRelationship.Location = new System.Drawing.Point(132, 117);
            this.txtItemRelationship.Name = "txtItemRelationship";
            this.txtItemRelationship.ReadOnly = true;
            this.txtItemRelationship.RecordHost = this.xrmPermission;
            this.txtItemRelationship.Size = new System.Drawing.Size(400, 20);
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
            // cmbItemScope
            // 
            this.cmbItemScope.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbItemScope.BackColor = System.Drawing.SystemColors.Window;
            this.cmbItemScope.Column = "adx_scope";
            this.cmbItemScope.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItemScope.Location = new System.Drawing.Point(132, 65);
            this.cmbItemScope.Name = "cmbItemScope";
            this.cmbItemScope.RecordHost = this.xrmPermission;
            this.cmbItemScope.Size = new System.Drawing.Size(400, 21);
            this.cmbItemScope.TabIndex = 4;
            // 
            // cmbItemParent
            // 
            this.cmbItemParent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbItemParent.BackColor = System.Drawing.SystemColors.Window;
            this.cmbItemParent.Column = "adx_parententitypermission";
            this.cmbItemParent.DisplayFormat = "";
            this.cmbItemParent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItemParent.Filter = null;
            this.cmbItemParent.Location = new System.Drawing.Point(132, 91);
            this.cmbItemParent.Name = "cmbItemParent";
            this.cmbItemParent.RecordHost = this.xrmPermission;
            this.cmbItemParent.Service = null;
            this.cmbItemParent.Size = new System.Drawing.Size(400, 21);
            this.cmbItemParent.TabIndex = 6;
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
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(554, 72);
            this.panel2.TabIndex = 13;
            // 
            // EPVControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStripMenu);
            this.Name = "EPVControl";
            this.PluginIcon = ((System.Drawing.Icon)(resources.GetObject("$this.PluginIcon")));
            this.Size = new System.Drawing.Size(983, 803);
            this.TabIcon = ((System.Drawing.Image)(resources.GetObject("$this.TabIcon")));
            this.Load += new System.EventHandler(this.EPVControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdWebroles)).EndInit();
            this.panItem.ResumeLayout(false);
            this.panItem.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private Helpers.Controls.XRMColumnLookup cmbWebsite;
        private System.Windows.Forms.TreeView tvPermissions;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private Helpers.Controls.XRMColumnText txtItemRelationship;
        private System.Windows.Forms.Label label5;
        private Helpers.Controls.XRMColumnLookup cmbItemParent;
        private System.Windows.Forms.Label label4;
        private Helpers.Controls.XRMColumnOptionSet cmbItemScope;
        private System.Windows.Forms.Label label3;
        private Helpers.Controls.XRMColumnText txtItemEntity;
        private System.Windows.Forms.Label label2;
        private Helpers.Controls.XRMColumnText txtItemName;
        private System.Windows.Forms.Panel panItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ImageList imgScope;
        private Helpers.Controls.XRMColumnText txtItemPrivileges;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Helpers.Controls.XRMDataGridView grdWebroles;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtItemEntityName;
        private System.Windows.Forms.RadioButton rbTreeRels;
        private System.Windows.Forms.RadioButton rbTreeNames;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ToolStripButton btnNew;
        private System.Windows.Forms.ToolStripButton btnOpen;
        private System.Windows.Forms.ToolStripButton btnNewChild;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripLabel lblAbout;
        private Helpers.Controls.XRMRecordHost xrmPermission;
    }
}
