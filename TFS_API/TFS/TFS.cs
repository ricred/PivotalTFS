using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using PivotalTFS_GENERAL;

namespace TFS_API.TFS
{
	public class TFS : ITFS
	{
		private const string Pivotalid = "PIVOTALID:";
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
			if (workitems.Count == 0)
			{
				nextPriority = 100;
				priorityStep = 10;
				return;
			}
			int lastWorkItemStepNumber, nextlastWorkItemStepNumber = -1;
			var currentItemIndex = workitems.Count - 1;
			bool foundLastWorkItem = false, foundSecondLastWorkItem = false;


			while (true)
			{
				var lastWorkItem = workitems[currentItemIndex];
				GetPriorityFieldValue(lastWorkItem, out lastWorkItemStepNumber);

				if (lastWorkItemStepNumber > 0)
				{
					foundLastWorkItem = true;
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