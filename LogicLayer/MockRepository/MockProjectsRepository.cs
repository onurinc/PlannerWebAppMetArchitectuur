using DataAccesLayer.Data;
using DataAccesLayer.Data.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer.MockRepository
{
    class MockProjectsRepository : IProjectsRepository
    {
        public void AddProject(ProjectsDTO project)
        {
            throw new NotImplementedException();
        }

        public void DeleteProject(int id)
        {
            throw new NotImplementedException();
        }

        public void EditProject(ProjectsDTO project)
        {
            throw new NotImplementedException();
        }

        public List<ProjectsDTO> GetAllProjects()
        {
            throw new NotImplementedException();
        }

        public ProjectsDTO GetProject(int id)
        {
            throw new NotImplementedException();
        }
    }
}
