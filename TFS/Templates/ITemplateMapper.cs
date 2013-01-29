using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.TeamFoundation.WorkItemTracking.Client;

namespace PivotalTFSSync.TFS.Templates
{
   public interface ITemplateMapper
   {
       bool CopyAttributes(Story pivotalstorySource, WorkItem destinationWorkItem);
       string TemplateName();
   }
}
