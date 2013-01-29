using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
 
using PIVOTAL_API;
using PivotalTFSSync.Properties;

namespace PivotalTFSSync
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
  private Button btnConnectToPivotal;
        private Button btnConnectToTFS;
        private Button btnExport;
        private Button btnGetStories;
        private Button btnSync;
        private Button btnSyncSelected;
        private Button btnWizard;
        private ComboBox cboPivotalIteration;
        private ComboBox cboPivotalProjects;
        private ComboBox cboSyncDirection;
        private ComboBox cboTFSIterations;
        private ComboBox cboTFSProjects;
        private ComboBox cboTFSSubPath;
         
        private GroupBox groupBox1;
        private GroupBox groupBox3;
        private GroupBox grpPivotal;
        private GroupBox grpPivotalSettings;
        private GroupBox grpTFS;
        private GroupBox grpTFSSettings;
        private ImageList imglst;
        private Label label1;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label lblPivotalProjects;
        private Label lblProjects;
        private ListBox lstMessages;
        private NumericUpDown numSyncInterval;
        private PictureBox picLeft;
        private PictureBox picRight;
        private IPivotal pivotal;
        private Panel pnlLeft;
        private Panel pnlMessages;
        private Panel pnlRight;
        private Panel pnlSync;
        private System.Windows.Forms.Timer tmrErrorMessage;
        private System.Windows.Forms.Timer tmrSync;
        private TreeView tvwDetails;
        private TreeView tvwTFS;
        private TextBox txtDomain;
        private TextBox txtPivotalPassword;
        private TextBox txtPivotalUsername;
        private TextBox txtPriorityStep;
        private TextBox txtStartPriority;
        private TextBox txtTFSPassword;
        private TextBox txtTFSServerURL;
        private TextBox txtTFSUsername;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
          private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pnlMessages = new System.Windows.Forms.Panel();
            this.lstMessages = new System.Windows.Forms.ListBox();
            this.imglst = new System.Windows.Forms.ImageList(this.components);
            this.tmrSync = new System.Windows.Forms.Timer(this.components);
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.grpPivotalSettings = new System.Windows.Forms.GroupBox();
            this.btnConnectToPivotal = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPivotalPassword = new System.Windows.Forms.TextBox();
            this.txtPivotalUsername = new System.Windows.Forms.TextBox();
            this.grpPivotal = new System.Windows.Forms.GroupBox();
            this.btnWizard = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.lblPivotalProjects = new System.Windows.Forms.Label();
            this.cboPivotalProjects = new System.Windows.Forms.ComboBox();
            this.btnSyncSelected = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.cboPivotalIteration = new System.Windows.Forms.ComboBox();
            this.btnGetStories = new System.Windows.Forms.Button();
            this.tvwDetails = new System.Windows.Forms.TreeView();
            this.btnRapport = new System.Windows.Forms.Button();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.btnAddPivotalId = new System.Windows.Forms.Button();
            this.tvwTFS = new System.Windows.Forms.TreeView();
            this.grpTFSSettings = new System.Windows.Forms.GroupBox();
            this.btnConnectToTFS = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDomain = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTFSServerURL = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTFSPassword = new System.Windows.Forms.TextBox();
            this.txtTFSUsername = new System.Windows.Forms.TextBox();
            this.grpTFS = new System.Windows.Forms.GroupBox();
            this.lblProjects = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cboTFSProjects = new System.Windows.Forms.ComboBox();
            this.cboTFSSubPath = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPriorityStep = new System.Windows.Forms.TextBox();
            this.txtStartPriority = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cboTFSIterations = new System.Windows.Forms.ComboBox();
            this.pnlSync = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.chkKopieraPiovtalTasks = new System.Windows.Forms.CheckBox();
            this.chklstDefaultTasks = new System.Windows.Forms.CheckedListBox();
            this.btnSyncNow = new System.Windows.Forms.Button();
            this.btnSync = new System.Windows.Forms.Button();
            this.picLeft = new System.Windows.Forms.PictureBox();
            this.picRight = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboSyncDirection = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numSyncInterval = new System.Windows.Forms.NumericUpDown();
            this.tmrErrorMessage = new System.Windows.Forms.Timer(this.components);
            this.pnlMessages.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.grpPivotalSettings.SuspendLayout();
            this.grpPivotal.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.grpTFSSettings.SuspendLayout();
            this.grpTFS.SuspendLayout();
            this.pnlSync.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRight)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSyncInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMessages
            // 
            this.pnlMessages.Controls.Add(this.lstMessages);
            this.pnlMessages.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlMessages.Location = new System.Drawing.Point(0, 768);
            this.pnlMessages.Name = "pnlMessages";
            this.pnlMessages.Size = new System.Drawing.Size(1068, 66);
            this.pnlMessages.TabIndex = 21;
            // 
            // lstMessages
            // 
            this.lstMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstMessages.ForeColor = System.Drawing.Color.Red;
            this.lstMessages.FormattingEnabled = true;
            this.lstMessages.Location = new System.Drawing.Point(0, 0);
            this.lstMessages.Name = "lstMessages";
            this.lstMessages.Size = new System.Drawing.Size(1068, 66);
            this.lstMessages.TabIndex = 22;
            // 
            // imglst
            // 
            this.imglst.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglst.ImageStream")));
            this.imglst.TransparentColor = System.Drawing.Color.Transparent;
            this.imglst.Images.SetKeyName(0, "bug");
            this.imglst.Images.SetKeyName(1, "chore");
            this.imglst.Images.SetKeyName(2, "feature");
            this.imglst.Images.SetKeyName(3, "story_flyover_attachment_icon");
            this.imglst.Images.SetKeyName(4, "story_flyover_icon");
            this.imglst.Images.SetKeyName(5, "Product Backlog Item");
            // 
            // tmrSync
            // 
            this.tmrSync.Tick += new System.EventHandler(this.tmrSync_Tick);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.grpPivotalSettings);
            this.pnlLeft.Controls.Add(this.grpPivotal);
            this.pnlLeft.Controls.Add(this.tvwDetails);
            this.pnlLeft.Location = new System.Drawing.Point(4, 2);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(479, 760);
            this.pnlLeft.TabIndex = 22;
            // 
            // grpPivotalSettings
            // 
            this.grpPivotalSettings.Controls.Add(this.btnConnectToPivotal);
            this.grpPivotalSettings.Controls.Add(this.label2);
            this.grpPivotalSettings.Controls.Add(this.label1);
            this.grpPivotalSettings.Controls.Add(this.txtPivotalPassword);
            this.grpPivotalSettings.Controls.Add(this.txtPivotalUsername);
            this.grpPivotalSettings.Location = new System.Drawing.Point(11, 6);
            this.grpPivotalSettings.Name = "grpPivotalSettings";
            this.grpPivotalSettings.Size = new System.Drawing.Size(286, 140);
            this.grpPivotalSettings.TabIndex = 26;
            this.grpPivotalSettings.TabStop = false;
            this.grpPivotalSettings.Text = "Pivotal Settings";
            // 
            // btnConnectToPivotal
            // 
            this.btnConnectToPivotal.Enabled = false;
            this.btnConnectToPivotal.Location = new System.Drawing.Point(169, 108);
            this.btnConnectToPivotal.Name = "btnConnectToPivotal";
            this.btnConnectToPivotal.Size = new System.Drawing.Size(107, 27);
            this.btnConnectToPivotal.TabIndex = 30;
            this.btnConnectToPivotal.Text = "Connect to Pivotal";
            this.btnConnectToPivotal.UseVisualStyleBackColor = true;
            this.btnConnectToPivotal.Click += new System.EventHandler(this.btnConnectToPivotal_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Username";
            // 
            // txtPivotalPassword
            // 
            this.txtPivotalPassword.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::PivotalTFSSync.Properties.Settings.Default, "Pivotal_Password", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtPivotalPassword.Location = new System.Drawing.Point(9, 82);
            this.txtPivotalPassword.Name = "txtPivotalPassword";
            this.txtPivotalPassword.PasswordChar = '*';
            this.txtPivotalPassword.Size = new System.Drawing.Size(267, 20);
            this.txtPivotalPassword.TabIndex = 1;
            this.txtPivotalPassword.Text = global::PivotalTFSSync.Properties.Settings.Default.Pivotal_Password;
            this.txtPivotalPassword.UseSystemPasswordChar = true;
            this.txtPivotalPassword.Validated += new System.EventHandler(this.Validate_ReadyForSync);
            // 
            // txtPivotalUsername
            // 
            this.txtPivotalUsername.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::PivotalTFSSync.Properties.Settings.Default, "Pivotal_Username", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtPivotalUsername.Location = new System.Drawing.Point(9, 39);
            this.txtPivotalUsername.Name = "txtPivotalUsername";
            this.txtPivotalUsername.Size = new System.Drawing.Size(267, 20);
            this.txtPivotalUsername.TabIndex = 0;
            this.txtPivotalUsername.Text = global::PivotalTFSSync.Properties.Settings.Default.Pivotal_Username;
            this.txtPivotalUsername.Validated += new System.EventHandler(this.Validate_ReadyForSync);
            // 
            // grpPivotal
            // 
            this.grpPivotal.Controls.Add(this.btnWizard);
            this.grpPivotal.Controls.Add(this.btnExport);
            this.grpPivotal.Controls.Add(this.lblPivotalProjects);
            this.grpPivotal.Controls.Add(this.cboPivotalProjects);
            this.grpPivotal.Controls.Add(this.btnSyncSelected);
            this.grpPivotal.Controls.Add(this.label9);
            this.grpPivotal.Controls.Add(this.cboPivotalIteration);
            this.grpPivotal.Controls.Add(this.btnGetStories);
            this.grpPivotal.Location = new System.Drawing.Point(11, 152);
            this.grpPivotal.Name = "grpPivotal";
            this.grpPivotal.Size = new System.Drawing.Size(286, 237);
            this.grpPivotal.TabIndex = 21;
            this.grpPivotal.TabStop = false;
            // 
            // btnWizard
            // 
            this.btnWizard.Location = new System.Drawing.Point(6, 186);
            this.btnWizard.Name = "btnWizard";
            this.btnWizard.Size = new System.Drawing.Size(269, 26);
            this.btnWizard.TabIndex = 7;
            this.btnWizard.Text = "Sync Wizard";
            this.btnWizard.UseVisualStyleBackColor = true;
            this.btnWizard.Visible = false;
            this.btnWizard.Click += new System.EventHandler(this.btnWizard_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(6, 130);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(269, 26);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "ExportStoriesToFile";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Visible = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // lblPivotalProjects
            // 
            this.lblPivotalProjects.AutoSize = true;
            this.lblPivotalProjects.Location = new System.Drawing.Point(5, 13);
            this.lblPivotalProjects.Name = "lblPivotalProjects";
            this.lblPivotalProjects.Size = new System.Drawing.Size(45, 13);
            this.lblPivotalProjects.TabIndex = 31;
            this.lblPivotalProjects.Text = "Projects";
            // 
            // cboPivotalProjects
            // 
            this.cboPivotalProjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPivotalProjects.FormattingEnabled = true;
            this.cboPivotalProjects.Location = new System.Drawing.Point(8, 32);
            this.cboPivotalProjects.Name = "cboPivotalProjects";
            this.cboPivotalProjects.Size = new System.Drawing.Size(267, 21);
            this.cboPivotalProjects.TabIndex = 2;
            this.cboPivotalProjects.Validated += new System.EventHandler(this.Validate_ReadyForSync);
            // 
            // btnSyncSelected
            // 
            this.btnSyncSelected.Location = new System.Drawing.Point(6, 158);
            this.btnSyncSelected.Name = "btnSyncSelected";
            this.btnSyncSelected.Size = new System.Drawing.Size(269, 26);
            this.btnSyncSelected.TabIndex = 6;
            this.btnSyncSelected.Text = "Sync checked ones below to TFS";
            this.btnSyncSelected.UseVisualStyleBackColor = true;
            this.btnSyncSelected.Visible = false;
            this.btnSyncSelected.Click += new System.EventHandler(this.btnSyncSelected_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Iteration";
            // 
            // cboPivotalIteration
            // 
            this.cboPivotalIteration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPivotalIteration.FormattingEnabled = true;
            this.cboPivotalIteration.Location = new System.Drawing.Point(8, 74);
            this.cboPivotalIteration.Name = "cboPivotalIteration";
            this.cboPivotalIteration.Size = new System.Drawing.Size(267, 21);
            this.cboPivotalIteration.TabIndex = 3;
            this.cboPivotalIteration.Validated += new System.EventHandler(this.Validate_ReadyForSync);
            // 
            // btnGetStories
            // 
            this.btnGetStories.Location = new System.Drawing.Point(6, 101);
            this.btnGetStories.Name = "btnGetStories";
            this.btnGetStories.Size = new System.Drawing.Size(269, 26);
            this.btnGetStories.TabIndex = 4;
            this.btnGetStories.Text = "GetStories";
            this.btnGetStories.UseVisualStyleBackColor = true;
            this.btnGetStories.Click += new System.EventHandler(this.btnGetStories_Click);
            // 
            // tvwDetails
            // 
            this.tvwDetails.CheckBoxes = true;
            this.tvwDetails.ImageIndex = 0;
            this.tvwDetails.ImageList = this.imglst;
            this.tvwDetails.Indent = 10;
            this.tvwDetails.Location = new System.Drawing.Point(11, 437);
            this.tvwDetails.Name = "tvwDetails";
            this.tvwDetails.SelectedImageKey = "selected";
            this.tvwDetails.Size = new System.Drawing.Size(463, 320);
            this.tvwDetails.TabIndex = 20;
            this.tvwDetails.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvwDetails_MouseDown);
            // 
            // btnRapport
            // 
            this.btnRapport.Location = new System.Drawing.Point(10, 387);
            this.btnRapport.Name = "btnRapport";
            this.btnRapport.Size = new System.Drawing.Size(266, 23);
            this.btnRapport.TabIndex = 32;
            this.btnRapport.Text = "Generera förändringsrapport";
            this.btnRapport.UseVisualStyleBackColor = true;
            this.btnRapport.Click += new System.EventHandler(this.btnRapport_Click);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.btnRapport);
            this.pnlRight.Controls.Add(this.btnAddPivotalId);
            this.pnlRight.Controls.Add(this.tvwTFS);
            this.pnlRight.Controls.Add(this.grpTFSSettings);
            this.pnlRight.Controls.Add(this.grpTFS);
            this.pnlRight.Location = new System.Drawing.Point(607, 3);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(461, 759);
            this.pnlRight.TabIndex = 23;
            // 
            // btnAddPivotalId
            // 
            this.btnAddPivotalId.Location = new System.Drawing.Point(10, 413);
            this.btnAddPivotalId.Name = "btnAddPivotalId";
            this.btnAddPivotalId.Size = new System.Drawing.Size(266, 23);
            this.btnAddPivotalId.TabIndex = 33;
            this.btnAddPivotalId.Text = "Lägg på Pivotalid på Workitems som saknar det";
            this.btnAddPivotalId.UseVisualStyleBackColor = true;
            this.btnAddPivotalId.Visible = false;
            this.btnAddPivotalId.Click += new System.EventHandler(this.btnAddPivotalId_Click);
            // 
            // tvwTFS
            // 
            this.tvwTFS.AllowDrop = true;
            this.tvwTFS.CheckBoxes = true;
            this.tvwTFS.ImageIndex = 0;
            this.tvwTFS.ImageList = this.imglst;
            this.tvwTFS.Indent = 10;
            this.tvwTFS.Location = new System.Drawing.Point(1, 436);
            this.tvwTFS.Name = "tvwTFS";
            this.tvwTFS.SelectedImageKey = "selected";
            this.tvwTFS.Size = new System.Drawing.Size(455, 320);
            this.tvwTFS.TabIndex = 23;
            this.tvwTFS.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvwTFS_DragDrop);
            this.tvwTFS.DragOver += new System.Windows.Forms.DragEventHandler(this.tvwTFS_DragOver);
            this.tvwTFS.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvwTFS_MouseDown);
            // 
            // grpTFSSettings
            // 
            this.grpTFSSettings.Controls.Add(this.btnConnectToTFS);
            this.grpTFSSettings.Controls.Add(this.label12);
            this.grpTFSSettings.Controls.Add(this.txtDomain);
            this.grpTFSSettings.Controls.Add(this.label5);
            this.grpTFSSettings.Controls.Add(this.txtTFSServerURL);
            this.grpTFSSettings.Controls.Add(this.label3);
            this.grpTFSSettings.Controls.Add(this.label4);
            this.grpTFSSettings.Controls.Add(this.txtTFSPassword);
            this.grpTFSSettings.Controls.Add(this.txtTFSUsername);
            this.grpTFSSettings.Location = new System.Drawing.Point(3, 9);
            this.grpTFSSettings.Name = "grpTFSSettings";
            this.grpTFSSettings.Size = new System.Drawing.Size(295, 195);
            this.grpTFSSettings.TabIndex = 22;
            this.grpTFSSettings.TabStop = false;
            this.grpTFSSettings.Text = "TFS Settings";
            // 
            // btnConnectToTFS
            // 
            this.btnConnectToTFS.Location = new System.Drawing.Point(172, 168);
            this.btnConnectToTFS.Name = "btnConnectToTFS";
            this.btnConnectToTFS.Size = new System.Drawing.Size(108, 21);
            this.btnConnectToTFS.TabIndex = 31;
            this.btnConnectToTFS.Text = "Connect to TFS";
            this.btnConnectToTFS.UseVisualStyleBackColor = true;
            this.btnConnectToTFS.Click += new System.EventHandler(this.btnConnectToTFS_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 53);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 13);
            this.label12.TabIndex = 27;
            this.label12.Text = "Domain";
            // 
            // txtDomain
            // 
            this.txtDomain.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::PivotalTFSSync.Properties.Settings.Default, "TFS_Domain", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtDomain.Location = new System.Drawing.Point(13, 69);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(267, 20);
            this.txtDomain.TabIndex = 9;
            this.txtDomain.Text = global::PivotalTFSSync.Properties.Settings.Default.TFS_Domain;
            this.txtDomain.Validated += new System.EventHandler(this.Validate_ReadyForSync);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Server URL";
            // 
            // txtTFSServerURL
            // 
            this.txtTFSServerURL.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::PivotalTFSSync.Properties.Settings.Default, "TFS_Url", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtTFSServerURL.Location = new System.Drawing.Point(13, 28);
            this.txtTFSServerURL.Name = "txtTFSServerURL";
            this.txtTFSServerURL.Size = new System.Drawing.Size(267, 20);
            this.txtTFSServerURL.TabIndex = 8;
            this.txtTFSServerURL.Text = global::PivotalTFSSync.Properties.Settings.Default.TFS_Url;
            this.txtTFSServerURL.Validated += new System.EventHandler(this.Validate_ReadyForSync);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Username";
            // 
            // txtTFSPassword
            // 
            this.txtTFSPassword.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::PivotalTFSSync.Properties.Settings.Default, "TFS_Password", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtTFSPassword.Location = new System.Drawing.Point(13, 146);
            this.txtTFSPassword.Name = "txtTFSPassword";
            this.txtTFSPassword.PasswordChar = '*';
            this.txtTFSPassword.Size = new System.Drawing.Size(267, 20);
            this.txtTFSPassword.TabIndex = 11;
            this.txtTFSPassword.Text = global::PivotalTFSSync.Properties.Settings.Default.TFS_Password;
            this.txtTFSPassword.UseSystemPasswordChar = true;
            this.txtTFSPassword.Validated += new System.EventHandler(this.Validate_ReadyForSync);
            // 
            // txtTFSUsername
            // 
            this.txtTFSUsername.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::PivotalTFSSync.Properties.Settings.Default, "TFS_Username", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtTFSUsername.Location = new System.Drawing.Point(13, 111);
            this.txtTFSUsername.Name = "txtTFSUsername";
            this.txtTFSUsername.Size = new System.Drawing.Size(267, 20);
            this.txtTFSUsername.TabIndex = 10;
            this.txtTFSUsername.Text = global::PivotalTFSSync.Properties.Settings.Default.TFS_Username;
            this.txtTFSUsername.Validated += new System.EventHandler(this.Validate_ReadyForSync);
            // 
            // grpTFS
            // 
            this.grpTFS.Controls.Add(this.lblProjects);
            this.grpTFS.Controls.Add(this.label8);
            this.grpTFS.Controls.Add(this.cboTFSProjects);
            this.grpTFS.Controls.Add(this.cboTFSSubPath);
            this.grpTFS.Controls.Add(this.label7);
            this.grpTFS.Controls.Add(this.label10);
            this.grpTFS.Controls.Add(this.txtPriorityStep);
            this.grpTFS.Controls.Add(this.txtStartPriority);
            this.grpTFS.Controls.Add(this.label11);
            this.grpTFS.Controls.Add(this.cboTFSIterations);
            this.grpTFS.Location = new System.Drawing.Point(3, 204);
            this.grpTFS.Name = "grpTFS";
            this.grpTFS.Size = new System.Drawing.Size(295, 184);
            this.grpTFS.TabIndex = 21;
            this.grpTFS.TabStop = false;
            // 
            // lblProjects
            // 
            this.lblProjects.AutoSize = true;
            this.lblProjects.Location = new System.Drawing.Point(3, 10);
            this.lblProjects.Name = "lblProjects";
            this.lblProjects.Size = new System.Drawing.Size(45, 13);
            this.lblProjects.TabIndex = 29;
            this.lblProjects.Text = "Projects";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "Iteration sub path";
            // 
            // cboTFSProjects
            // 
            this.cboTFSProjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTFSProjects.FormattingEnabled = true;
            this.cboTFSProjects.Location = new System.Drawing.Point(6, 29);
            this.cboTFSProjects.Name = "cboTFSProjects";
            this.cboTFSProjects.Size = new System.Drawing.Size(267, 21);
            this.cboTFSProjects.TabIndex = 12;
            this.cboTFSProjects.SelectedIndexChanged += new System.EventHandler(this.cboProjects_SelectedIndexChanged);
            this.cboTFSProjects.Validated += new System.EventHandler(this.Validate_ReadyForSync);
            // 
            // cboTFSSubPath
            // 
            this.cboTFSSubPath.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTFSSubPath.FormattingEnabled = true;
            this.cboTFSSubPath.Location = new System.Drawing.Point(6, 112);
            this.cboTFSSubPath.Name = "cboTFSSubPath";
            this.cboTFSSubPath.Size = new System.Drawing.Size(267, 21);
            this.cboTFSSubPath.TabIndex = 14;
            this.cboTFSSubPath.DropDownClosed += new System.EventHandler(this.cboTFSSubPath_DropDownClosed);
            this.cboTFSSubPath.Enter += new System.EventHandler(this.cboTFSSubPath_Enter);
            this.cboTFSSubPath.Validated += new System.EventHandler(this.Validate_ReadyForSync);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(126, 138);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Priority Incremental Step";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 138);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "Start priority";
            // 
            // txtPriorityStep
            // 
            this.txtPriorityStep.Location = new System.Drawing.Point(129, 157);
            this.txtPriorityStep.Name = "txtPriorityStep";
            this.txtPriorityStep.Size = new System.Drawing.Size(49, 20);
            this.txtPriorityStep.TabIndex = 16;
            this.txtPriorityStep.Text = "10";
            this.txtPriorityStep.Validated += new System.EventHandler(this.Validate_ReadyForSync);
            // 
            // txtStartPriority
            // 
            this.txtStartPriority.Location = new System.Drawing.Point(6, 157);
            this.txtStartPriority.Name = "txtStartPriority";
            this.txtStartPriority.Size = new System.Drawing.Size(64, 20);
            this.txtStartPriority.TabIndex = 15;
            this.txtStartPriority.Text = "100";
            this.txtStartPriority.Validated += new System.EventHandler(this.Validate_ReadyForSync);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 53);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Iteration";
            // 
            // cboTFSIterations
            // 
            this.cboTFSIterations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTFSIterations.FormattingEnabled = true;
            this.cboTFSIterations.Location = new System.Drawing.Point(7, 72);
            this.cboTFSIterations.Name = "cboTFSIterations";
            this.cboTFSIterations.Size = new System.Drawing.Size(267, 21);
            this.cboTFSIterations.TabIndex = 13;
            this.cboTFSIterations.SelectionChangeCommitted += new System.EventHandler(this.cboDestinationIteration_SelectedIndexChanged);
            this.cboTFSIterations.Enter += new System.EventHandler(this.cboDestinationIteration_SelectedIndexChanged);
            this.cboTFSIterations.Validated += new System.EventHandler(this.Validate_ReadyForSync);
            // 
            // pnlSync
            // 
            this.pnlSync.Controls.Add(this.textBox1);
            this.pnlSync.Controls.Add(this.chkKopieraPiovtalTasks);
            this.pnlSync.Controls.Add(this.chklstDefaultTasks);
            this.pnlSync.Controls.Add(this.btnSyncNow);
            this.pnlSync.Controls.Add(this.btnSync);
            this.pnlSync.Controls.Add(this.picLeft);
            this.pnlSync.Controls.Add(this.picRight);
            this.pnlSync.Controls.Add(this.groupBox3);
            this.pnlSync.Controls.Add(this.groupBox1);
            this.pnlSync.Location = new System.Drawing.Point(489, 2);
            this.pnlSync.Name = "pnlSync";
            this.pnlSync.Size = new System.Drawing.Size(112, 716);
            this.pnlSync.TabIndex = 24;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(8, 449);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 24;
            // 
            // chkKopieraPiovtalTasks
            // 
            this.chkKopieraPiovtalTasks.AutoSize = true;
            this.chkKopieraPiovtalTasks.Checked = true;
            this.chkKopieraPiovtalTasks.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkKopieraPiovtalTasks.Location = new System.Drawing.Point(3, 316);
            this.chkKopieraPiovtalTasks.Name = "chkKopieraPiovtalTasks";
            this.chkKopieraPiovtalTasks.Size = new System.Drawing.Size(122, 17);
            this.chkKopieraPiovtalTasks.TabIndex = 22;
            this.chkKopieraPiovtalTasks.Text = "Kopiera Pivotaltasks";
            this.chkKopieraPiovtalTasks.UseVisualStyleBackColor = true;
            // 
            // chklstDefaultTasks
            // 
            this.chklstDefaultTasks.FormattingEnabled = true;
            this.chklstDefaultTasks.Items.AddRange(new object[] {
            "DOD"});
            this.chklstDefaultTasks.Location = new System.Drawing.Point(3, 343);
            this.chklstDefaultTasks.Name = "chklstDefaultTasks";
            this.chklstDefaultTasks.Size = new System.Drawing.Size(106, 94);
            this.chklstDefaultTasks.TabIndex = 21;
            this.chklstDefaultTasks.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.chklstDefaultTasks_MouseDoubleClick);
            // 
            // btnSyncNow
            // 
            this.btnSyncNow.Location = new System.Drawing.Point(8, 205);
            this.btnSyncNow.Name = "btnSyncNow";
            this.btnSyncNow.Size = new System.Drawing.Size(101, 23);
            this.btnSyncNow.TabIndex = 19;
            this.btnSyncNow.Text = "SyncNow!";
            this.btnSyncNow.UseVisualStyleBackColor = true;
            this.btnSyncNow.Click += new System.EventHandler(this.btnSyncNow_Click);
            // 
            // btnSync
            // 
            this.btnSync.Location = new System.Drawing.Point(8, 161);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(101, 23);
            this.btnSync.TabIndex = 18;
            this.btnSync.TabStop = false;
            this.btnSync.Text = "Start Sync";
            this.btnSync.UseVisualStyleBackColor = true;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // picLeft
            // 
            this.picLeft.Image = global::PivotalTFSSync.Properties.Resources.leftarrow;
            this.picLeft.Location = new System.Drawing.Point(10, 571);
            this.picLeft.Name = "picLeft";
            this.picLeft.Size = new System.Drawing.Size(88, 37);
            this.picLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLeft.TabIndex = 17;
            this.picLeft.TabStop = false;
            // 
            // picRight
            // 
            this.picRight.Image = global::PivotalTFSSync.Properties.Resources.rightArrow;
            this.picRight.Location = new System.Drawing.Point(10, 504);
            this.picRight.Name = "picRight";
            this.picRight.Size = new System.Drawing.Size(88, 37);
            this.picRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picRight.TabIndex = 16;
            this.picRight.TabStop = false;
            this.picRight.Click += new System.EventHandler(this.picRight_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cboSyncDirection);
            this.groupBox3.Location = new System.Drawing.Point(8, 94);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(101, 61);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sync direction";
            // 
            // cboSyncDirection
            // 
            this.cboSyncDirection.FormattingEnabled = true;
            this.cboSyncDirection.Items.AddRange(new object[] {
            "Pivotal -> TFS",
            "TFS -> Pivotal",
            "Pivotal <->TFS"});
            this.cboSyncDirection.Location = new System.Drawing.Point(4, 24);
            this.cboSyncDirection.Name = "cboSyncDirection";
            this.cboSyncDirection.Size = new System.Drawing.Size(84, 21);
            this.cboSyncDirection.TabIndex = 19;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.numSyncInterval);
            this.groupBox1.Location = new System.Drawing.Point(3, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(106, 72);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Syncronisation interval";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(57, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Sec.";
            // 
            // numSyncInterval
            // 
            this.numSyncInterval.Location = new System.Drawing.Point(5, 32);
            this.numSyncInterval.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.numSyncInterval.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numSyncInterval.Name = "numSyncInterval";
            this.numSyncInterval.Size = new System.Drawing.Size(46, 20);
            this.numSyncInterval.TabIndex = 0;
            this.numSyncInterval.TabStop = false;
            this.numSyncInterval.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // tmrErrorMessage
            // 
            this.tmrErrorMessage.Enabled = true;
            this.tmrErrorMessage.Interval = 10000;
            this.tmrErrorMessage.Tick += new System.EventHandler(this.tmrErrorMessage_Tick);
            // 
            // frmMain
            // 
            this.ClientSize = new System.Drawing.Size(1068, 834);
            this.Controls.Add(this.pnlSync);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlMessages);
            this.Name = "frmMain";
            this.Text = "PivotalTFS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnlMessages.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.grpPivotalSettings.ResumeLayout(false);
            this.grpPivotalSettings.PerformLayout();
            this.grpPivotal.ResumeLayout(false);
            this.grpPivotal.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.grpTFSSettings.ResumeLayout(false);
            this.grpTFSSettings.PerformLayout();
            this.grpTFS.ResumeLayout(false);
            this.grpTFS.PerformLayout();
            this.pnlSync.ResumeLayout(false);
            this.pnlSync.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRight)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSyncInterval)).EndInit();
            this.ResumeLayout(false);

        }

    

        #endregion

		  private Button btnSyncNow;
		  private Button btnRapport;
		  private CheckedListBox chklstDefaultTasks;
		  private CheckBox chkKopieraPiovtalTasks;
          private Button btnAddPivotalId;
          private TextBox textBox1;
    }
}