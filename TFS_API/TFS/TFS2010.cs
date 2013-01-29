using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.VersionControl.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using PivotalTFS_GENERAL;
using TFS_API.Properties;
using TFS_API.TFS.Templates;

namespace TFS_API.TFS
{
	public class TFS2010 : ITFS
	{
		private const string Pivotalid = "PIVOTALID:";
		private const string ProductBacklogItem = "Product Backlog Item";
		private const string HistoryField = "History";
		private readonly WorkItemStore store;
		// private readonly TfsConfigurationServer tfsConfigurationServer;
		private TemplateProxy templateproxy = new TemplateProxy();
		private TfsTeamProjectCollection tfsTeamProjectCollection;
		private static string SprintBacklogItem = "Sprint Backlog Item";

		public TFS2010(string servername, string domain, string username, string password)
		{
			if (string.IsNullOrEmpty(servername))
				throw new ArgumentException("Parameter named:servername cannot be null or empty.");

			if (string.IsNullOrEmpty(username))
				throw new ArgumentException("Parameter named:username cannot be null or empty.");

			if (string.IsNullOrEmpty(password))
				throw new ArgumentException("Parameter named:password cannot be null or empty.");

			//ICredentialsProvider provider = new UICredentialsProvider();
			//tfsConfigurationServer = TeamFoundationServerFactory.GetServer(serverName, provider);
			//if (!tfsConfigurationServer.HasAuthenticated)
			//    tfsConfigurationServer.Authenticate();

			//tfsConfigurationServer = new TfsConfigurationServer(new Uri(string.Concat("http://", servername)),
			//                                                    new NetworkCredential(username, password, domain));

			//TeamProjectPicker pp = new TeamProjectPicker(TeamProjectPickerMode.SingleProject, false);

			//pp.ShowDialog();

			//var coll = new TfsTeamProjectCollection(new Uri(string.Concat("http://", servername)), new UICredentialsProvider());
			tfsTeamProjectCollection = new TfsTeamProjectCollection(new Uri(string.Concat("http://", servername)),
																	new NetworkCredential(username, password, domain));
			tfsTeamProjectCollection.EnsureAuthenticated();
			store = (WorkItemStore)tfsTeamProjectCollection.GetService(typeof(WorkItemStore));

			//var processTemplates = (IProcessTemplates)tfsTeamProjectCollection.GetService(typeof(IProcessTemplates));
			//var node = processTemplates.GetTemplateNames();

			//ICommonStructureService css = (ICommonStructureService)tfsTeamProjectCollection.GetService(typeof(ICommonStructureService));
			//ProjectInfo projectInfo = css.GetProjectFromName(store.Projects[5].Name);
			//String projectName;
			//String prjState;
			//int templateId = 0;
			//ProjectProperty[] projectProperties;

			//css.GetProjectProperties(
			//        projectInfo.Uri, out projectName, out prjState, out templateId, out projectProperties);

			// //tfsConfigurationServer.Authenticate();
			// var tpcService = tfsConfigurationServer.GetService<ITeamProjectCollectionService>();
			//var  collections = tpcService.GetCollections();
			// //var wstore= ((TfsTeamProjectCollection )collections[0]).GetService(typeof (WorkItemStore));
			// var ws=tpcService.GetServicingOperation("WorkItemStore");

			// store = (WorkItemStore) tfsConfigurationServer.GetService(typeof (WorkItemStore));
		}

		#region ITFS Members

		public NodeCollection GetIterationPaths(string projectname)
		{
			try
			{
				return store.Projects[projectname].IterationRootNodes;
			}
			catch (Exception)
			{
				//TODO: log error. 
			}
			return null;
		}

