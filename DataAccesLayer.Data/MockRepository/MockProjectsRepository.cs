using System;
using System.Collections.Generic;
using DataAccesLayer.Data.InterfaceRepository;

namespace DataAccesLayer.Data.MockRepository
{
    class MockProjectsRepository : IProjectsRepository
    {
        private IProjectsContext context;

        public MockProjectsRepository(IProjectsContext context)
        {
            this.context = context;
        }

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
