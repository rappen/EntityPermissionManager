namespace Rappen.XTB.EPM
{
    partial class EPMControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EPMControl));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvPermissions = new System.Windows.Forms.TreeView();
            this.imgScope = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.rbTreeRels = new System.Windows.Forms.RadioButton();
            this.rbTreeNames = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.chkShowDebug = new System.Windows.Forms.CheckBox();
            this.panWebroleButtons = new System.Windows.Forms.Panel();
            this.btnWebroleRemove = new System.Windows.Forms.Button();
            this.btnWebroleAdd = new System.Windows.Forms.Button();
            this.panWebroles = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.lblNoRoles = new System.Windows.Forms.Label();
            this.panItem = new System.Windows.Forms.Panel();
            this.lblNoParent = new System.Windows.Forms.Label();
            this.lblNoRelationships = new System.Windows.Forms.Label();
            this.cmbItemRelationship = new System.Windows.Forms.ComboBox();
            this.btnItemUndo = new System.Windows.Forms.Button();
            this.btnItemSave = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNewChild = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.listLog = new System.Windows.Forms.ListView();
            this.colColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOld = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNew = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cmbWebsite = new Rappen.XTB.Helpers.Controls.XRMColumnLookup();
            this.grdWebroles = new Rappen.XTB.Helpers.Controls.XRMDataGridView();
            this.cmbItemEntity = new Rappen.XTB.Helpers.Controls.XRMEntityComboBox();
            this.xrmColumnBool6 = new Rappen.XTB.Helpers.Controls.XRMColumnBool();
            this.xrmPermission = new Rappen.XTB.Helpers.Controls.XRMRecordHost();
            this.xrmColumnBool5 = new Rappen.XTB.Helpers.Controls.XRMColumnBool();
            this.xrmColumnBool4 = new Rappen.XTB.Helpers.Controls.XRMColumnBool();
            this.xrmColumnBool3 = new Rappen.XTB.Helpers.Controls.XRMColumnBool();
            this.xrmColumnBool2 = new Rappen.XTB.Helpers.Controls.XRMColumnBool();
            this.xrmColumnBool1 = new Rappen.XTB.Helpers.Controls.XRMColumnBool();
            this.txtItemName = new Rappen.XTB.Helpers.Controls.XRMColumnText();
            this.txtItemEntity = new Rappen.XTB.Helpers.Controls.XRMColumnText();
            this.txtItemRelationship = new Rappen.XTB.Helpers.Controls.XRMColumnText();
            this.cmbItemScope = new Rappen.XTB.Helpers.Controls.XRMColumnOptionSet();
            this.cmbItemParent = new Rappen.XTB.Helpers.Controls.XRMColumnLookup();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panWebroleButtons.SuspendLayout();
            this.panWebroles.SuspendLayout();
            this.panItem.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdWebroles)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
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
            this.splitContainer1.Size = new System.Drawing.Size(983, 556);
            this.splitContainer1.SplitterDistance = 421;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 5;
            // 
            // tvPermissions
            // 
            this.tvPermissions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvPermissions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvPermissions.HideSelection = false;
            this.tvPermissions.ImageIndex = 0;
            this.tvPermissions.ImageList = this.imgScope;
            this.tvPermissions.Location = new System.Drawing.Point(16, 109);
            this.tvPermissions.Name = "tvPermissions";
            this.tvPermissions.SelectedImageIndex = 0;
            this.tvPermissions.Size = new System.Drawing.Size(387, 445);
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
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.rbTreeRels);
            this.panel1.Controls.Add(this.rbTreeNames);
            this.panel1.Controls.Add(this.cmbWebsite);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(419, 96);
            this.panel1.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.White;
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(330, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(86, 73);
            this.btnRefresh.TabIndex = 4;
            this.toolTip1.SetToolTip(this.btnRefresh, "Reload all Entity Permissions");
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // rbTreeRels
            // 
            this.rbTreeRels.AutoSize = true;
            this.rbTreeRels.Location = new System.Drawing.Point(180, 56);
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
            this.rbTreeNames.Location = new System.Drawing.Point(16, 56);
            this.rbTreeNames.Name = "rbTreeNames";
            this.rbTreeNames.Size = new System.Drawing.Size(140, 17);
            this.rbTreeNames.TabIndex = 2;
            this.rbTreeNames.TabStop = true;
            this.rbTreeNames.Text = "Entity Permission Names";
            this.rbTreeNames.UseVisualStyleBackColor = true;
            this.rbTreeNames.CheckedChanged += new System.EventHandler(this.rbTreeNames_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Website";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.chkShowDebug);
            this.splitContainer2.Panel1.Controls.Add(this.panWebroleButtons);
            this.splitContainer2.Panel1.Controls.Add(this.panWebroles);
            this.splitContainer2.Panel1.Controls.Add(this.panItem);
            this.splitContainer2.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.listLog);
            this.splitContainer2.Panel2Collapsed = true;
            this.splitContainer2.Size = new System.Drawing.Size(552, 554);
            this.splitContainer2.SplitterDistance = 504;
            this.splitContainer2.SplitterWidth = 8;
            this.splitContainer2.TabIndex = 14;
            // 
            // chkShowDebug
            // 
            this.chkShowDebug.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkShowDebug.AutoSize = true;
            this.chkShowDebug.Location = new System.Drawing.Point(443, 534);
            this.chkShowDebug.Name = "chkShowDebug";
            this.chkShowDebug.Size = new System.Drawing.Size(106, 17);
            this.chkShowDebug.TabIndex = 14;
            this.chkShowDebug.Text = "Show debug info";
            this.chkShowDebug.UseVisualStyleBackColor = true;
            this.chkShowDebug.CheckedChanged += new System.EventHandler(this.chkShowDebug_CheckedChanged);
            // 
            // panWebroleButtons
            // 
            this.panWebroleButtons.Controls.Add(this.btnWebroleRemove);
            this.panWebroleButtons.Controls.Add(this.btnWebroleAdd);
            this.panWebroleButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.panWebroleButtons.Location = new System.Drawing.Point(0, 395);
            this.panWebroleButtons.Name = "panWebroleButtons";
            this.panWebroleButtons.Size = new System.Drawing.Size(552, 42);
            this.panWebroleButtons.TabIndex = 3;
            // 
            // btnWebroleRemove
            // 
            this.btnWebroleRemove.Enabled = false;
            this.btnWebroleRemove.Location = new System.Drawing.Point(190, 6);
            this.btnWebroleRemove.Name = "btnWebroleRemove";
            this.btnWebroleRemove.Size = new System.Drawing.Size(75, 23);
            this.btnWebroleRemove.TabIndex = 1;
            this.btnWebroleRemove.Text = "Remove";
            this.btnWebroleRemove.UseVisualStyleBackColor = true;
            this.btnWebroleRemove.Click += new System.EventHandler(this.btnWebroleRemove_Click);
            // 
            // btnWebroleAdd
            // 
            this.btnWebroleAdd.Enabled = false;
            this.btnWebroleAdd.Location = new System.Drawing.Point(98, 6);
            this.btnWebroleAdd.Name = "btnWebroleAdd";
            this.btnWebroleAdd.Size = new System.Drawing.Size(75, 23);
            this.btnWebroleAdd.TabIndex = 0;
            this.btnWebroleAdd.Text = "Add";
            this.btnWebroleAdd.UseVisualStyleBackColor = true;
            this.btnWebroleAdd.Click += new System.EventHandler(this.btnWebroleAdd_Click);
            // 
            // panWebroles
            // 
            this.panWebroles.BackColor = System.Drawing.SystemColors.Window;
            this.panWebroles.Controls.Add(this.label8);
            this.panWebroles.Controls.Add(this.lblNoRoles);
            this.panWebroles.Controls.Add(this.grdWebroles);
            this.panWebroles.Dock = System.Windows.Forms.DockStyle.Top;
            this.panWebroles.Location = new System.Drawing.Point(0, 354);
            this.panWebroles.Name = "panWebroles";
            this.panWebroles.Size = new System.Drawing.Size(552, 41);
            this.panWebroles.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Webroles";
            // 
            // lblNoRoles
            // 
            this.lblNoRoles.AutoSize = true;
            this.lblNoRoles.Location = new System.Drawing.Point(99, 12);
            this.lblNoRoles.Name = "lblNoRoles";
            this.lblNoRoles.Size = new System.Drawing.Size(111, 13);
            this.lblNoRoles.TabIndex = 1;
            this.lblNoRoles.Text = "No assigned webroles";
            this.lblNoRoles.Visible = false;
            // 
            // panItem
            // 
            this.panItem.Controls.Add(this.lblNoParent);
            this.panItem.Controls.Add(this.lblNoRelationships);
            this.panItem.Controls.Add(this.cmbItemRelationship);
            this.panItem.Controls.Add(this.cmbItemEntity);
            this.panItem.Controls.Add(this.xrmColumnBool6);
            this.panItem.Controls.Add(this.xrmColumnBool5);
            this.panItem.Controls.Add(this.xrmColumnBool4);
            this.panItem.Controls.Add(this.xrmColumnBool3);
            this.panItem.Controls.Add(this.xrmColumnBool2);
            this.panItem.Controls.Add(this.xrmColumnBool1);
            this.panItem.Controls.Add(this.btnItemUndo);
            this.panItem.Controls.Add(this.btnItemSave);
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
            this.panItem.Enabled = false;
            this.panItem.Location = new System.Drawing.Point(0, 96);
            this.panItem.Name = "panItem";
            this.panItem.Size = new System.Drawing.Size(552, 258);
            this.panItem.TabIndex = 12;
            // 
            // lblNoParent
            // 
            this.lblNoParent.AutoSize = true;
            this.lblNoParent.Location = new System.Drawing.Point(99, 69);
            this.lblNoParent.Name = "lblNoParent";
            this.lblNoParent.Size = new System.Drawing.Size(75, 13);
            this.lblNoParent.TabIndex = 29;
            this.lblNoParent.Text = "Not applicable";
            this.lblNoParent.Visible = false;
            // 
            // lblNoRelationships
            // 
            this.lblNoRelationships.AutoSize = true;
            this.lblNoRelationships.Location = new System.Drawing.Point(99, 138);
            this.lblNoRelationships.Name = "lblNoRelationships";
            this.lblNoRelationships.Size = new System.Drawing.Size(127, 13);
            this.lblNoRelationships.TabIndex = 26;
            this.lblNoRelationships.Text = "No relationships available";
            this.lblNoRelationships.Visible = false;
            // 
            // cmbItemRelationship
            // 
            this.cmbItemRelationship.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbItemRelationship.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItemRelationship.FormattingEnabled = true;
            this.cmbItemRelationship.Location = new System.Drawing.Point(98, 135);
            this.cmbItemRelationship.Name = "cmbItemRelationship";
            this.cmbItemRelationship.Size = new System.Drawing.Size(432, 21);
            this.cmbItemRelationship.TabIndex = 25;
            this.cmbItemRelationship.SelectedIndexChanged += new System.EventHandler(this.cmbItemRelationship_SelectedIndexChanged);
            // 
            // btnItemUndo
            // 
            this.btnItemUndo.Enabled = false;
            this.btnItemUndo.Location = new System.Drawing.Point(190, 223);
            this.btnItemUndo.Name = "btnItemUndo";
            this.btnItemUndo.Size = new System.Drawing.Size(75, 23);
            this.btnItemUndo.TabIndex = 17;
            this.btnItemUndo.Text = "Undo";
            this.btnItemUndo.UseVisualStyleBackColor = true;
            this.btnItemUndo.Visible = false;
            this.btnItemUndo.Click += new System.EventHandler(this.btnItemUndo_Click);
            // 
            // btnItemSave
            // 
            this.btnItemSave.Enabled = false;
            this.btnItemSave.Location = new System.Drawing.Point(98, 223);
            this.btnItemSave.Name = "btnItemSave";
            this.btnItemSave.Size = new System.Drawing.Size(75, 23);
            this.btnItemSave.TabIndex = 16;
            this.btnItemSave.Text = "Save";
            this.btnItemSave.UseVisualStyleBackColor = true;
            this.btnItemSave.Click += new System.EventHandler(this.btnItemSave_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 183);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Privileges";
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
            this.label6.Location = new System.Drawing.Point(24, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Relationship";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Table";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Parent";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Scope";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnAbout);
            this.panel2.Controls.Add(this.btnOpen);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnNewChild);
            this.panel2.Controls.Add(this.btnNew);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(552, 96);
            this.panel2.TabIndex = 13;
            // 
            // btnAbout
            // 
            this.btnAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbout.BackColor = System.Drawing.Color.White;
            this.btnAbout.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAbout.FlatAppearance.BorderSize = 0;
            this.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbout.Image = ((System.Drawing.Image)(resources.GetObject("btnAbout.Image")));
            this.btnAbout.Location = new System.Drawing.Point(463, 8);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(86, 73);
            this.btnAbout.TabIndex = 4;
            this.toolTip1.SetToolTip(this.btnAbout, "About Entity Permission Manager");
            this.btnAbout.UseVisualStyleBackColor = false;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.BackColor = System.Drawing.Color.White;
            this.btnOpen.Enabled = false;
            this.btnOpen.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnOpen.FlatAppearance.BorderSize = 0;
            this.btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnOpen.Image")));
            this.btnOpen.Location = new System.Drawing.Point(343, 10);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(86, 73);
            this.btnOpen.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btnOpen, "Open Entity Permission in Dataverse");
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.White;
            this.btnDelete.Enabled = false;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(238, 8);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(86, 73);
            this.btnDelete.TabIndex = 2;
            this.toolTip1.SetToolTip(this.btnDelete, "Delete selected Entity Permission");
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNewChild
            // 
            this.btnNewChild.BackColor = System.Drawing.Color.White;
            this.btnNewChild.Enabled = false;
            this.btnNewChild.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnNewChild.FlatAppearance.BorderSize = 0;
            this.btnNewChild.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewChild.Image = ((System.Drawing.Image)(resources.GetObject("btnNewChild.Image")));
            this.btnNewChild.Location = new System.Drawing.Point(132, 8);
            this.btnNewChild.Name = "btnNewChild";
            this.btnNewChild.Size = new System.Drawing.Size(86, 73);
            this.btnNewChild.TabIndex = 1;
            this.toolTip1.SetToolTip(this.btnNewChild, "Create New Child Entity Permission");
            this.btnNewChild.UseVisualStyleBackColor = false;
            this.btnNewChild.Click += new System.EventHandler(this.btnNewChild_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.White;
            this.btnNew.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.Location = new System.Drawing.Point(27, 8);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(86, 73);
            this.btnNew.TabIndex = 0;
            this.toolTip1.SetToolTip(this.btnNew, "Create New Entity Permission");
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // listLog
            // 
            this.listLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colColumn,
            this.colOld,
            this.colNew,
            this.colType});
            this.listLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listLog.HideSelection = false;
            this.listLog.Location = new System.Drawing.Point(0, 0);
            this.listLog.Name = "listLog";
            this.listLog.Size = new System.Drawing.Size(150, 46);
            this.listLog.TabIndex = 0;
            this.listLog.UseCompatibleStateImageBehavior = false;
            this.listLog.View = System.Windows.Forms.View.Details;
            // 
            // colColumn
            // 
            this.colColumn.Text = "Column";
            this.colColumn.Width = 139;
            // 
            // colOld
            // 
            this.colOld.Text = "Old value";
            this.colOld.Width = 117;
            // 
            // colNew
            // 
            this.colNew.Text = "New value";
            this.colNew.Width = 117;
            // 
            // colType
            // 
            this.colType.Text = "Type";
            this.colType.Width = 154;
            // 
            // toolTip1
            // 
            this.toolTip1.ForeColor = System.Drawing.SystemColors.HotTrack;
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
            this.cmbWebsite.Location = new System.Drawing.Point(65, 24);
            this.cmbWebsite.Name = "cmbWebsite";
            this.cmbWebsite.RecordHost = null;
            this.cmbWebsite.Service = null;
            this.cmbWebsite.Size = new System.Drawing.Size(236, 21);
            this.cmbWebsite.TabIndex = 1;
            this.cmbWebsite.SelectedIndexChanged += new System.EventHandler(this.cmbWebsite_SelectedIndexChanged);
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
            this.grdWebroles.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.grdWebroles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdWebroles.ColumnHeadersVisible = false;
            this.grdWebroles.ColumnOrder = "";
            this.grdWebroles.FilterColumns = "";
            this.grdWebroles.Location = new System.Drawing.Point(98, 8);
            this.grdWebroles.Name = "grdWebroles";
            this.grdWebroles.ReadOnly = true;
            this.grdWebroles.RowHeadersVisible = false;
            this.grdWebroles.Service = null;
            this.grdWebroles.ShowFriendlyNames = true;
            this.grdWebroles.ShowIdColumn = false;
            this.grdWebroles.ShowIndexColumn = false;
            this.grdWebroles.Size = new System.Drawing.Size(398, 30);
            this.grdWebroles.TabIndex = 0;
            this.grdWebroles.SelectionChanged += new System.EventHandler(this.grdWebroles_SelectionChanged);
            // 
            // cmbItemEntity
            // 
            this.cmbItemEntity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbItemEntity.FormattingEnabled = true;
            this.cmbItemEntity.Location = new System.Drawing.Point(98, 93);
            this.cmbItemEntity.Name = "cmbItemEntity";
            this.cmbItemEntity.Size = new System.Drawing.Size(432, 21);
            this.cmbItemEntity.TabIndex = 24;
            this.cmbItemEntity.SelectedIndexChanged += new System.EventHandler(this.cmbItemEntity_SelectedIndexChanged);
            // 
            // xrmColumnBool6
            // 
            this.xrmColumnBool6.AutoSize = true;
            this.xrmColumnBool6.Column = "adx_appendto";
            this.xrmColumnBool6.Location = new System.Drawing.Point(418, 182);
            this.xrmColumnBool6.Name = "xrmColumnBool6";
            this.xrmColumnBool6.RecordHost = this.xrmPermission;
            this.xrmColumnBool6.ShowMetadataLabels = false;
            this.xrmColumnBool6.Size = new System.Drawing.Size(79, 17);
            this.xrmColumnBool6.TabIndex = 23;
            this.xrmColumnBool6.Text = "Append To";
            this.xrmColumnBool6.UseVisualStyleBackColor = true;
            // 
            // xrmPermission
            // 
            this.xrmPermission.Id = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.xrmPermission.LogicalName = null;
            this.xrmPermission.Record = null;
            this.xrmPermission.Service = null;
            this.xrmPermission.ColumnValueChanged += new Rappen.XTB.Helpers.Controls.XRMRecordEventHandler(this.xrmPermission_RecordColumnUpdated);
            // 
            // xrmColumnBool5
            // 
            this.xrmColumnBool5.AutoSize = true;
            this.xrmColumnBool5.Column = "adx_append";
            this.xrmColumnBool5.Location = new System.Drawing.Point(349, 182);
            this.xrmColumnBool5.Name = "xrmColumnBool5";
            this.xrmColumnBool5.RecordHost = this.xrmPermission;
            this.xrmColumnBool5.ShowMetadataLabels = false;
            this.xrmColumnBool5.Size = new System.Drawing.Size(63, 17);
            this.xrmColumnBool5.TabIndex = 22;
            this.xrmColumnBool5.Text = "Append";
            this.xrmColumnBool5.UseVisualStyleBackColor = true;
            // 
            // xrmColumnBool4
            // 
            this.xrmColumnBool4.AutoSize = true;
            this.xrmColumnBool4.Column = "adx_delete";
            this.xrmColumnBool4.Location = new System.Drawing.Point(286, 182);
            this.xrmColumnBool4.Name = "xrmColumnBool4";
            this.xrmColumnBool4.RecordHost = this.xrmPermission;
            this.xrmColumnBool4.ShowMetadataLabels = false;
            this.xrmColumnBool4.Size = new System.Drawing.Size(57, 17);
            this.xrmColumnBool4.TabIndex = 21;
            this.xrmColumnBool4.Text = "Delete";
            this.xrmColumnBool4.UseVisualStyleBackColor = true;
            // 
            // xrmColumnBool3
            // 
            this.xrmColumnBool3.AutoSize = true;
            this.xrmColumnBool3.Column = "adx_write";
            this.xrmColumnBool3.Location = new System.Drawing.Point(219, 182);
            this.xrmColumnBool3.Name = "xrmColumnBool3";
            this.xrmColumnBool3.RecordHost = this.xrmPermission;
            this.xrmColumnBool3.ShowMetadataLabels = false;
            this.xrmColumnBool3.Size = new System.Drawing.Size(61, 17);
            this.xrmColumnBool3.TabIndex = 20;
            this.xrmColumnBool3.Text = "Update";
            this.xrmColumnBool3.UseVisualStyleBackColor = true;
            // 
            // xrmColumnBool2
            // 
            this.xrmColumnBool2.AutoSize = true;
            this.xrmColumnBool2.Column = "adx_create";
            this.xrmColumnBool2.Location = new System.Drawing.Point(156, 182);
            this.xrmColumnBool2.Name = "xrmColumnBool2";
            this.xrmColumnBool2.RecordHost = this.xrmPermission;
            this.xrmColumnBool2.ShowMetadataLabels = false;
            this.xrmColumnBool2.Size = new System.Drawing.Size(57, 17);
            this.xrmColumnBool2.TabIndex = 19;
            this.xrmColumnBool2.Text = "Create";
            this.xrmColumnBool2.UseVisualStyleBackColor = true;
            // 
            // xrmColumnBool1
            // 
            this.xrmColumnBool1.AutoSize = true;
            this.xrmColumnBool1.Column = "adx_read";
            this.xrmColumnBool1.Location = new System.Drawing.Point(98, 182);
            this.xrmColumnBool1.Name = "xrmColumnBool1";
            this.xrmColumnBool1.RecordHost = this.xrmPermission;
            this.xrmColumnBool1.ShowMetadataLabels = false;
            this.xrmColumnBool1.Size = new System.Drawing.Size(52, 17);
            this.xrmColumnBool1.TabIndex = 18;
            this.xrmColumnBool1.Text = "Read";
            this.xrmColumnBool1.UseVisualStyleBackColor = true;
            // 
            // txtItemName
            // 
            this.txtItemName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemName.BackColor = System.Drawing.SystemColors.Window;
            this.txtItemName.Column = "adx_entityname";
            this.txtItemName.DisplayFormat = "";
            this.txtItemName.Location = new System.Drawing.Point(98, 13);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.RecordHost = this.xrmPermission;
            this.txtItemName.Size = new System.Drawing.Size(432, 20);
            this.txtItemName.TabIndex = 0;
            // 
            // txtItemEntity
            // 
            this.txtItemEntity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemEntity.BackColor = System.Drawing.SystemColors.Window;
            this.txtItemEntity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtItemEntity.Column = "adx_entitylogicalname";
            this.txtItemEntity.DisplayFormat = "";
            this.txtItemEntity.Location = new System.Drawing.Point(102, 116);
            this.txtItemEntity.Name = "txtItemEntity";
            this.txtItemEntity.ReadOnly = true;
            this.txtItemEntity.RecordHost = this.xrmPermission;
            this.txtItemEntity.Size = new System.Drawing.Size(428, 13);
            this.txtItemEntity.TabIndex = 2;
            // 
            // txtItemRelationship
            // 
            this.txtItemRelationship.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemRelationship.BackColor = System.Drawing.SystemColors.Window;
            this.txtItemRelationship.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtItemRelationship.Column = "";
            this.txtItemRelationship.DisplayFormat = "";
            this.txtItemRelationship.Location = new System.Drawing.Point(102, 158);
            this.txtItemRelationship.Name = "txtItemRelationship";
            this.txtItemRelationship.ReadOnly = true;
            this.txtItemRelationship.RecordHost = this.xrmPermission;
            this.txtItemRelationship.Size = new System.Drawing.Size(427, 13);
            this.txtItemRelationship.TabIndex = 8;
            // 
            // cmbItemScope
            // 
            this.cmbItemScope.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbItemScope.BackColor = System.Drawing.SystemColors.Window;
            this.cmbItemScope.Column = "adx_scope";
            this.cmbItemScope.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItemScope.Location = new System.Drawing.Point(98, 39);
            this.cmbItemScope.Name = "cmbItemScope";
            this.cmbItemScope.RecordHost = this.xrmPermission;
            this.cmbItemScope.ShowValue = false;
            this.cmbItemScope.Size = new System.Drawing.Size(432, 21);
            this.cmbItemScope.TabIndex = 4;
            this.cmbItemScope.SelectedIndexChanged += new System.EventHandler(this.cmbItemScope_SelectedIndexChanged);
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
            this.cmbItemParent.Location = new System.Drawing.Point(98, 66);
            this.cmbItemParent.Name = "cmbItemParent";
            this.cmbItemParent.RecordHost = this.xrmPermission;
            this.cmbItemParent.Service = null;
            this.cmbItemParent.Size = new System.Drawing.Size(432, 21);
            this.cmbItemParent.TabIndex = 6;
            this.cmbItemParent.SelectedIndexChanged += new System.EventHandler(this.cmbItemParent_SelectedIndexChanged);
            // 
            // EPMControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.splitContainer1);
            this.Name = "EPMControl";
            this.PluginIcon = ((System.Drawing.Icon)(resources.GetObject("$this.PluginIcon")));
            this.Size = new System.Drawing.Size(983, 556);
            this.TabIcon = ((System.Drawing.Image)(resources.GetObject("$this.TabIcon")));
            this.Load += new System.EventHandler(this.EPMControl_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panWebroleButtons.ResumeLayout(false);
            this.panWebroles.ResumeLayout(false);
            this.panWebroles.PerformLayout();
            this.panItem.ResumeLayout(false);
            this.panItem.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdWebroles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
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
        private Helpers.Controls.XRMDataGridView grdWebroles;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton rbTreeRels;
        private System.Windows.Forms.RadioButton rbTreeNames;
        private Helpers.Controls.XRMRecordHost xrmPermission;
        private System.Windows.Forms.Button btnItemSave;
        private System.Windows.Forms.Button btnItemUndo;
        private Helpers.Controls.XRMColumnBool xrmColumnBool6;
        private Helpers.Controls.XRMColumnBool xrmColumnBool5;
        private Helpers.Controls.XRMColumnBool xrmColumnBool4;
        private Helpers.Controls.XRMColumnBool xrmColumnBool3;
        private Helpers.Controls.XRMColumnBool xrmColumnBool2;
        private Helpers.Controls.XRMColumnBool xrmColumnBool1;
        private System.Windows.Forms.Label lblNoRoles;
        private System.Windows.Forms.ListView listLog;
        private System.Windows.Forms.ColumnHeader colColumn;
        private System.Windows.Forms.ColumnHeader colNew;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.ColumnHeader colOld;
        private Helpers.Controls.XRMEntityComboBox cmbItemEntity;
        private System.Windows.Forms.ComboBox cmbItemRelationship;
        private System.Windows.Forms.Label lblNoRelationships;
        private System.Windows.Forms.Label lblNoParent;
        private System.Windows.Forms.Panel panWebroles;
        private System.Windows.Forms.Panel panWebroleButtons;
        private System.Windows.Forms.Button btnWebroleRemove;
        private System.Windows.Forms.Button btnWebroleAdd;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.CheckBox chkShowDebug;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNewChild;
        private System.Windows.Forms.Button btnNew;
    }
}
