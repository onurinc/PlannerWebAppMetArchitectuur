using System;
using System.Collections.Generic;
using System.Linq;
using DataAccesLayer.Data.InterfaceRepository;
using DataAccesLayer.Data.MockContext;

namespace DataAccesLayer.Data.MockRepository
{
    public class MockProjectsRepository : IProjectsRepository
    {
        private IProjectsContext mockContext;

        public MockProjectsRepository()
        {
            mockContext = new MockProjectsContext();
        }

        public List<ProjectsDTO> GetAllProjects()
        {
            return mockContext.GetAllProjects().ToList();
        }

        public void AddProject(ProjectsDTO project)
        {
            mockContext.AddProject(project);
        }

        public ProjectsDTO GetProject(int id)
        {
            return mockContext.GetProject(id);
        }

        public void EditProject(ProjectsDTO project)
        {
            mockContext.EditProject(project);
        }

        public void DeleteProject(int id)
        {
            mockContext.DeleteProject(id);
        }


    }
}
