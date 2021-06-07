using LogicLayer.DAO;
using System.Collections.Generic;

namespace LogicLayer.InterfaceContainer
{
    public interface IProjectContainer
    {
        public List<ProjectModel> GetAllProjects();

        public ProjectModel GetProjectById(int id);

        public void AddProject(int userId, string projectName, string projectDescription);

        public void EditProject(int id, int userId, string projectName, string projectDescription);

        public void DeleteProject(int id);

    }
}
