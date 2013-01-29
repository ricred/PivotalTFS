using System.Collections.Generic;
using PivotalTFS_GENERAL;

namespace PIVOTAL_API
{
    public interface IPivotal
    {
        string AddStory(Project project, Pivotal.IterationVersion iteration, Story pivotalstory);

        Project GetProjectById(int id);
        Project GetProjectByName(string name);
        IEnumerable<Project> GetAllProjects();
        IEnumerable<Iteration> GetIteration(Project project, Pivotal.IterationVersion iterationToRetrieve);
		IEnumerable<Iteration> GetIteration(int projectId, Pivotal.IterationVersion iterationToRetrieve);
		IEnumerable<Story> GetStoriesByFilter(Project project, string filter);
	 	void SaveStory(Project project, Story story);
    	void UpdatePivotalStoryStatus(Project project, Story story);
    }
}