using System;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using PivotalTFS_GENERAL;

namespace TFS_API.TFS.Templates
{
    public class MSF_For_AgileDevelopment_v50_Template : ITemplateMapper
    {
        #region ITemplateMapper Members

        public bool CopyAttributes(Story pivotalstorySource, WorkItem destinationWorkItem)
        {
            throw new NotImplementedException();
        }

        public string TemplateName()
        {
            return "MSF for Agile Software Development v5.0";
        }

        #endregion
    }
}