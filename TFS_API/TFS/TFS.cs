using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using PivotalTFS_GENERAL;

namespace TFS_API.TFS
{
	public class TFS : ITFS
	{
		private const string Pivotalid = "PIVOTALID:";
		private const string ProductBacklogItem = "Product Backlog Item";
		private const string HistoryField = "History";
		private readonly WorkItemStore store;

		public TFS(string servername, string domain, string username, string password)
		{
			if (string.IsNullOrEmpty(servername))
			{
				throw new ArgumentException("Parameter named:servername cannot be null or empty.");
			}

			if (string.IsNullOrEmpty(username))
			{
				throw new ArgumentException("Parameter named:username cannot be null or empty.");
			}
			if (string.IsNullOrEmpty(password))
			{
				throw new ArgumentException("Parameter named:password cannot be null or empty.");
			}

			try
			{
				var tfsConfigurationServer = new TfsConfigurationServer(new Uri(servername),
				                                                        new NetworkCredential(username, password, domain));
				store = (WorkItemStore) tfsConfigurationServer.GetService(typeof (WorkItemStore));
			}
			catch (Exception)
			{
				var tfsServer = new TeamFoundationServer(servername, new NetworkCredential(username, password, domain));
				store = (WorkItemStore) tfsServer.GetService(typeof (WorkItemStore));
			}
		}

		#region ITFS Members

		NodeCollection ITFS.GetIterationPaths(string projectname)
		{
			return store.Projects[projectname].IterationRootNodes;
		}

		public void AddPivotalStoryToTFS(Story pivotalStoryToAdd, string projectname, string iterationPath, string subPath, IEnumerable<Story> additionalDefaultTask, bool kopieraÄvenPiovtalTasks)
		{
			throw new NotImplementedException();
		}

		bool ITFS.DeletePivotalStoryFromTFS(Story storyToDelete, string projectname, string iterationPath)
		{
			var iteration = store.Projects[projectname].IterationRootNodes[iterationPath];
			if (iteration != null)
			{
				var nodes =
					store.Projects[projectname].IterationRootNodes[iterationPath].ChildNodes.GetEnumerator();
				while (nodes.MoveNext())
				{
					if (!((WorkItem) nodes.Current).History.Contains(string.Concat(Pivotalid, storyToDelete.Id))) continue;
					var workitem = ((WorkItem) nodes.Current);
					if (workitem == null) continue;
					workitem.Open();
					workitem.Reason = "Deleted in Pivotal.";
					workitem.State = "Closed";
					workitem.Save();
				}
			}
			return false;
		}

		//void ITFS.AddPivotalStoryToTFS(Story pivotalStoryToAdd, string projectname, string iterationPath, string subPath)
		//{
		//    var workItemTypes = store.Projects[projectname].WorkItemTypes;

		//    var existingworkingItem = GetTFSBacklogItemByPivotalId(projectname, iterationPath, subPath,
		//                                                           pivotalStoryToAdd.Id);
		//    if (existingworkingItem != null)
		//    {
		//        existingworkingItem.Description = string.Concat(pivotalStoryToAdd.URL, Environment.NewLine,
		//                                                        pivotalStoryToAdd.Description);
		//        existingworkingItem.Save();
		//        return;
		//    }

		//    var workItem = new WorkItem(workItemTypes[ProductBacklogItem]);

		//    if (pivotalStoryToAdd.Type == "bug")
		//    {
		//        workItem = new WorkItem(workItemTypes["Bug"]);
		//    }

		//    workItem.Fields[(string) TFSConstants.ConchangoTeamsystemScrumEstimatedeffort].Value =
		//        pivotalStoryToAdd.Estimate;
		//    workItem.Fields[(string) TFSConstants.ConchangoTeamsystemScrumBusinesspriority].Value =
		//        pivotalStoryToAdd.Priority;
		//    workItem.Fields[(string) TFSConstants.ConchangoTeamsystemScrumDeliveryorder].Value =
		//        pivotalStoryToAdd.Priority;

		//    workItem.Description = string.Concat(pivotalStoryToAdd.URL, Environment.NewLine,
		//                                         pivotalStoryToAdd.Description);
		//    workItem.Title = pivotalStoryToAdd.Name;
		//    workItem.IterationPath = string.Concat(projectname, "\\", iterationPath, "\\", subPath);
		//    workItem.Fields[HistoryField].Value = string.Concat(Pivotalid, pivotalStoryToAdd.Id, ":");

		//    //Add Hyper Link
		//    //Link most be valid!
		//    var hp = new Hyperlink(pivotalStoryToAdd.URL) {Comment = "Link to pivotal story."};
		//    workItem.Links.Add(hp);

		//    //Add Attachment
		//    //TFS will search for the file, so make sure it exists.

