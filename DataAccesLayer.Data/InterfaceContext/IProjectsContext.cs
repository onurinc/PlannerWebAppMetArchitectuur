using System.Collections.Generic;

namespace DataAccesLayer.Data
{
    public interface IProjectsContext
    {
        IEnumerable<ProjectsDTO> GetAllProjects();

        ProjectsDTO GetProject(int id);

        void EditProject(ProjectsDTO project);

        public void AddProject(ProjectsDTO project);

        public void DeleteProject(int id);
    }

}
