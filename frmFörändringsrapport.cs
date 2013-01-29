using System;
using System.Windows.Forms;

namespace PivotalTFSSync
{
	public partial class frmFörändringsrapport : Form
	{
		public frmFörändringsrapport()
		{
			InitializeComponent();
		}

		public DateTime fromDate { get; set; }
		public DateTime toDate { get; set; }

		private void btnGenerera_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			fromDate = dteFrom.Value;
			toDate = dteTo.Value;
		}
	}
}