using System;
using System.Collections.Generic;
using System.Linq;
using DataAccesLayer.Data.InterfaceRepository;
using System.Text;
using DataAccesLayer.Data.MockContext;

namespace DataAccesLayer.Data
{
    public class ProjectsRepository : IProjectsRepository
    {
        private IProjectsContext context;

        private IProjectsContext mockContext;

        public ProjectsRepository(IProjectsContext context)
        {
            this.context = context;
            this.context = mockContext;
        }

        public ProjectsRepository()
        {
            mockContext = new MockProjectsContext();
        }

        public List<ProjectsDTO> GetAllProjects()
        {
           return context.GetAllProjects().ToList();
        }

        public ProjectsDTO GetProject(int id)
        {
            return context.GetProject(id);
        }

        public void AddProject(ProjectsDTO project)
        {
            context.AddProject(project);
        }

        public void EditProject(ProjectsDTO project)
        {
            context.EditProject(project);
        }

        public void DeleteProject(int id)
        {
            context.DeleteProject(id);
        }
    }
}
