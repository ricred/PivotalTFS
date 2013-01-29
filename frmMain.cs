using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Browser;
using System.Windows.Forms;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using PIVOTAL_API;
using PivotalTFSSync.Properties;
using PivotalTFSSync.Serializers;
using PivotalTFS_GENERAL;
using TFS_API.TFS;
using Project = PivotalTFS_GENERAL.Project;

namespace PivotalTFSSync
{
	public partial class frmMain : Form
	{
		private const string PIVOTALID = "PIVOTALID:";
		private ITFS TFS;

		public frmMain()
		{
			InitializeComponent();
			Settings.Default.SettingsLoaded += Settings_SettingsLoaded;
		}

		private void btnConnectToPivotal_Click(object sender, EventArgs e)
		{
			ConnectToPivotalAndPopulateData();
		}

		private void btnConnectToTFS_Click(object sender, EventArgs e)
		{
			ConnectToTFS();
			LoadTFSProjects();
		}

		private void btnExport_Click(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;
			try
			{
				var enumerable = pivotal.GetIteration(
					(Project) cboPivotalProjects.SelectedItem,
					(Pivotal.IterationVersion) cboPivotalIteration.SelectedItem);
				using (var stream = File.OpenWrite(@"c:\stories.csv"))
				{
					var serializer2 = new StorySerializer();
					serializer2.RowDelimiter = '\n';
					serializer2.ColumnDelimiter = '\t';
					serializer2.EncapsulateAllFieldsWith = '"';
					var serializer = serializer2;
					foreach (var iteration in enumerable)
					{
						WriteStoriesToStream(iteration, iteration.Stories.stories, serializer, stream);
					}
					if (((Pivotal.IterationVersion) cboPivotalIteration.SelectedItem) ==
					    Pivotal.IterationVersion.All)
					{
						var storiesByFilter =
							pivotal.GetStoriesByFilter(
								(Project) cboPivotalProjects.SelectedItem, "state:unscheduled");
						WriteStoriesToStream(null, storiesByFilter, serializer, stream);
					}
					stream.Close();
				}
			}
			catch (Exception exception)
			{
				LogError(exception);
			}
			Cursor = Cursors.Arrow;
		}

		private void btnGetStories_Click(object sender, EventArgs e)
		{
			var pivotalStories = GetPivotalStories();
			PopulateTreeview(pivotalStories);
		}

		private void btnSync_Click(object sender, EventArgs e)
		{
			if (numSyncInterval.Value <= 0M)
				return;
			tmrSync.Interval = decimal.ToInt32(numSyncInterval.Value)*0x3e8;
			ToggleSyncText();
			tmrSync.Enabled = !tmrSync.Enabled;
		}

		private void btnSyncSelected_Click(object sender, EventArgs e)
		{
			SyncCheckedItems();
			PopulateTFSWorkItemList();
		}

		private void btnWizard_Click(object sender, EventArgs e)
		{
			new frmWizard().ShowDialog(this);
		}