		//    //Attachment a = new Attachment(@"C:\FileToAdd.txt", "Comment....");
		//    //workItem.Attachments.Add(a);

		//    //Make sure your Work Item is Valid
		//    //After you finish adding all the wanted values into the Work Item make sure that all fields are Valid and your can save the Work Item, This step is to make sure that you prepare the Work Item Definition for the migration. 

		//    var invalidFields = new ArrayList();
		//    foreach (Field field in workItem.Fields)
		//    {
		//        if (!field.IsValid)
		//        {
		//            invalidFields.Add(field);
		//            Console.WriteLine(Resources.TFS_AddPivotalStoryToTFS_Invalid_Field, field.Name, field.Status);
		//            Console.WriteLine(Resources.TFS_AddPivotalStoryToTFS_Current_Value, field.Value);
		//        }
		//    }
		//    //There are some Invalid Fields.
		//    if (invalidFields.Count > 0)
		//    {
		//        Console.WriteLine(Resources.TFS_AddPivotalStoryToTFS_Invalid_Bug_Track_ID, invalidFields.ToArray());
		//        return;
		//    }
		//    workItem.Save();
		//}

		ProjectCollection ITFS.GetProjects()
		{
			return store.Projects;
		}

		void ITFS.GetNextPriorityNumberAndPriorityStep(string projectname, string iterationPath, string subPath,
		                                               out int nextPriority, out int priorityStep)
		{
			priorityStep = 10;
			var workItemTypes = store.Projects[projectname].WorkItemTypes;

			var workitems = ((ITFS) this).GetWorkItems(projectname, iterationPath, subPath,
			                                           workItemTypes["Product Backlog Item"],
			                                           -1);
			//workitems.SortFields.Add( new SortField( ))
			if (workitems.Count == 0)
			{
				nextPriority = 100;
				priorityStep = 10;
				return;
			}
			int lastWorkItemStepNumber, nextlastWorkItemStepNumber = -1;
			var currentItemIndex = workitems.Count - 1;
			bool foundLastWorkItem = false, foundSecondLastWorkItem = false;

			//DumpAllWorkItems(workitems);

			while (true)
			{
				//if (!foundLastWorkItem)
				//{
				var lastWorkItem = workitems[currentItemIndex];
				GetPriorityFieldValue(lastWorkItem, out lastWorkItemStepNumber);

				if (lastWorkItemStepNumber > 0)
				{
					//next lastWorkItemStepNumber
					foundLastWorkItem = true;
				}
				//}

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

				currentItemIndex--;
				if (currentItemIndex <= 0)
				{
					break;
				}
			}
			nextPriority = lastWorkItemStepNumber + priorityStep;
		}

		WorkItemCollection ITFS.GetWorkItems(string projectname, string iterationPath, string subPath,
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

		WorkItemTypeCollection ITFS.GetWorkItemTypes(string projectname)
		{
			return store.Projects[projectname].WorkItemTypes;
		}

		public void UpdateWorkItem(WorkItem workitem)
		{
			workitem.Save();
		}

		public IEnumerable<BacklogItemWithChanges> GetWorkItemsWithCodechanges(string projectname, DateTime fromdate, DateTime todate)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<WorkItem> GetWorkItemsWithoutPivotalIds(string projectname)
		{
			throw new NotImplementedException();
		}

		#endregion

		private static void DumpAllWorkItems(IEnumerable workitems)
		{
			foreach (var field in from WorkItem item in workitems from Field field in item.Fields select field)
			{
				Console.Write(field.Id);
				Console.Write(@":");
				Console.Write(field.Name);
				Console.Write(@":");
				Console.Write(field.Value);
				Console.WriteLine(@"---");
			}
		}

		private WorkItem GetTFSBacklogItemByPivotalId(string projectname, string iterationPath, string subPath, int id)
		{
			var completeiterationpath = string.Concat(projectname, "\\", iterationPath, "\\", subPath);
			try
			{
				return
					store.Query(
						string.Format(
							"SELECT * FROM WorkItems WHERE [System.TeamProject] = '{0}' AND [System.IterationPath]='{1}' AND  [System.History] contains '%{2}{3}:%'",
							projectname, completeiterationpath, Pivotalid, id))[0];
			}
			catch (Exception)
			{
			}
			return null;
		}

		private static void GetPriorityFieldValue(WorkItem wrk, out int val)
		{
			const string conchangoTeamsystemScrumBusinesspriority = "Business Priority (Scrum)";

			try
			{
				var field = wrk.Fields[conchangoTeamsystemScrumBusinesspriority];
				val = int.Parse(field.Value.ToString());
			}
			catch (Exception)
			{
				val = -1;
			}
		}
	}
}