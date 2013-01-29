using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.TeamFoundation.WorkItemTracking.Client;

namespace PivotalTFSSync.TFS.Templates
{
   public class Microsoft_Visual_Studio_Scrum_10_Template:ITemplateMapper
    {
        const string microsoftVstsSchedulingEffort = "Microsoft.VSTS.Scheduling.Effort";
        const string microsoftVstsCommonBacklogpriority = "Microsoft.VSTS.Common.BacklogPriority";
       
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
    }
}
