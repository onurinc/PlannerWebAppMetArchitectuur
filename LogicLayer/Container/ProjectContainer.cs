using System.Collections.Generic;
using DataAccesLayer.Data;
using DataAccesLayer.Data.InterfaceRepository;
using LogicLayer.DAO;
using LogicLayer.InterfaceContainer;

namespace LogicLayer.Container
{
    public class ProjectContainer : IProjectContainer
    {
        private readonly IProjectsRepository _projectRepo;

        public ProjectContainer(IProjectsRepository projectRepo)
        {
            this._projectRepo = projectRepo;
        }

        public List<ProjectModel> GetAllProjects()
        {
            List <ProjectModel> projects = new List<ProjectModel>();

            var projectdto = _projectRepo.GetAllProjects();

            foreach (var dto in projectdto)
            {
                projects.Add(new ProjectModel(dto) );
            }
            return projects;
        }

        public ProjectModel GetProjectById(int id)
        {
            var project = _projectRepo.GetProject(id);
            ProjectModel projectModel = new ProjectModel(project);
            return projectModel;
        }

        public void AddProject(int userId, string projectName, string projectDescription)
        {
            _projectRepo.AddProject(new ProjectsDTO() { UserId = userId, ProjectName = projectName, ProjectDescription = projectDescription });
        }

        public void EditProject(int id, int userId, string projectName, string projectDescription)
        {
            _projectRepo.EditProject(new ProjectsDTO() { ProjectId = id, UserId = userId, ProjectName = projectName, ProjectDescription = projectDescription});
        }

        public void DeleteProject(int id)
        {
            _projectRepo.DeleteProject(id);
        }

    }
}
