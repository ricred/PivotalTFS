using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.TeamFoundation.WorkItemTracking.Client;

namespace PivotalTFSSync.TFS.Templates
{
    public class Conchango_Template:ITemplateMapper
    {
        private const string ConchangoTeamsystemScrumEstimatedeffort = "Conchango.TeamSystem.Scrum.EstimatedEffort";
        private const string ConchangoTeamsystemScrumBusinesspriority = "Conchango.TeamSystem.Scrum.BusinessPriority";
        private const string ConchangoTeamsystemScrumDeliveryorder = "Conchango.TeamSystem.Scrum.DeliveryOrder";

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
    }
}
