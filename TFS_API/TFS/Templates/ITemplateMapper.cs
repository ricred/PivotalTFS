using Microsoft.TeamFoundation.WorkItemTracking.Client;
using PivotalTFS_GENERAL;

namespace TFS_API.TFS.Templates
{
	public interface ITemplateMapper
	{
		bool CopyAttributes(Story pivotalstorySource, WorkItem destinationWorkItem);
		string TemplateName();
	}
}