		public void AddPivotalStoryToTFS(Story pivotalStoryToAdd, string projectname, string iterationPath, string subPath, IEnumerable<Story> additionalDefaultTask, bool kopieraÄvenPiovtalTasks)
		{

			var workItemTypes = store.Projects[projectname].WorkItemTypes;

			var existingworkingItem = GetTFSBacklogItemByPivotalId(projectname, iterationPath, subPath,
																   pivotalStoryToAdd.Id);
			if (existingworkingItem != null)
			{
				existingworkingItem.Title = pivotalStoryToAdd.Name;
				existingworkingItem.Description = string.Concat(pivotalStoryToAdd.URL, Environment.NewLine,
																pivotalStoryToAdd.Description);
				existingworkingItem.Save();
				return;
			}

			var workItem = new WorkItem(workItemTypes[ProductBacklogItem]);

			if (pivotalStoryToAdd.Type == "bug")
			{
				workItem = new WorkItem(workItemTypes["Bug"]);
			}

			templateproxy.CopyPivotalStoryValuesToWorkItem(pivotalStoryToAdd, workItem);

			workItem.Description = string.Concat(pivotalStoryToAdd.URL, Environment.NewLine,
												 pivotalStoryToAdd.Description);
			workItem.Title = pivotalStoryToAdd.Name;
			workItem.IterationPath = string.Concat(projectname, "\\", iterationPath, "\\", subPath);
			workItem.Fields[HistoryField].Value = string.Concat(Pivotalid, pivotalStoryToAdd.Id, ":");

			//Add Hyper Link
			//Link most be valid!
			if (pivotalStoryToAdd.URL != null)
			{

				var hp = new Hyperlink(pivotalStoryToAdd.URL)
				{
					Comment = "Link to pivotal story."
				};
				workItem.Links.Add(hp);
			}

			if (kopieraÄvenPiovtalTasks)
			{
				//add all existing pivotal tasks as linked workitems to this product backlog workitem. 
				AddPivotalTasksAsLinkedWorkItems(workItemTypes, workItem, pivotalStoryToAdd);
			}

			//Add additional tasks.
			if (additionalDefaultTask!=null)
				AddAdditionalTasks(workItemTypes, workItem, additionalDefaultTask);

			//Add Attachment
			//TFS will search for the file, so make sure it exists.

			//Attachment a = new Attachment(@"C:\FileToAdd.txt", "Comment....");
			//workItem.Attachments.Add(a);

			//Make sure your Work Item is Valid
			//After you finish adding all the wanted values into the Work Item make sure that all fields are Valid and your can save the Work Item, This step is to make sure that you prepare the Work Item Definition for the migration. 

			var invalidFields = new ArrayList();
			foreach (var field in workItem.Fields.Cast<Field>().Where(field => !field.IsValid))
			{
				invalidFields.Add(field);
				Console.WriteLine(Resources.TFS_AddPivotalStoryToTFS_Invalid_Field, field.Name, field.Status);
				Console.WriteLine(Resources.TFS_AddPivotalStoryToTFS_Current_Value, field.Value);
			}
			//There are some Invalid Fields.

			if (invalidFields.Count > 0)
			{
				Console.WriteLine(Resources.TFS_AddPivotalStoryToTFS_Invalid_Bug_Track_ID, invalidFields.ToArray());
				return;
			}
			workItem.Save();

		}

		private static void AddAdditionalTasks(WorkItemTypeCollection workItemTypes, WorkItem parentWorkItem, IEnumerable<Story> additionalTaskTitles)
		{
			foreach (var workitemTask in additionalTaskTitles.Select(story => new WorkItem(workItemTypes[SprintBacklogItem])
																					{
																						Title = story.Name,
																						Description = story.Description,
																						IterationPath = parentWorkItem.IterationPath
																					}))
			{
				workitemTask.Fields[HistoryField].Value = parentWorkItem.Fields[HistoryField].Value;
				workitemTask.Save();
				parentWorkItem.Links.Add(new RelatedLink(workitemTask.Id));
			}
		}

		public bool DeletePivotalStoryFromTFS(Story storyToDelete, string projectname, string iterationPath)
		{
			var iteration = store.Projects[projectname].IterationRootNodes[iterationPath];
			if (iteration != null)
			{
				var nodes =
					store.Projects[projectname].IterationRootNodes[iterationPath].ChildNodes.GetEnumerator();
				while (nodes.MoveNext())
				{
					if (!((WorkItem)nodes.Current).History.Contains(string.Concat(Pivotalid, storyToDelete.Id)))
						continue;

					var workitem = ((WorkItem)nodes.Current);
					if (workitem == null)
						continue;

					workitem.Open();
					workitem.Reason = "Deleted in Pivotal.";
					workitem.State = "Closed";
					workitem.Save();
				}
			}
			return false;
		}

		//public void AddPivotalStoryToTFS(Story pivotalStoryToAdd, string projectname, string iterationPath,
		//                                 string subPath)
		//{

		//    AddPivotalStoryToTFS(pivotalStoryToAdd, projectname, iterationPath, subPath, null, false);


		//}

		public ProjectCollection GetProjects()
		{
			try
			{
				return store.Projects;
			}
			catch (Exception)
			{
				//TODO: log error. 
			}
			return null;
		}

