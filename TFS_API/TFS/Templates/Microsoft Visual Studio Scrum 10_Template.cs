using Microsoft.TeamFoundation.WorkItemTracking.Client;
using PivotalTFS_GENERAL;

namespace TFS_API.TFS.Templates
{
	public class Microsoft_Visual_Studio_Scrum_10_Template : ITemplateMapper
	{
		private const string microsoftVstsSchedulingEffort = "Microsoft.VSTS.Scheduling.Effort";
		private const string microsoftVstsCommonBacklogpriority = "Microsoft.VSTS.Common.BacklogPriority";

		#region ITemplateMapper Members

		public bool CopyAttributes(Story pivotalstorySource, WorkItem destinationWorkItem)
		{
			destinationWorkItem.Fields[microsoftVstsSchedulingEffort].Value = pivotalstorySource.Estimate;
			destinationWorkItem.Fields[microsoftVstsCommonBacklogpriority].Value = pivotalstorySource.Priority;
			return true;
		}

		public string TemplateName()
		{
			return "Microsoft Visual Studio Scrum 1.0";
		}

		#endregion
	}
}