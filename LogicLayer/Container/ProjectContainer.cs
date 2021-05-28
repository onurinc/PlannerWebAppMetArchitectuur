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

        public List<ProjectModel> GetAllProjects()
        {
            ProjectsRepository repo = new ProjectsRepository(context);
            List <ProjectModel> projects = new List<ProjectModel>();

            var projectdto = repo.GetAllProjects();

            foreach (var dto in projectdto)
            {
                projects.Add(new ProjectModel(dto) );
            }
            return projects;
        }

        public ProjectModel GetProjectById(int id)
        {
            ProjectsRepository repo = new ProjectsRepository(context);
            var project = repo.GetProject(id);
            ProjectModel projectDAO = new ProjectModel(project);
            return projectDAO;
        }

        //public void AddProject(ProjectDAO project)
        //{
        //    ProjectsRepository.AddProject(project);
        //}

    }
}