		private void cboDestinationIteration_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboTFSIterations.SelectedItem == null)
				return;
			cboTFSSubPath.DataSource = ((Node) cboTFSIterations.SelectedItem).ChildNodes;
			cboTFSSubPath.DisplayMember = "Name";
		}

		private void cboProjects_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboTFSProjects.SelectedItem == null)
				return;
			PopulateTFSIterationsCombo(
				((Microsoft.TeamFoundation.WorkItemTracking.Client.Project) cboTFSProjects.SelectedItem).Name);
		}

		private void cboTFSSubPath_DropDownClosed(object sender, EventArgs e)
		{
			var priorityStep = 10;
			var nextPriority = 10;
			try
			{
				TFS.GetNextPriorityNumberAndPriorityStep(cboTFSProjects.Text, cboTFSIterations.Text,
				                                         cboTFSSubPath.Text, out nextPriority,
				                                         out priorityStep);
			}
			catch (Exception exception)
			{
				LogError(exception);
			}
			txtPriorityStep.Text = priorityStep.ToString();
			txtStartPriority.Text = nextPriority.ToString();
			PopulateTFSWorkItemList();
		}

		private void ConnectToPivotalAndPopulateData()
		{
			try
			{
				Cursor = Cursors.WaitCursor;
				if (VerifyLoginToPivotal())
				{
					PopulatePivotalProjectsCombo();
					PopulatePivotalIterationsCombo();
					btnGetStories.Enabled = true;
				}
			}
			catch (Exception exception)
			{
				LogError(exception);
			}
			Cursor = Cursors.Arrow;
		}

		private void ConnectToTFS()
		{
			try
			{
				TFS = new TFS2010(txtTFSServerURL.Text, txtDomain.Text,
				                  txtTFSUsername.Text, txtTFSPassword.Text);
			}
			catch (Exception exception)
			{
				LogError(exception);
			}
		}

		private void EnableTFSGroup(bool isvalid)
		{
			grpTFS.Enabled = isvalid;
		}

		private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			Settings.Default.Save();
		}

		private void frmMain_Load(object sender, EventArgs e)
		{
			IsReadyForSync();
		}

		private IEnumerable<TreeNode> GetCheckedTreeNodes()
		{
			return
				tvwDetails.Nodes.Cast<TreeNode>().Where(delegate(TreeNode node) { return node.Checked; });
		}

		private static int GetPivotalIdFromTFSWorkItem(WorkItem item)
		{
			int num;
			var originalValue = (string) item.Fields["History"].Value;
			if (originalValue == string.Empty)
			{
				originalValue = (string) item.Fields["History"].OriginalValue;
			}

			if ((!string.IsNullOrEmpty(originalValue) && originalValue.Contains(PIVOTALID)) &&
			    int.TryParse(
				    originalValue.Substring(originalValue.IndexOf(PIVOTALID) + PIVOTALID.Length).Replace(":", ""), out num))
			{
				return num;
			}

			var url = GetPivotalUrlFromTFSWorkItem(item);

			if (url == null)
				return -1;

			if (int.TryParse(url.Substring(url.LastIndexOf("/") + 1), out num))
				return num;

			return -1;
		}

		private static string GetPivotalUrlFromTFSWorkItem(WorkItem item)
		{
			if (item.Links != null)
			{
				var hyperlinks = item.Links.OfType<Hyperlink>();

				return
					hyperlinks.Where(hyperlink => hyperlink.Comment == "Link to pivotal story.").Select(hyperlink => hyperlink.Location)
					          .FirstOrDefault();
			}
			return null;
		}

		private IEnumerable<Story> GetPivotalStories()
		{
			Cursor = Cursors.WaitCursor;
			try
			{
				return pivotal.GetIteration((Project) cboPivotalProjects.SelectedItem,
				                            (Pivotal.IterationVersion)
				                            cboPivotalIteration.SelectedItem).First().Stories.stories;
			}
			catch (Exception exception)
			{
				LogError(exception);
			}
			finally
			{
				Cursor = Cursors.Arrow;
			}
			return new Story[0];
		}

		private static bool IsChildNode(TreeNode node)
		{
			return (node.Parent != null);
		}

		private bool IsPivotalLoginInformationPresent(bool isvalid)
		{
			if (txtPivotalUsername.Text.Trim().Length == 0)
			{
				isvalid = false;
				lstMessages.Items.Add("Invalid Pivotal username.");
			}
			if (txtPivotalPassword.Text.Trim().Length == 0)
			{
				isvalid = false;
				lstMessages.Items.Add("Invalid Pivotal password.");
			}
			btnGetStories.Enabled = isvalid;
			btnConnectToPivotal.Enabled = isvalid;
			return isvalid;
		}

		private bool IsReadyForSync()
		{
			var isvalid = true;
			isvalid = IsPivotalLoginInformationPresent(isvalid);
			isvalid = IsTFSLoginInformationPresent(isvalid);
			isvalid = IsStepInformationPresent(isvalid);
			btnSyncSelected.Enabled = isvalid;
			picLeft.Enabled = isvalid;
			picRight.Enabled = isvalid;
			return isvalid;
		}

		private bool IsStepInformationPresent(bool isvalid)
		{
			if (txtPriorityStep.Text.Trim().Length == 0)
			{
				isvalid = false;
				lstMessages.Items.Add("Invalid TFS Prioritystep.");
			}
			if (txtStartPriority.Text.Trim().Length == 0)
			{
				isvalid = false;
				lstMessages.Items.Add("Invalid TFS Startpriority.");
			}
			return isvalid;
		}

		private bool IsTFSLoginInformationPresent(bool isvalid)
		{
			if (txtTFSUsername.Text.Trim().Length == 0)
			{
				isvalid = false;
				lstMessages.Items.Add("Invalid TFS username.");
			}
			if (txtTFSPassword.Text.Trim().Length == 0)
			{
				isvalid = false;
				lstMessages.Items.Add("Invalid TFS password.");
			}
			if (txtTFSServerURL.Text.Trim().Length == 0)
			{
				isvalid = false;
				lstMessages.Items.Add("Invalid TFS ServerURL.");
			}
			if (txtDomain.Text.Trim().Length == 0)
			{
				isvalid = false;
				lstMessages.Items.Add("Invalid TFS Domain.");
			}
			btnConnectToTFS.Enabled = isvalid;
			EnableTFSGroup(isvalid);
			return isvalid;
		}

		private void LoadTFSProjects()
		{
			try
			{
				cboTFSProjects.DataSource = TFS.GetProjects();
				cboTFSProjects.DisplayMember = "Name";
			}
			catch (Exception exception)
			{
				LogError(exception);
			}
		}

		private void LogError(Exception exception)
		{
			lstMessages.Items.Add(exception.Message);
		}

		private void picRight_Click(object sender, EventArgs e)
		{
			SyncCheckedItems();
			PopulateTFSWorkItemList();
		}

		private void PopulatePivotalIterationsCombo()
		{
			cboPivotalIteration.Items.Clear();
			cboPivotalIteration.Items.Add(Pivotal.IterationVersion.All);
			cboPivotalIteration.Items.Add(Pivotal.IterationVersion.Backlog);
			cboPivotalIteration.Items.Add(Pivotal.IterationVersion.Current);
			cboPivotalIteration.Items.Add(Pivotal.IterationVersion.Done);
		}

		private void PopulatePivotalProjectsCombo()
		{
			cboPivotalProjects.DataSource = pivotal.GetAllProjects();
			cboPivotalProjects.DisplayMember = "Name";
		}

		private void PopulateTFSIterationsCombo(string projectname)
		{
			try
			{
				cboTFSIterations.DataSource = TFS.GetIterationPaths(projectname);
				cboTFSIterations.DisplayMember = "Name";
			}
			catch (Exception exception)
			{
				LogError(exception);
			}
		}

		private void PopulateTFSWorkItemList()
		{
			tvwTFS.Nodes.Clear();
			var workItemTypes = TFS.GetWorkItemTypes(cboTFSProjects.Text);
			var items = TFS.GetWorkItems(cboTFSProjects.Text, cboTFSIterations.Text,
			                             cboTFSSubPath.Text, workItemTypes["Product Backlog Item"], -1);
			if (items == null)
				return;

			tvwTFS.TreeViewNodeSorter = new NodeSorter();
			foreach (WorkItem item in items)
			{
				if (item.State == "Deleted")
					continue;
				var key = item.Id.ToString();
				tvwTFS.Nodes.Add(key, item.Title, item.Type.Name).Tag = item;
			}
			tvwTFS.Sort();
		}

		private void PopulateTreeview(IEnumerable<Story> stories)
		{
			tvwDetails.Nodes.Clear();
			if (stories == null)
				return;

			foreach (var story in stories)
			{
				var key = story.Id.ToString();
				var node = tvwDetails.Nodes.Add(key, story.Name, story.Type);
				node.Tag = story;
				if (story.Description.Trim().Length > 0)
				{
					node.Nodes.Add(key + "-2", story.Description.Trim(), "empty");
				}
			}
		}

		private bool SetPivotalStatus(Story pivotalstory, WorkItem workitem)
		{
			if (pivotalstory.CurrentState != "Finished")
			{
				switch (workitem.State)
				{
					case "Closed":
						pivotalstory.CurrentState = "finished";
						return true;

					case "In Progress":
						{
							if (pivotalstory.CurrentState.ToLowerInvariant() != "started")
							{
								pivotalstory.CurrentState = "started";
								return true;
							}
							return false;
						}
				}
			}
			return false;
		}

		private void Settings_SettingsLoaded(object sender, SettingsLoadedEventArgs e)
		{
			if (IsPivotalLoginInformationPresent(true))
			{
				ConnectToPivotalAndPopulateData();
			}
			if (IsTFSLoginInformationPresent(true))
			{
				ConnectToTFS();
				LoadTFSProjects();
			}
		}

		private void SyncCheckedItems()
		{
			Cursor = Cursors.WaitCursor;
			var progress = new frmProgress();
			try
			{
				progress.Show(this);
				var num = int.Parse(txtStartPriority.Text);
				var num2 = int.Parse(txtPriorityStep.Text);
				var name =
					((Microsoft.TeamFoundation.WorkItemTracking.Client.Project) cboTFSProjects.SelectedItem).Name;
				var checkedTreeNodes = GetCheckedTreeNodes();
				var num3 = 1;
				var extraTasksToAdd = GetExtraTasksToAdd();
				foreach (var node in checkedTreeNodes)
				{
					progress.SetMessage(string.Format("Copying item {0} of {1}", num3,
					                                  checkedTreeNodes.Count()));
					var tag = (Story) node.Tag;
					tag.Priority = num;
					TFS.AddPivotalStoryToTFS(tag, name, ((Node) cboTFSIterations.SelectedItem).Name,
					                         ((Node) cboTFSSubPath.SelectedItem).Name, extraTasksToAdd, chkKopieraPiovtalTasks.Checked);
					num += num2;
					num3++;
				}
			}
			finally
			{
				Cursor = Cursors.Arrow;
				progress.Close();
			}
		}

		private IEnumerable<Story> GetExtraTasksToAdd()
		{
			return from object defaulttask in chklstDefaultTasks.CheckedItems
			       select new Story
				       {
					       Description = defaulttask.ToString(),
					       Name = defaulttask.ToString()
				       };
		}

		private void SyncStatuses()
		{
			var dictionary =
				GetPivotalStories().Where(query => query.CurrentState.ToLowerInvariant() != "accepted").ToDictionary(d => d.Id);
			try
			{
				Monitor.Enter(dictionary);
				var workItemTypes = TFS.GetWorkItemTypes(cboTFSProjects.Text);
				var tfsWorkItems = TFS.GetWorkItems(cboTFSProjects.Text, cboTFSIterations.Text,
				                                    cboTFSSubPath.Text, workItemTypes["Product Backlog Item"],
				                                    -1);
				switch (cboSyncDirection.SelectedIndex)
				{
					case 0:
						return;

					case 1:
						SyncTFSWorkItemStatusesToPivotal(dictionary, tfsWorkItems);
						return;
				}
				SyncTFSWorkItemStatusesToPivotal(dictionary, tfsWorkItems);
			}
			finally
			{
				Monitor.Exit(dictionary);
			}
		}

		private void SyncTFSWorkItemStatusesToPivotal(IDictionary<int, Story> pivotalStoriesdictionary,
		                                              IEnumerable tfsWorkItems)
		{
			foreach (WorkItem workItem in tfsWorkItems)
			{
				var pivotalId = GetPivotalIdFromTFSWorkItem(workItem);

				if (pivotalId <= -1)
					continue;
				if (!pivotalStoriesdictionary.ContainsKey(pivotalId))
					continue;

				var pivotalstory = pivotalStoriesdictionary[pivotalId];
				if (SetPivotalStatus(pivotalstory, workItem))
					pivotal.UpdatePivotalStoryStatus((Project) cboPivotalProjects.SelectedItem, pivotalstory);
			}
		}

		private void tmrErrorMessage_Tick(object sender, EventArgs e)
		{
			if (lstMessages.Items.Count > 0)
			{
				lstMessages.Items.RemoveAt(0);
			}
		}

		private void tmrSync_Tick(object sender, EventArgs e)
		{
			SyncStatuses();
		}

		private void ToggleSyncText()
		{
			btnSync.Text = (btnSync.Text == "Stop Sync") ? "Start Sync" : "Stop Sync";
		}

		private void tvwDetails_MouseDown(object sender, MouseEventArgs e)
		{
			var view = (TreeView) sender;
			var nodeAt = view.GetNodeAt(e.X, e.Y);
			view.SelectedNode = nodeAt;
			if (nodeAt != null)
			{
				view.DoDragDrop(nodeAt.Clone(), DragDropEffects.Copy);
			}
		}

		private void tvwTFS_DragDrop(object sender, DragEventArgs e)
		{
			var view = (TreeView) sender;
			var p = new Point(e.X, e.Y);
			p = view.PointToClient(p);
			var nodeAt = view.GetNodeAt(p);
			var tag = (WorkItem) nodeAt.Tag;
			var item2 = (WorkItem) nodeAt.NextNode.Tag;
			var num =
				Math.Abs(
					((int) item2.Fields["Conchango.TeamSystem.Scrum.BusinessPriority"].Value) -
					((int) tag.Fields["Conchango.TeamSystem.Scrum.BusinessPriority"].Value));
			if (num < 2)
			{
				num = 2;
			}
			var num2 = ((int) tag.Fields["Conchango.TeamSystem.Scrum.BusinessPriority"].Value) + (num/2);
			if (((TreeNode) e.Data.GetData("System.Windows.Forms.TreeNode")).Tag.GetType().Name.Equals("WorkItem"))
			{
				var workitem = (WorkItem) ((TreeNode) e.Data.GetData("System.Windows.Forms.TreeNode")).Tag;
				workitem.Fields["Conchango.TeamSystem.Scrum.BusinessPriority"].Value = num2;
				workitem.Fields["Conchango.TeamSystem.Scrum.DeliveryOrder"].Value = num2;
				TFS.UpdateWorkItem(workitem);
			}
			else
			{
				var pivotalStoryToAdd = (Story) ((TreeNode) e.Data.GetData("System.Windows.Forms.TreeNode")).Tag;
				pivotalStoryToAdd.Priority = num2;
				TFS.AddPivotalStoryToTFS(pivotalStoryToAdd, cboTFSProjects.Text, cboTFSIterations.Text,
				                         cboTFSSubPath.Text, GetExtraTasksToAdd(), chkKopieraPiovtalTasks.Checked);
			}
			PopulateTFSWorkItemList();
		}

		private void tvwTFS_DragOver(object sender, DragEventArgs e)
		{
			var view = (TreeView) sender;
			var effect = e.Effect;
			e.Effect = DragDropEffects.None;
			if (e.Data.GetData(typeof (TreeNode)) == null)
				return;
			var p = new Point(e.X, e.Y);
			p = view.PointToClient(p);
			var nodeAt = view.GetNodeAt(p);
			if (nodeAt == null)
				return;
			e.Effect = (effect != DragDropEffects.None) ? effect : DragDropEffects.Copy;
			view.SelectedNode = nodeAt;
		}

		private void tvwTFS_MouseDown(object sender, MouseEventArgs e)
		{
			var view = (TreeView) sender;
			var nodeAt = view.GetNodeAt(e.X, e.Y);
			view.SelectedNode = nodeAt;
			if (nodeAt != null)
			{
				view.DoDragDrop(nodeAt, DragDropEffects.Copy);
			}
		}

		private void Validate_ReadyForSync(object sender, EventArgs e)
		{
			IsReadyForSync();
		}

		private bool VerifyLoginToPivotal()
		{
			try
			{
				pivotal = new Pivotal(txtPivotalUsername.Text,
				                      txtPivotalPassword.Text);
				return true;
			}
			catch (Exception exception)
			{
				LogError(exception);
				return false;
			}
		}

		private static void WriteStoriesToStream(Iteration iteration, IEnumerable<Story> stories,
		                                         StorySerializer serializer, FileStream tempFileStream)
		{
			int num;
			serializer.Iteration = iteration;
			var stream = serializer.Serialize(stories);
			var buffer = new byte[0x1000];
			while ((num = stream.Read(buffer, 0, buffer.Length)) > 0)
			{
				tempFileStream.Write(buffer, 0, num);
			}
		}

		private void btnSyncNow_Click(object sender, EventArgs e)
		{
			SyncStatuses();
		}

		private void btnRapport_Click(object sender, EventArgs e)
		{
			var frm = new frmFörändringsrapport();
			var dialogresult = frm.ShowDialog(this);
			if (dialogresult == DialogResult.Cancel)
				return;

			var fromdate = frm.fromDate;
			var todate = frm.toDate;

			//Ta ut alla us mellan datumen
			//kontrollera mot tfs:en om det finns incheckningar på workitem som ingår i datumintervallet ovan.

			var items = TFS.GetWorkItemsWithCodechanges(cboTFSProjects.Text, fromdate, todate).OfType<BacklogItemWithChanges>();

			if (items.Count() == 0)
			{
				return;
			}

			var filestream = File.CreateText(@"c:\temp\export.csv");

			foreach (var workItem in items)
			{
				filestream.WriteLine(GenereraWorkItemRad(workItem));
			}
			filestream.Flush();
			filestream.Close();
		}

		private static string GenereraWorkItemRad(BacklogItemWithChanges workItem)
		{
			const string separator = "\t";
			return string.Concat(workItem.BacklogItem.Type.Name, separator, GetPivotalIdFromTFSWorkItem(workItem.BacklogItem),
			                     separator, GetPivotalUrlFromTFSWorkItem(workItem.BacklogItem), separator,
			                     workItem.BacklogItem.Title, separator,
			                     workItem.BacklogItem.IterationPath, separator, workItem.ChangedBy);
		}

		private void chklstDefaultTasks_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			var frm = new frmEditAdditionalTasks(chklstDefaultTasks.Items);
			frm.ShowDialog(this);
			if (frm.DialogResult != DialogResult.OK)
				return;

			chklstDefaultTasks.DataSource = frm.AdditionalTasks;
			chklstDefaultTasks.Refresh();
		}

		private void btnAddPivotalId_Click(object sender, EventArgs e)
		{
			var workitems = TFS.GetWorkItemsWithoutPivotalIds(cboTFSProjects.Text);

			foreach (var workItem in workitems.Where(q => q.Title.Length > 0))
			{
				var pivotalstory = GetPivotalStoryViaTitle(workItem.Title);
				if (pivotalstory == null)
					continue;

				var hp = new Hyperlink(pivotalstory.URL)
					{
						Comment = "Link to pivotal story."
					};
				workItem.Links.Add(hp);
				workItem.Save();
			}
		}

		private Story GetPivotalStoryViaTitle(string title)
		{
			if (string.IsNullOrEmpty(title) || title.Contains(":"))
				return null;

			var story = pivotal.GetStoriesByFilter((Project) cboPivotalProjects.SelectedItem, string.Format("includedone:true name:\"{0}\"", HttpUtility.UrlEncode(title)));
			return story != null ? story.FirstOrDefault() : null;
		}

		private class NodeSorter : IComparer
		{
			#region IComparer Members

			public int Compare(object x, object y)
			{
				var node = (TreeNode) x;
				var node2 = (TreeNode) y;
				var tag = node.Tag as WorkItem;
				var item2 = node2.Tag as WorkItem;
				if (item2 != null)
				{
					int num;
					int num2;
					if (tag == null)
					{
						return 1;
					}
					if (tag.Fields["Conchango.TeamSystem.Scrum.BusinessPriority"].Value == null)
					{
						return 1;
					}
					if (item2.Fields["Conchango.TeamSystem.Scrum.BusinessPriority"].Value == null)
					{
						return 0;
					}
					int.TryParse(tag.Fields["Conchango.TeamSystem.Scrum.BusinessPriority"].Value.ToString(), out num);
					int.TryParse(item2.Fields["Conchango.TeamSystem.Scrum.BusinessPriority"].Value.ToString(), out num2);
					if (num >= num2)
					{
						return 1;
					}
				}
				return 0;
			}

			#endregion
		}
	}
}