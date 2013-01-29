using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using PIVOTAL_API;
using PivotalTFS_GENERAL;
using TFS_API.TFS;
using Project = PivotalTFS_GENERAL.Project;

namespace PivotalTFSSync
{
	public partial class frmWizard : Form
	{
		private readonly IList<Panel> wizardsteps;
		private int currentStepIndex;

		public frmWizard()
		{
			InitializeComponent();
			wizardsteps = new List<Panel>
			              	{
			              		pnlStep_PivotalLogin,
			              		pnlStep_PivotalDetails,
			              		pnlStep_TFSLogins,
			              		pnlStep_TFSDetails,
			              		pnlStep_Summary
			              	};
			currentStepIndex = 0;
			InitializeAndShowStep(wizardsteps[currentStepIndex]);
		}

		private void pnlMain_Paint(object sender, PaintEventArgs e)
		{
		}

		private void btnNext_Click(object sender, EventArgs e)
		{
			MoveNext();
		}

		private void MoveNext()
		{
			if (currentStepIndex < wizardsteps.Count)
			{
				currentStepIndex++;
				InitializeAndShowStep(wizardsteps[currentStepIndex]);
			}
			else
			{
				SyncCheckedItems();
				MessageBox.Show("Done!", "Sync completed.");
			}
		}

		private void SyncCheckedItems()
		{
			Cursor = Cursors.WaitCursor;
			var currentPriority = int.Parse(txtStartPriority.Text);
			var priorityStep = int.Parse(txtPriorityStep.Text);
			ITFS tfs = new TFS(txtTFSServerURL.Text, txtDomain.Text, txtTFSUsername.Text,
			                   txtTFSPassword.Text);
			var projectname =
				((Microsoft.TeamFoundation.WorkItemTracking.Client.Project) cboTFSProjects.SelectedItem).Name;

			foreach (var story in from TreeNode node in tvwDetails.Nodes where node.Checked select (Story) node.Tag)
			{
				story.Priority = currentPriority;
				tfs.AddPivotalStoryToTFS(story, projectname, ((Node) cboTFSIterations.SelectedItem).Name,
				                         ((Node) cboTFSSubPath.SelectedItem).Name, null, true);
				currentPriority = currentPriority + priorityStep;
			}
			Cursor = Cursors.Arrow;
		}

		private void InitializeAndShowStep(Control wizardstep)
		{
			wizardstep.SetBounds(0, 0, pnlMain.Width, pnlMain.Height);
			HideAllSteps();
			btnNext.Text = "&Next";

			switch (wizardstep.Name)
			{
				case "pnlStep_PivotalLogin":
					{
						break;
					}
				case "pnlStep_PivotalDetails":
					{
						PopulatePivotalIterationsCombo();
						PopulatePivotalProjectsCombo();
						break;
					}
				case "pnlStep_TFSLogins":
					{
						break;
					}
				case "pnlStep_TFSDetails":
					{
						PopulateTFSIterationsCombo(cboTFSProjects.SelectedText);
						break;
					}
				case "pnlStep_Summary":
					{
						btnNext.Text = "&Finish";
						break;
					}
			}
			wizardstep.Show();
		}

		private void PopulateTFSIterationsCombo(string projectname)
		{
			try
			{
				ITFS tfs = new TFS_API.TFS.TFS(txtTFSServerURL.Text, txtDomain.Text, txtTFSUsername.Text,
				                               txtTFSPassword.Text);
				cboTFSIterations.DataSource = tfs.GetIterationPaths(projectname);
				cboTFSIterations.DisplayMember = "Name";
			}
			catch (Exception exception)
			{
				//LogError(exception);
			}
		}

		private void PopulatePivotalProjectsCombo()
		{
			IPivotal p = new Pivotal(txtStep_PivotalUsername.Text, txtStep_PiovtalPassword.Text);
			cboPivotalProjects.DataSource = p.GetAllProjects();
			cboPivotalProjects.DisplayMember = "Name";
		}

		private void PopulatePivotalIterationsCombo()
		{
			cboPivotalIteration.Items.Clear();
			cboPivotalIteration.Items.Add(Pivotal.IterationVersion.All);
			cboPivotalIteration.Items.Add(Pivotal.IterationVersion.Backlog);
			cboPivotalIteration.Items.Add(Pivotal.IterationVersion.Current);
			cboPivotalIteration.Items.Add(Pivotal.IterationVersion.Done);
		}

		private void HideAllSteps()
		{
			foreach (var step in wizardsteps)
			{
				step.Hide();
			}
		}

		private void cboPivotalIteration_DropDownClosed(object sender, EventArgs e)
		{
			var stories = GetPivotalStories();
			PopulateTreeview(stories);
		}

		private Story[] GetPivotalStories()
		{
			Cursor = Cursors.WaitCursor;
			IPivotal p = new Pivotal(txtStep_PivotalUsername.Text, txtStep_PiovtalPassword.Text);
			try
			{
				var iterations = p.GetIteration((Project) cboPivotalProjects.SelectedItem,
				                                ((Pivotal.IterationVersion) cboPivotalIteration.SelectedItem));
				return iterations.First().Stories.stories;
			}
			catch (Exception ex)
			{
				//LogError(ex);
			}
			Cursor = Cursors.Arrow;
			return new Story[] {};
		}

		private void PopulateTreeview(IEnumerable<Story> stories)
		{
			tvwDetails.Nodes.Clear();

			foreach (var story in stories)
			{
				var key = story.Id.ToString();
				var node = tvwDetails.Nodes.Add(key, story.Name, story.Type);
				node.Tag = story;

				if (story.Description.Trim().Length > 0)
				{
					node.Nodes.Add(string.Concat(key, "-2"), story.Description.Trim(), "empty");
				}
			}
		}

		private void btnPrev_Click(object sender, EventArgs e)
		{
			MovePrevious();
		}

		private void MovePrevious()
		{
			if (currentStepIndex > 0)
			{
				currentStepIndex--;
				InitializeAndShowStep(wizardsteps[currentStepIndex]);
			}
		}
	}
}