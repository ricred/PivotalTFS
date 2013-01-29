namespace PivotalTFSSync
{
	partial class frmFörändringsrapport
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
			this.dteFrom = new System.Windows.Forms.DateTimePicker();
			this.dteTo = new System.Windows.Forms.DateTimePicker();
			this.btnGenerera = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// dteFrom
			// 
			this.dteFrom.Location = new System.Drawing.Point(12, 23);
			this.dteFrom.Name = "dteFrom";
			this.dteFrom.Size = new System.Drawing.Size(200, 20);
			this.dteFrom.TabIndex = 0;
			// 
			// dteTo
			// 
			this.dteTo.Location = new System.Drawing.Point(12, 80);
			this.dteTo.Name = "dteTo";
			this.dteTo.Size = new System.Drawing.Size(200, 20);
			this.dteTo.TabIndex = 1;
			// 
			// btnGenerera
			// 
			this.btnGenerera.Location = new System.Drawing.Point(12, 106);
			this.btnGenerera.Name = "btnGenerera";
			this.btnGenerera.Size = new System.Drawing.Size(200, 23);
			this.btnGenerera.TabIndex = 2;
			this.btnGenerera.Text = "Generera";
			this.btnGenerera.UseVisualStyleBackColor = true;
			this.btnGenerera.Click += new System.EventHandler(this.btnGenerera_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 4);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(33, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "F.o.m";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 61);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(34, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "T.o.m";
			// 
			// frmFörändringsrapport
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(220, 136);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnGenerera);
			this.Controls.Add(this.dteTo);
			this.Controls.Add(this.dteFrom);
			this.Name = "frmFörändringsrapport";
			this.Text = "frmFörändringsrapport";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DateTimePicker dteFrom;
		private System.Windows.Forms.DateTimePicker dteTo;
		private System.Windows.Forms.Button btnGenerera;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
	}
}