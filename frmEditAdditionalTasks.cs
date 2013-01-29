using System;
using System.Windows.Forms;

namespace PivotalTFSSync
{
	public partial class frmEditAdditionalTasks : Form
	{
		public frmEditAdditionalTasks(CheckedListBox.ObjectCollection items)
		{
			InitializeComponent();
			lstItems.Items.AddRange(items);
			lstItems.Refresh();
		}

		public ListBox.ObjectCollection AdditionalTasks { get; set; }

		private void btnAdd_Click(object sender, EventArgs e)
		{
			if (txtTask.Text.Length <= 0)
				return;

			lstItems.Items.Add(txtTask.Text);
			txtTask.Text = string.Empty;
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			while (lstItems.SelectedItems.Count > 0)
				lstItems.Items.Remove(lstItems.SelectedItem);
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			ReturnResults();
		}

		private void ReturnResults()
		{
			AdditionalTasks = lstItems.Items;
			Hide();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			ReturnResults();
		}
	}
}