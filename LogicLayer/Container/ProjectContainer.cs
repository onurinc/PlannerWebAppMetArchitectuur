using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
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
            ProjectModel projectModel = new ProjectModel(project);
            return projectModel;
        }

        public void AddProject(string projectName)
        {
            ProjectsRepository repo = new ProjectsRepository(context);
            repo.AddProject(new ProjectsDTO() { ProjectName = projectName});
        }

        public void EditProject(int id, string projectName)
        {
            ProjectsRepository repo = new ProjectsRepository(context);
            repo.EditProject(new ProjectsDTO() { ProjectId = id, ProjectName = projectName });
        }

        public void DeleteProject(int id)
        {
            ProjectsRepository repo = new ProjectsRepository(context);
            repo.DeleteProject(id);
        }

    }
}
