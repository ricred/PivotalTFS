namespace PivotalTFSSync
{
	partial class frmWizard
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
			this.pnlMain = new System.Windows.Forms.Panel();
			this.pnlStep_Summary = new System.Windows.Forms.Panel();
			this.lblSummary = new System.Windows.Forms.Label();
			this.pnlStep_TFSLogins = new System.Windows.Forms.Panel();
			this.label12 = new System.Windows.Forms.Label();
			this.txtDomain = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtTFSServerURL = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.txtTFSPassword = new System.Windows.Forms.TextBox();
			this.txtTFSUsername = new System.Windows.Forms.TextBox();
			this.pnlStep_PivotalDetails = new System.Windows.Forms.Panel();
			this.pnlPivotalTreeDetails = new System.Windows.Forms.Panel();
			this.tvwDetails = new System.Windows.Forms.TreeView();
			this.pnlPivotalSource = new System.Windows.Forms.Panel();
			this.lblPivotalProjects = new System.Windows.Forms.Label();
			this.cboPivotalProjects = new System.Windows.Forms.ComboBox();
			this.label9 = new System.Windows.Forms.Label();
			this.cboPivotalIteration = new System.Windows.Forms.ComboBox();
			this.pnlStep_PivotalLogin = new System.Windows.Forms.Panel();
			this.pnlStep_TFSDetails = new System.Windows.Forms.Panel();
			this.lblProjects = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.cboTFSProjects = new System.Windows.Forms.ComboBox();
			this.cboTFSSubPath = new System.Windows.Forms.ComboBox();
			this.label13 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.txtPriorityStep = new System.Windows.Forms.TextBox();
			this.txtStartPriority = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.cboTFSIterations = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.txtStep_PiovtalPassword = new System.Windows.Forms.TextBox();
			this.txtStep_PivotalUsername = new System.Windows.Forms.TextBox();
			this.pnlButtons = new System.Windows.Forms.Panel();
			this.btnPrev = new System.Windows.Forms.Button();
			this.btnNext = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txtPivotalPassword = new System.Windows.Forms.TextBox();
			this.txtPivotalUsername = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.pnlMain.SuspendLayout();
			this.pnlStep_Summary.SuspendLayout();
			this.pnlStep_TFSLogins.SuspendLayout();
			this.pnlStep_PivotalDetails.SuspendLayout();
			this.pnlPivotalTreeDetails.SuspendLayout();
			this.pnlPivotalSource.SuspendLayout();
			this.pnlStep_PivotalLogin.SuspendLayout();
			this.pnlStep_TFSDetails.SuspendLayout();
			this.pnlButtons.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlMain
			// 
			this.pnlMain.Controls.Add(this.pnlStep_Summary);
			this.pnlMain.Controls.Add(this.pnlStep_TFSLogins);
			this.pnlMain.Controls.Add(this.pnlStep_PivotalDetails);
			this.pnlMain.Controls.Add(this.pnlStep_PivotalLogin);
			this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlMain.Location = new System.Drawing.Point(0, 0);
			this.pnlMain.Name = "pnlMain";
			this.pnlMain.Size = new System.Drawing.Size(618, 572);
			this.pnlMain.TabIndex = 0;
			this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
			// 
			// pnlStep_Summary
			// 
			this.pnlStep_Summary.Controls.Add(this.lblSummary);
			this.pnlStep_Summary.Location = new System.Drawing.Point(541, 299);
			this.pnlStep_Summary.Name = "pnlStep_Summary";
			this.pnlStep_Summary.Size = new System.Drawing.Size(200, 100);
			this.pnlStep_Summary.TabIndex = 3;
			// 
			// lblSummary
			// 
			this.lblSummary.AutoSize = true;
			this.lblSummary.Location = new System.Drawing.Point(29, 35);
			this.lblSummary.Name = "lblSummary";
			this.lblSummary.Size = new System.Drawing.Size(78, 13);
			this.lblSummary.TabIndex = 0;
			this.lblSummary.Text = "Ready to sync.";
			// 
			// pnlStep_TFSLogins
			// 
			this.pnlStep_TFSLogins.Controls.Add(this.label12);
			this.pnlStep_TFSLogins.Controls.Add(this.txtDomain);
			this.pnlStep_TFSLogins.Controls.Add(this.label7);
			this.pnlStep_TFSLogins.Controls.Add(this.txtTFSServerURL);
			this.pnlStep_TFSLogins.Controls.Add(this.label8);
			this.pnlStep_TFSLogins.Controls.Add(this.label10);
			this.pnlStep_TFSLogins.Controls.Add(this.txtTFSPassword);
			this.pnlStep_TFSLogins.Controls.Add(this.txtTFSUsername);
			this.pnlStep_TFSLogins.Location = new System.Drawing.Point(328, 3);
			this.pnlStep_TFSLogins.Name = "pnlStep_TFSLogins";
			this.pnlStep_TFSLogins.Size = new System.Drawing.Size(287, 226);
			this.pnlStep_TFSLogins.TabIndex = 2;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(3, 75);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(43, 13);
			this.label12.TabIndex = 27;
			this.label12.Text = "Domain";
			// 
			// txtDomain
			// 
			this.txtDomain.Location = new System.Drawing.Point(6, 91);
			this.txtDomain.Name = "txtDomain";
			this.txtDomain.Size = new System.Drawing.Size(267, 20);
			this.txtDomain.TabIndex = 26;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(3, 34);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(63, 13);
			this.label7.TabIndex = 25;
			this.label7.Text = "Server URL";
			// 
			// txtTFSServerURL
			// 
			this.txtTFSServerURL.Location = new System.Drawing.Point(6, 50);
			this.txtTFSServerURL.Name = "txtTFSServerURL";
			this.txtTFSServerURL.Size = new System.Drawing.Size(267, 20);
			this.txtTFSServerURL.TabIndex = 24;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(1, 154);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(53, 13);
			this.label8.TabIndex = 23;
			this.label8.Text = "Password";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(1, 117);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(55, 13);
			this.label10.TabIndex = 22;
			this.label10.Text = "Username";
			// 
			// txtTFSPassword
			// 
			this.txtTFSPassword.Location = new System.Drawing.Point(4, 168);
			this.txtTFSPassword.Name = "txtTFSPassword";
			this.txtTFSPassword.PasswordChar = '*';
			this.txtTFSPassword.Size = new System.Drawing.Size(267, 20);
			this.txtTFSPassword.TabIndex = 21;
			this.txtTFSPassword.UseSystemPasswordChar = true;
			// 
			// txtTFSUsername
			// 
			this.txtTFSUsername.Location = new System.Drawing.Point(4, 133);
			this.txtTFSUsername.Name = "txtTFSUsername";
			this.txtTFSUsername.Size = new System.Drawing.Size(267, 20);
			this.txtTFSUsername.TabIndex = 20;
			// 
			// pnlStep_PivotalDetails
			// 
			this.pnlStep_PivotalDetails.Controls.Add(this.pnlPivotalTreeDetails);
			this.pnlStep_PivotalDetails.Controls.Add(this.pnlPivotalSource);
			this.pnlStep_PivotalDetails.Location = new System.Drawing.Point(28, 231);
			this.pnlStep_PivotalDetails.Name = "pnlStep_PivotalDetails";
			this.pnlStep_PivotalDetails.Size = new System.Drawing.Size(457, 290);
			this.pnlStep_PivotalDetails.TabIndex = 1;
			// 
			// pnlPivotalTreeDetails
			// 
			this.pnlPivotalTreeDetails.Controls.Add(this.tvwDetails);
			this.pnlPivotalTreeDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlPivotalTreeDetails.Location = new System.Drawing.Point(0, 95);
			this.pnlPivotalTreeDetails.Name = "pnlPivotalTreeDetails";
			this.pnlPivotalTreeDetails.Size = new System.Drawing.Size(457, 195);
			this.pnlPivotalTreeDetails.TabIndex = 44;
			// 
			// tvwDetails
			// 
			this.tvwDetails.CheckBoxes = true;
			this.tvwDetails.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvwDetails.Indent = 10;
			this.tvwDetails.Location = new System.Drawing.Point(0, 0);
			this.tvwDetails.Name = "tvwDetails";
			this.tvwDetails.SelectedImageKey = "selected";
			this.tvwDetails.Size = new System.Drawing.Size(457, 195);
			this.tvwDetails.TabIndex = 41;
			// 
			// pnlPivotalSource
			// 
			this.pnlPivotalSource.Controls.Add(this.lblPivotalProjects);
			this.pnlPivotalSource.Controls.Add(this.cboPivotalProjects);
			this.pnlPivotalSource.Controls.Add(this.label9);
			this.pnlPivotalSource.Controls.Add(this.cboPivotalIteration);
			this.pnlPivotalSource.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlPivotalSource.Location = new System.Drawing.Point(0, 0);
			this.pnlPivotalSource.Name = "pnlPivotalSource";
			this.pnlPivotalSource.Size = new System.Drawing.Size(457, 100);
			this.pnlPivotalSource.TabIndex = 42;
			// 
			// lblPivotalProjects
			// 
			this.lblPivotalProjects.AutoSize = true;
			this.lblPivotalProjects.Location = new System.Drawing.Point(11, 7);
			this.lblPivotalProjects.Name = "lblPivotalProjects";
			this.lblPivotalProjects.Size = new System.Drawing.Size(45, 13);
			this.lblPivotalProjects.TabIndex = 43;
			this.lblPivotalProjects.Text = "Projects";
			// 
			// cboPivotalProjects
			// 
			this.cboPivotalProjects.FormattingEnabled = true;
			this.cboPivotalProjects.Location = new System.Drawing.Point(14, 26);
			this.cboPivotalProjects.Name = "cboPivotalProjects";
			this.cboPivotalProjects.Size = new System.Drawing.Size(267, 21);
			this.cboPivotalProjects.TabIndex = 42;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(11, 52);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(45, 13);
			this.label9.TabIndex = 41;
			this.label9.Text = "Iteration";
			// 
			// cboPivotalIteration
			// 
			this.cboPivotalIteration.FormattingEnabled = true;
			this.cboPivotalIteration.Location = new System.Drawing.Point(14, 68);
			this.cboPivotalIteration.Name = "cboPivotalIteration";
			this.cboPivotalIteration.Size = new System.Drawing.Size(267, 21);
			this.cboPivotalIteration.TabIndex = 40;
			this.cboPivotalIteration.DropDownClosed += new System.EventHandler(this.cboPivotalIteration_DropDownClosed);
			// 
			// pnlStep_PivotalLogin
			// 
			this.pnlStep_PivotalLogin.Controls.Add(this.pnlStep_TFSDetails);
			this.pnlStep_PivotalLogin.Controls.Add(this.label5);
			this.pnlStep_PivotalLogin.Controls.Add(this.label6);
			this.pnlStep_PivotalLogin.Controls.Add(this.txtStep_PiovtalPassword);
			this.pnlStep_PivotalLogin.Controls.Add(this.txtStep_PivotalUsername);
			this.pnlStep_PivotalLogin.Location = new System.Drawing.Point(28, 23);
			this.pnlStep_PivotalLogin.Name = "pnlStep_PivotalLogin";
			this.pnlStep_PivotalLogin.Size = new System.Drawing.Size(457, 202);
			this.pnlStep_PivotalLogin.TabIndex = 0;
			// 
			// pnlStep_TFSDetails
			// 
			this.pnlStep_TFSDetails.Controls.Add(this.lblProjects);
			this.pnlStep_TFSDetails.Controls.Add(this.label11);
			this.pnlStep_TFSDetails.Controls.Add(this.cboTFSProjects);
			this.pnlStep_TFSDetails.Controls.Add(this.cboTFSSubPath);
			this.pnlStep_TFSDetails.Controls.Add(this.label13);
			this.pnlStep_TFSDetails.Controls.Add(this.label14);
			this.pnlStep_TFSDetails.Controls.Add(this.txtPriorityStep);
			this.pnlStep_TFSDetails.Controls.Add(this.txtStartPriority);
			this.pnlStep_TFSDetails.Controls.Add(this.label15);
			this.pnlStep_TFSDetails.Controls.Add(this.cboTFSIterations);
			this.pnlStep_TFSDetails.Location = new System.Drawing.Point(136, 150);
			this.pnlStep_TFSDetails.Name = "pnlStep_TFSDetails";
			this.pnlStep_TFSDetails.Size = new System.Drawing.Size(336, 261);
			this.pnlStep_TFSDetails.TabIndex = 3;
			// 
			// lblProjects
			// 
			this.lblProjects.AutoSize = true;
			this.lblProjects.Location = new System.Drawing.Point(15, 14);
			this.lblProjects.Name = "lblProjects";
			this.lblProjects.Size = new System.Drawing.Size(45, 13);
			this.lblProjects.TabIndex = 39;
			this.lblProjects.Text = "Projects";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(15, 100);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(89, 13);
			this.label11.TabIndex = 37;
			this.label11.Text = "Iteration sub path";
			// 
			// cboTFSProjects
			// 
			this.cboTFSProjects.FormattingEnabled = true;
			this.cboTFSProjects.Location = new System.Drawing.Point(18, 33);
			this.cboTFSProjects.Name = "cboTFSProjects";
			this.cboTFSProjects.Size = new System.Drawing.Size(267, 21);
			this.cboTFSProjects.TabIndex = 38;
			// 
			// cboTFSSubPath
			// 
			this.cboTFSSubPath.FormattingEnabled = true;
			this.cboTFSSubPath.Location = new System.Drawing.Point(18, 116);
			this.cboTFSSubPath.Name = "cboTFSSubPath";
			this.cboTFSSubPath.Size = new System.Drawing.Size(267, 21);
			this.cboTFSSubPath.TabIndex = 36;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(138, 142);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(121, 13);
			this.label13.TabIndex = 35;
			this.label13.Text = "Priority Incremental Step";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(15, 142);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(62, 13);
			this.label14.TabIndex = 34;
			this.label14.Text = "Start priority";
			// 
			// txtPriorityStep
			// 
			this.txtPriorityStep.Location = new System.Drawing.Point(141, 161);
			this.txtPriorityStep.Name = "txtPriorityStep";
			this.txtPriorityStep.Size = new System.Drawing.Size(49, 20);
			this.txtPriorityStep.TabIndex = 33;
			this.txtPriorityStep.Text = "10";
			// 
			// txtStartPriority
			// 
			this.txtStartPriority.Location = new System.Drawing.Point(18, 161);
			this.txtStartPriority.Name = "txtStartPriority";
			this.txtStartPriority.Size = new System.Drawing.Size(64, 20);
			this.txtStartPriority.TabIndex = 32;
			this.txtStartPriority.Text = "100";
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(15, 57);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(45, 13);
			this.label15.TabIndex = 31;
			this.label15.Text = "Iteration";
			// 
			// cboTFSIterations
			// 
			this.cboTFSIterations.FormattingEnabled = true;
			this.cboTFSIterations.Location = new System.Drawing.Point(18, 76);
			this.cboTFSIterations.Name = "cboTFSIterations";
			this.cboTFSIterations.Size = new System.Drawing.Size(267, 21);
			this.cboTFSIterations.TabIndex = 30;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(3, 53);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(53, 13);
			this.label5.TabIndex = 19;
			this.label5.Text = "Password";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(3, 10);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(55, 13);
			this.label6.TabIndex = 18;
			this.label6.Text = "Username";
			// 
			// txtStep_PiovtalPassword
			// 
			this.txtStep_PiovtalPassword.Location = new System.Drawing.Point(6, 69);
			this.txtStep_PiovtalPassword.Name = "txtStep_PiovtalPassword";
			this.txtStep_PiovtalPassword.PasswordChar = '*';
			this.txtStep_PiovtalPassword.Size = new System.Drawing.Size(267, 20);
			this.txtStep_PiovtalPassword.TabIndex = 17;
			this.txtStep_PiovtalPassword.UseSystemPasswordChar = true;
			// 
			// txtStep_PivotalUsername
			// 
			this.txtStep_PivotalUsername.Location = new System.Drawing.Point(6, 26);
			this.txtStep_PivotalUsername.Name = "txtStep_PivotalUsername";
			this.txtStep_PivotalUsername.Size = new System.Drawing.Size(267, 20);
			this.txtStep_PivotalUsername.TabIndex = 16;
			// 
			// pnlButtons
			// 
			this.pnlButtons.Controls.Add(this.btnPrev);
			this.pnlButtons.Controls.Add(this.btnNext);
			this.pnlButtons.Controls.Add(this.btnCancel);
			this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlButtons.Location = new System.Drawing.Point(0, 527);
			this.pnlButtons.Name = "pnlButtons";
			this.pnlButtons.Size = new System.Drawing.Size(618, 45);
			this.pnlButtons.TabIndex = 1;
			// 
			// btnPrev
			// 
			this.btnPrev.Location = new System.Drawing.Point(344, 10);
			this.btnPrev.Name = "btnPrev";
			this.btnPrev.Size = new System.Drawing.Size(75, 23);
			this.btnPrev.TabIndex = 2;
			this.btnPrev.Text = "&Prev";
			this.btnPrev.UseVisualStyleBackColor = true;
			this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
			// 
			// btnNext
			// 
			this.btnNext.Location = new System.Drawing.Point(425, 10);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(75, 23);
			this.btnNext.TabIndex = 1;
			this.btnNext.Text = "&Next";
			this.btnNext.UseVisualStyleBackColor = true;
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(531, 10);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 0;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(8, 46);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 13);
			this.label2.TabIndex = 15;
			this.label2.Text = "Password";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(55, 13);
			this.label1.TabIndex = 14;
			this.label1.Text = "Username";
			// 
			// txtPivotalPassword
			// 
			this.txtPivotalPassword.Location = new System.Drawing.Point(11, 62);
			this.txtPivotalPassword.Name = "txtPivotalPassword";
			this.txtPivotalPassword.PasswordChar = '*';
			this.txtPivotalPassword.Size = new System.Drawing.Size(267, 20);
			this.txtPivotalPassword.TabIndex = 13;
			this.txtPivotalPassword.UseSystemPasswordChar = true;
			// 
			// txtPivotalUsername
			// 
			this.txtPivotalUsername.Location = new System.Drawing.Point(11, 19);
			this.txtPivotalUsername.Name = "txtPivotalUsername";
			this.txtPivotalUsername.Size = new System.Drawing.Size(267, 20);
			this.txtPivotalUsername.TabIndex = 12;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(8, 46);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(53, 13);
			this.label3.TabIndex = 15;
			this.label3.Text = "Password";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(8, 3);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(55, 13);
			this.label4.TabIndex = 14;
			this.label4.Text = "Username";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(11, 62);
			this.textBox1.Name = "textBox1";
			this.textBox1.PasswordChar = '*';
			this.textBox1.Size = new System.Drawing.Size(267, 20);
			this.textBox1.TabIndex = 13;
			this.textBox1.UseSystemPasswordChar = true;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(11, 19);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(267, 20);
			this.textBox2.TabIndex = 12;
			// 
			// frmWizard
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(618, 572);
			this.Controls.Add(this.pnlButtons);
			this.Controls.Add(this.pnlMain);
			this.Name = "frmWizard";
			this.Text = "frmWizard";
			this.pnlMain.ResumeLayout(false);
			this.pnlStep_Summary.ResumeLayout(false);
			this.pnlStep_Summary.PerformLayout();
			this.pnlStep_TFSLogins.ResumeLayout(false);
			this.pnlStep_TFSLogins.PerformLayout();
			this.pnlStep_PivotalDetails.ResumeLayout(false);
			this.pnlPivotalTreeDetails.ResumeLayout(false);
			this.pnlPivotalSource.ResumeLayout(false);
			this.pnlPivotalSource.PerformLayout();
			this.pnlStep_PivotalLogin.ResumeLayout(false);
			this.pnlStep_PivotalLogin.PerformLayout();
			this.pnlStep_TFSDetails.ResumeLayout(false);
			this.pnlStep_TFSDetails.PerformLayout();
			this.pnlButtons.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlMain;
		private System.Windows.Forms.Panel pnlButtons;
		private System.Windows.Forms.Button btnPrev;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Panel pnlStep_PivotalLogin;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtPivotalPassword;
		private System.Windows.Forms.TextBox txtPivotalUsername;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtStep_PiovtalPassword;
		private System.Windows.Forms.TextBox txtStep_PivotalUsername;
		private System.Windows.Forms.Panel pnlStep_PivotalDetails;
		private System.Windows.Forms.Panel pnlPivotalTreeDetails;
		private System.Windows.Forms.TreeView tvwDetails;
		private System.Windows.Forms.Panel pnlPivotalSource;
		private System.Windows.Forms.Label lblPivotalProjects;
		private System.Windows.Forms.ComboBox cboPivotalProjects;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ComboBox cboPivotalIteration;
		private System.Windows.Forms.Panel pnlStep_TFSLogins;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox txtDomain;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtTFSServerURL;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtTFSPassword;
		private System.Windows.Forms.TextBox txtTFSUsername;
		private System.Windows.Forms.Panel pnlStep_TFSDetails;
		private System.Windows.Forms.Label lblProjects;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.ComboBox cboTFSProjects;
		private System.Windows.Forms.ComboBox cboTFSSubPath;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox txtPriorityStep;
		private System.Windows.Forms.TextBox txtStartPriority;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.ComboBox cboTFSIterations;
		private System.Windows.Forms.Panel pnlStep_Summary;
		private System.Windows.Forms.Label lblSummary;
	}
}