using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.TeamFoundation.WorkItemTracking.Client;

namespace PivotalTFSSync.TFS.Templates
{
    public class TemplateProxy
    {
        private Dictionary<string, ITemplateMapper> templates;
        public TemplateProxy()
        {
            //TODO: howto detect which tfs template that is used for this project???? 
            //can cut most of this stuff away then.. 
            templates = new Dictionary<string, ITemplateMapper>();
            var conchango = new Conchango_Template();
            templates.Add(conchango.TemplateName(), conchango);
            var msScrum = new Microsoft_Visual_Studio_Scrum_10_Template();
            templates.Add(msScrum.TemplateName(), msScrum);
            var msf = new MSF_For_AgileDevelopment_v50_Template();
            templates.Add(msf.TemplateName(), msf);

        }
        public bool CopyPivotalStoryValuesToWorkItem(Story source, WorkItem destination)
        {
            foreach (var templateMapper in templates.Values)
            {
                if (IsCreatedFromTemplate(destination, templateMapper))
                {
                    return templateMapper.CopyAttributes(source, destination);

                }
            }
            return false;
        }

        private static bool IsCreatedFromTemplate(WorkItem destination, ITemplateMapper templateMapper)
        {
            return destination.DisplayForm.Contains(templateMapper.TemplateName());
        }
    }
}