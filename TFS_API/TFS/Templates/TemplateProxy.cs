using System.Collections.Generic;
using System.Linq;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using PivotalTFS_GENERAL;

namespace TFS_API.TFS.Templates
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
        	return (from templateMapper in templates.Values
        	        where IsCreatedFromTemplate(destination, templateMapper)
        	        select templateMapper.CopyAttributes(source, destination)).FirstOrDefault();
        }

    	private static bool IsCreatedFromTemplate(WorkItem destination, ITemplateMapper templateMapper)
        {
            return destination.DisplayForm.Contains(templateMapper.TemplateName());
        }
    }
}