using Microsoft.TeamFoundation.WorkItemTracking.Client;

namespace PivotalTFSSync
{
    public interface ITFS
    {
        NodeCollection GetIterationPaths(string projectname);
        void AddPivotalStoryToTFS(Story pivotalStoryToAdd, string projectname, string iterationPath, string subPath);
        bool DeletePivotalStoryFromTFS(Story storyToDelete, string projectname, string iterationPath);
        ProjectCollection GetProjects();

        void GetNextPriorityNumberAndPriorityStep(string projectname, string iterationPath, string subPath,
                                                  out int nextPriority, out int priorityStep);

        WorkItemCollection GetWorkItems(string projectname, string iterationPath, string subPath,
                                        WorkItemType workitemtype, int forSpecificBacklogItemId);

        WorkItemTypeCollection GetWorkItemTypes(string projectname);

        void UpdateWorkItem(WorkItem workitem);
    }
}