		public void GetNextPriorityNumberAndPriorityStep(string projectname, string iterationPath, string subPath,
														 out int nextPriority, out int priorityStep)
		{
			priorityStep = 10;
			var workItemTypes = store.Projects[projectname].WorkItemTypes;

			var workitems = GetWorkItems(projectname, iterationPath, subPath, workItemTypes["Product Backlog Item"], -1);

			if (workitems.Count == 0)
			{
				nextPriority = 100;
				priorityStep = 10;
				return;
			}

			int lastWorkItemStepNumber = -1, nextlastWorkItemStepNumber = -1;
			var currentItemIndex = workitems.Count - 1;
			bool foundLastWorkItem = false, foundSecondLastWorkItem = false;
			if (workitems.Count == 1)
			{
				GetPriorityFieldValue(workitems[0], out lastWorkItemStepNumber);
				priorityStep = lastWorkItemStepNumber;
				nextPriority = lastWorkItemStepNumber + priorityStep;
				return;
			}
			//DumpAllWorkItems(workitems);

			while (true)
			{
				try
				{
					if (!foundLastWorkItem)
					{
						var lastWorkItem = workitems[currentItemIndex];
						GetPriorityFieldValue(lastWorkItem, out lastWorkItemStepNumber);

						if (lastWorkItemStepNumber > 0)
						{
							//next lastWorkItemStepNumber
							foundLastWorkItem = true;
						}
					}

					if (!foundSecondLastWorkItem)
					{
						var nextLastWorkItem = workitems[currentItemIndex - 1];
						GetPriorityFieldValue(nextLastWorkItem, out nextlastWorkItemStepNumber);

						foundSecondLastWorkItem = true;
					}

					if (foundLastWorkItem)
					{
						priorityStep = lastWorkItemStepNumber - nextlastWorkItemStepNumber;
						break;
					}
				}
				catch (Exception)
				{
					//TODO: log error. 
				}
				currentItemIndex--;
				if (currentItemIndex <= 0)
				{
					break;
				}
			}
			nextPriority = lastWorkItemStepNumber + priorityStep;
		}

		public WorkItemCollection GetWorkItems(string projectname, string iterationPath, string subPath,
											   WorkItemType workitemtype, int forSpecificBacklogItemId)
		{
			var completeiterationpath = string.Concat(projectname, "\\", iterationPath, "\\", subPath);
			if (forSpecificBacklogItemId < 0)
			{
				return
					store.Query(
						string.Format(
							"SELECT * FROM WorkItems WHERE [System.TeamProject] = '{0}' AND [System.IterationPath]='{1}' AND  [System.WorkItemType] = '{2}'",
							projectname, completeiterationpath, workitemtype.Name));
			}

			return
				store.Query(
					string.Format(
						"SELECT * FROM WorkItems WHERE [System.TeamProject] = '{0}' AND [System.IterationPath]='{1}' AND  [System.WorkItemType] = '{2}' AND [System.BacklogWorkItemId] = '{3}'",
						projectname, completeiterationpath, workitemtype.Name, forSpecificBacklogItemId));
		}

		public WorkItemTypeCollection GetWorkItemTypes(string projectname)
		{
			return store.Projects[projectname].WorkItemTypes;
		}

		public void UpdateWorkItem(WorkItem workitem)
		{
			//  throw new NotImplementedException();
		}

		#endregion

		private static void AddPivotalTasksAsLinkedWorkItems(WorkItemTypeCollection workItemTypes, WorkItem workItem,
															 Story pivotalStoryToAdd)
		{
			if (pivotalStoryToAdd.Tasks == null)
				return;
			foreach (var task in pivotalStoryToAdd.Tasks.tasks)
			{
				var workitemTask = new WorkItem(workItemTypes[SprintBacklogItem])
									{
										Title = task.Description,
										IterationPath = workItem.IterationPath
									};
				workitemTask.Fields[HistoryField].Value = workItem.Fields[HistoryField].Value;
				workitemTask.Save();
				workItem.Links.Add(new RelatedLink(workitemTask.Id));
			}
		}

