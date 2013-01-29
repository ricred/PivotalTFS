using Microsoft.TeamFoundation.WorkItemTracking.Client;

namespace TFS_API.TFS
{
	public class BacklogItemWithChanges
	{
		public WorkItem  BacklogItem
		{
			get;
			set;
		}

		public string ChangedBy
		{
			get;
			set;
		}
	}
}