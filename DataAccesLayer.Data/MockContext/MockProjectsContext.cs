using System;
using System.Collections.Generic;

namespace DataAccesLayer.Data.MockContext
{
    public class MockProjectsContext : IProjectsContext
    {
        public List<ProjectsDTO> MockProjectsList = new List<ProjectsDTO>();

        public MockProjectsContext()
        { 
            //ProjectsDTO projectOne = new ProjectsDTO(projectId: 1, projectName: "ProjectOne");
            //ProjectsDTO projectTwo = new ProjectsDTO(projectId: 2, projectName: "ProjectTwo");

            //MockProjectsList.Add(projectOne);
            //MockProjectsList.Add(projectTwo);
        }

        public void AddProject(ProjectsDTO project)
        {
            ProjectsDTO lastProjectInList = MockProjectsList[MockProjectsList.Count - 1];
            project.ProjectId = lastProjectInList.ProjectId + 1;
            MockProjectsList.Add(project);
        }

        public void DeleteProject(int id)
        {
            throw new NotImplementedException();
        }

        public void EditProject(ProjectsDTO project)
        {
            foreach (var p in MockProjectsList)
            {
                if (p.ProjectId == project.ProjectId)
                {
                    int pIndex = MockProjectsList.IndexOf(p);
                    MockProjectsList[pIndex] = project;
                    break;
                }
            }
        }

        public IEnumerable<ProjectsDTO> GetAllProjects()
        {
            return MockProjectsList;
        }

        public ProjectsDTO GetProject(int id)
        {
            foreach (var p in MockProjectsList)
            {
                if (p.ProjectId == id)
                {
                    return p;
                }
            }
            return null;
        }
    }
}