		public IEnumerable<BacklogItemWithChanges> GetWorkItemsWithCodechanges(string projectname, DateTime fromdate, DateTime todate)
		{
			var workitems =
			store.Query(
				string.Format(
					"SELECT * FROM WorkItems WHERE [System.TeamProject] = '{0}' AND [System.ChangedDate]>='{1}' AND [System.ChangedDate]<='{2}'",
					projectname, fromdate.ToShortDateString(), todate.ToShortDateString())).OfType<WorkItem>();
			var versionControlServer = tfsTeamProjectCollection.GetService<VersionControlServer>();
			var artifactProvider = versionControlServer.ArtifactProvider;

			var workitemsWithChangesets = new List<BacklogItemWithChanges>();

			foreach (var workitem in workitems)
			{
				var changesets =
					workitem.Links.OfType<ExternalLink>().Select(link => artifactProvider.GetChangeset(new Uri(link.LinkedArtifactUri)));

				if (changesets.Count() <= 0)
					continue;

				var names = GetNamesOfPersons(changesets);

				var relatedlink = (from related in workitem.Links.OfType<RelatedLink>()
								   where related.GetType() == typeof(RelatedLink)
								   select related).FirstOrDefault();

				var backlogItem = relatedlink == null ? workitem : store.GetWorkItem(relatedlink.RelatedWorkItemId);

				if (!ContainsBacklogItemId(workitemsWithChangesets, backlogItem.Id))
					workitemsWithChangesets.Add(new BacklogItemWithChanges
													{
														BacklogItem = backlogItem,
														ChangedBy = names
													});
			}
			return workitemsWithChangesets;
		}

		public IEnumerable<WorkItem> GetWorkItemsWithoutPivotalIds(string projectname)
		{
			//var workitems =store.Query(string.Format("SELECT * FROM WorkItems WHERE [System.TeamProject] = '{0}'",projectname)).OfType<WorkItem>();

			//var workitemsWithoutPivotalIds = from ws in workitems where ws.Links[0].ArtifactLinkType.Name != "Hyperlink" select ws;
			//return workitemsWithoutPivotalIds;

			return store.Query(
				   string.Format(
					   "SELECT * FROM WorkItems WHERE [System.TeamProject] = '{0}' AND  [System.History] not contains '%PIVOTALID:%'",
					   projectname)).OfType<WorkItem>();

		}

		private static bool ContainsBacklogItemId(IEnumerable<BacklogItemWithChanges> workitemsWithChangesets, int id)
		{
			return workitemsWithChangesets.Where(q => q.BacklogItem.Id == id).Count() > 0;
		}

		private static string GetNamesOfPersons(IEnumerable<Changeset> changesets)
		{
			var results = new List<string>();
			var strbuilder = new StringBuilder();

			foreach (var name in
				changesets.Select(changeset => changeset.Committer.Substring(changeset.Committer.IndexOf(@"\") + 1)).Where(name => !results.Contains(name)))
			{
				results.Add(name);
			}
			results.ForEach(a => strbuilder.AppendFormat("{0},", a));
			strbuilder.Remove(strbuilder.Length - 1, 1);

			return strbuilder.ToString();
		}

		private void DumpAllWorkItems(IEnumerable workitems)
		{
			foreach (var field in from WorkItem item in workitems
								  from Field field in item.Fields
								  select field)
			{
				Console.Write(field.Id);
				Console.Write(":");
				Console.Write(field.Name);
				Console.Write(":");
				Console.Write(field.Value);
				Console.WriteLine("---");
			}
		}

		private WorkItem GetTFSBacklogItemByPivotalId(string projectname, string iterationPath, string subPath, int id)
		{
			var completeiterationpath = string.Concat(projectname, "\\", iterationPath, "\\", subPath);

			var results =
				store.Query(
					string.Format(
						"SELECT * FROM WorkItems WHERE [System.TeamProject] = '{0}' AND [System.IterationPath]='{1}' AND  [System.History] contains '%{2}{3}:%'",
						projectname, completeiterationpath, Pivotalid, id));
			if (results != null && results.Count > 0)
				return results[0];

			return null;
		}

		private static void GetPriorityFieldValue(WorkItem wrk, out int val)
		{
			const string conchangoTeamsystemScrumBusinesspriority = "Business Priority (Scrum)";
			const string vstsBusinessPriority = "Microsoft.VSTS.Common.BacklogPriority";
			try
			{
				Field field;
				if (wrk.Fields.Contains(conchangoTeamsystemScrumBusinesspriority))
					field = wrk.Fields[conchangoTeamsystemScrumBusinesspriority];
				else
					field = wrk.Fields[vstsBusinessPriority];
				val = int.Parse(field.Value.ToString());
				return;
			}
			catch (Exception)
			{
				val = -1;
				return;
			}
		}
	}
}