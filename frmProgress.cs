using System.Windows.Forms;

namespace PivotalTFSSync
{
	public partial class frmProgress : Form
	{
		public frmProgress()
		{
			InitializeComponent();
		}

		public void SetMessage(string message)
		{
			lblMessage.Text = message;
			Application.DoEvents();
		}
	}
}