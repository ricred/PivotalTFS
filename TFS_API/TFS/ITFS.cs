using System;
using System.Collections.Generic;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using PivotalTFS_GENERAL;

namespace TFS_API.TFS
{
	public interface ITFS
	{
		NodeCollection GetIterationPaths(string projectname);

		void AddPivotalStoryToTFS(Story pivotalStoryToAdd, string projectname, string iterationPath, string subPath, IEnumerable<Story> additionalDefaultTask, bool kopieraÄvenPiovtalTasks);

		bool DeletePivotalStoryFromTFS(Story storyToDelete, string projectname, string iterationPath);
		ProjectCollection GetProjects();

		void GetNextPriorityNumberAndPriorityStep(string projectname, string iterationPath, string subPath,
		                                          out int nextPriority, out int priorityStep);

		WorkItemCollection GetWorkItems(string projectname, string iterationPath, string subPath,
		                                WorkItemType workitemtype, int forSpecificBacklogItemId);

		WorkItemTypeCollection GetWorkItemTypes(string projectname);

		void UpdateWorkItem(WorkItem workitem);

		IEnumerable<BacklogItemWithChanges> GetWorkItemsWithCodechanges(string projectname, DateTime fromdate, DateTime todate);

		IEnumerable<WorkItem> GetWorkItemsWithoutPivotalIds(string projectname);
	}
}