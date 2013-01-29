using Microsoft.TeamFoundation.WorkItemTracking.Client;
using PivotalTFS_GENERAL;

namespace TFS_API.TFS.Templates
{
	public class Conchango_Template : ITemplateMapper
	{
		private const string ConchangoTeamsystemScrumEstimatedeffort = "Conchango.TeamSystem.Scrum.EstimatedEffort";
		private const string ConchangoTeamsystemScrumBusinesspriority = "Conchango.TeamSystem.Scrum.BusinessPriority";
		private const string ConchangoTeamsystemScrumDeliveryorder = "Conchango.TeamSystem.Scrum.DeliveryOrder";

		#region ITemplateMapper Members

		public bool CopyAttributes(Story pivotalstorySource, WorkItem destinationWorkItem)
		{
			destinationWorkItem.Fields[ConchangoTeamsystemScrumEstimatedeffort].Value = pivotalstorySource.Estimate;
			destinationWorkItem.Fields[ConchangoTeamsystemScrumBusinesspriority].Value = pivotalstorySource.Priority;
			destinationWorkItem.Fields[ConchangoTeamsystemScrumDeliveryorder].Value = pivotalstorySource.Priority;
			return true;
		}

		public string TemplateName()
		{
			return "Conchango"; //TODO: Return the correct string here. 
		}

		#endregion
	}
}