using DataAccesLayer.Data;
using LogicLayer.DAO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer.InterfaceContainer
{
    public interface IProjectContainer
    {
        public List<ProjectModel> GetAllProjects();

        public ProjectModel GetProjectById(int id);

        public void AddProject(string projectName);

        public void EditProject(int id, string projectName);

        public void DeleteProject(int id);


    }
}
