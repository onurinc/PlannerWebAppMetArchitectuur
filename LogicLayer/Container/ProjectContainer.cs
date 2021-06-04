using System.Collections.Generic;
using DataAccesLayer.Data;
using DataAccesLayer.Data.InterfaceRepository;
using LogicLayer.DAO;
using LogicLayer.InterfaceContainer;

namespace LogicLayer.Container
{
    public class ProjectContainer : IProjectContainer
    {
        private readonly IProjectsRepository projectRepo;

        public ProjectContainer(IProjectsRepository projectRepo)
        {
            this.projectRepo = projectRepo;
        }

        public List<ProjectModel> GetAllProjects()
        {
            List <ProjectModel> projects = new List<ProjectModel>();

            var projectdto = projectRepo.GetAllProjects();

            foreach (var dto in projectdto)
            {
                projects.Add(new ProjectModel(dto) );
            }
            return projects;
        }

        public ProjectModel GetProjectById(int id)
        {
            var project = projectRepo.GetProject(id);
            ProjectModel projectModel = new ProjectModel(project);
            return projectModel;
        }

        public void AddProject(string projectName)
        {
            projectRepo.AddProject(new ProjectsDTO() { ProjectName = projectName});
        }

        public void EditProject(int id, string projectName)
        {
            projectRepo.EditProject(new ProjectsDTO() { ProjectId = id, ProjectName = projectName });
        }

        public void DeleteProject(int id)
        {
            projectRepo.DeleteProject(id);
        }

    }
}
