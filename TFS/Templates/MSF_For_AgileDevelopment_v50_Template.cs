using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.TeamFoundation.WorkItemTracking.Client;

namespace PivotalTFSSync.TFS.Templates
{
  public  class MSF_For_AgileDevelopment_v50_Template : ITemplateMapper
    {
        public bool CopyAttributes(Story pivotalstorySource, WorkItem destinationWorkItem)
        {
            throw new NotImplementedException();
        }

        public string TemplateName()
        {
            return "MSF for Agile Software Development v5.0";
        }
    }
}
