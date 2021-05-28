using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccesLayer.Data
{
    public class ProjectsRepository
    {
        private IProjectsContext context;

        public ProjectsRepository(IProjectsContext context)
        {
            this.context = context;
        }

        public ProjectsRepository()
        {
            this.context = new ProjectsContext();
        }

        public List<ProjectsDTO> GetAllProjects()
        {
           return context.GetAllProjects().ToList();
        }

        public ProjectsDTO GetProject(int id)
        {
            return context.GetProject(id);
        }
    }
}
