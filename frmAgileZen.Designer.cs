namespace PivotalTFSSync
{
	partial class frmAgileZen
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

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
			this.button1 = new System.Windows.Forms.Button();
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
			this.grpTFSSettings.SuspendLayout();
			this.grpTFS.SuspendLayout();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(33, 247);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
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
			this.grpTFSSettings.Location = new System.Drawing.Point(239, 22);
			this.grpTFSSettings.Name = "grpTFSSettings";
			this.grpTFSSettings.Size = new System.Drawing.Size(295, 195);
			this.grpTFSSettings.TabIndex = 23;
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
			// 
			// txtTFSUsername
			// 
			this.txtTFSUsername.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::PivotalTFSSync.Properties.Settings.Default, "TFS_Username", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.txtTFSUsername.Location = new System.Drawing.Point(13, 111);
			this.txtTFSUsername.Name = "txtTFSUsername";
			this.txtTFSUsername.Size = new System.Drawing.Size(267, 20);
			this.txtTFSUsername.TabIndex = 10;
			this.txtTFSUsername.Text = global::PivotalTFSSync.Properties.Settings.Default.TFS_Username;
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
			this.grpTFS.Location = new System.Drawing.Point(239, 223);
			this.grpTFS.Name = "grpTFS";
			this.grpTFS.Size = new System.Drawing.Size(295, 184);
			this.grpTFS.TabIndex = 24;
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
			// 
			// cboTFSSubPath
			// 
			this.cboTFSSubPath.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboTFSSubPath.FormattingEnabled = true;
			this.cboTFSSubPath.Location = new System.Drawing.Point(6, 112);
			this.cboTFSSubPath.Name = "cboTFSSubPath";
			this.cboTFSSubPath.Size = new System.Drawing.Size(267, 21);
			this.cboTFSSubPath.TabIndex = 14;
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
			// 
			// txtStartPriority
			// 
			this.txtStartPriority.Location = new System.Drawing.Point(6, 157);
			this.txtStartPriority.Name = "txtStartPriority";
			this.txtStartPriority.Size = new System.Drawing.Size(64, 20);
			this.txtStartPriority.TabIndex = 15;
			this.txtStartPriority.Text = "100";
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
			// 
			// frmAgileZen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(558, 553);
			this.Controls.Add(this.grpTFS);
			this.Controls.Add(this.grpTFSSettings);
			this.Controls.Add(this.button1);
			this.Name = "frmAgileZen";
			this.Text = "frmAgileZen";
			this.grpTFSSettings.ResumeLayout(false);
			this.grpTFSSettings.PerformLayout();
			this.grpTFS.ResumeLayout(false);
			this.grpTFS.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.GroupBox grpTFSSettings;
		private System.Windows.Forms.Button btnConnectToTFS;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox txtDomain;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtTFSServerURL;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtTFSPassword;
		private System.Windows.Forms.TextBox txtTFSUsername;
		private System.Windows.Forms.GroupBox grpTFS;
		private System.Windows.Forms.Label lblProjects;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ComboBox cboTFSProjects;
		private System.Windows.Forms.ComboBox cboTFSSubPath;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtPriorityStep;
		private System.Windows.Forms.TextBox txtStartPriority;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.ComboBox cboTFSIterations;
	}
}