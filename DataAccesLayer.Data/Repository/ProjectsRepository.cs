using System.Collections.Generic;
using System.Linq;
using DataAccesLayer.Data.InterfaceRepository;

namespace DataAccesLayer.Data
{
    public class ProjectsRepository : IProjectsRepository
    {
        private IProjectsContext _context;

        public ProjectsRepository(IProjectsContext context)
        {
            this._context = context;
        }

        public List<ProjectsDTO> GetAllProjects()
        {
           return _context.GetAllProjects().ToList();
        }

        public ProjectsDTO GetProject(int id)
        {
            return _context.GetProject(id);
        }

        public void AddProject(ProjectsDTO project)
        {
            _context.AddProject(project);
        }

        public void EditProject(ProjectsDTO project)
        {
            _context.EditProject(project);
        }

        public void DeleteProject(int id)
        {
            _context.DeleteProject(id);
        }
    }
}
