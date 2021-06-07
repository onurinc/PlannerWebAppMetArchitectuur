using System.Collections.Generic;

namespace DataAccesLayer.Data.InterfaceRepository
{
    public interface IProjectsRepository
    {
        public List<ProjectsDTO> GetAllProjects();

        public ProjectsDTO GetProject(int id);

        public void AddProject(ProjectsDTO project);

        public void EditProject(ProjectsDTO project);

        public void DeleteProject(int id);

    }
}
