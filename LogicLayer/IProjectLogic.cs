using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer
{
    public interface IProjectLogic
    {
        List<ProjectModel> GetAllProjects();
        void AddProject(ProjectModel project);
        ProjectModel GetProjectById(int id);
        void EditProject(ProjectModel project);
        void DeleteProject(int id);
    }
}
