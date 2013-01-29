using System.Collections.Generic;

namespace PivotalTFSSync.Pivotal
{
    public interface IPivotal
    {
        string AddStory(Project project, Pivotal.IterationVersion iteration, Story pivotalstory);

        Project GetProjectById(int id);
        Project GetProjectByName(string name);
        IEnumerable<Project> GetAllProjects();
        IEnumerable<Iteration> GetIteration(Project project, Pivotal.IterationVersion iterationToRetrieve);
        IEnumerable<Story> GetStoriesByFilter(Project project, string filter);
        void SaveStory(Project project, Story story);
    }
}