using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer.Data;
using LogicLayer.DAO;

namespace LogicLayer.Container
{
    public class ProjectContainer
    {
        private ProjectsContext context = new ProjectsContext();

        public List<ProjectDAO> GetAllProjects()
        {
            ProjectsRepository repo = new ProjectsRepository(context);
            List <ProjectDAO> projects = new List<ProjectDAO>();

            var projectdto = repo.GetAllProjects();

            foreach (var dto in projectdto)
            {
                projects.Add(new ProjectDAO(dto) );
            }
            return projects;
        }

        public ProjectDAO GetProjectById(int id)
        {
            ProjectsRepository repo = new ProjectsRepository(context);
            var project = repo.GetProject(id);
            ProjectDAO projectDAO = new ProjectDAO(project);
            return projectDAO;
        }
    }
}
