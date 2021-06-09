using System.Collections.Generic;
using System.Linq;
using DataAccesLayer.Data.InterfaceRepository;

namespace DataAccesLayer.Data
{
    public class ProjectsRepository : IProjectsRepository
    {
        private readonly IProjectsContext _projectsContext;

        public ProjectsRepository(IProjectsContext projectsContext)
        {
            this._projectsContext = projectsContext;
        }

        public List<ProjectsDTO> GetAllProjects()
        {
           return _projectsContext.GetAllProjects().ToList();
        }

        public ProjectsDTO GetProject(int id)
        {
            return _projectsContext.GetProject(id);
        }

        public void AddProject(ProjectsDTO project)
        {
            _projectsContext.AddProject(project);
        }

        public void EditProject(ProjectsDTO project)
        {
            _projectsContext.EditProject(project);
        }

        public void DeleteProject(int id)
        {
            _projectsContext.DeleteProject(id);
        }
    }
}
