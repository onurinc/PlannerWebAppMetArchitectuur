using System;
using System.Collections.Generic;

namespace DataAccesLayer.Data.MockContext
{
    
    public class MockProjectsContext : IProjectsContext
    {
        List<ProjectsDTO> projectsList = new List<ProjectsDTO>();

        public MockProjectsContext()
        { 
            ProjectsDTO projectOne = new ProjectsDTO(projectId: 1, projectName: "ProjectOne");
            ProjectsDTO projectTwo = new ProjectsDTO(projectId: 2, projectName: "ProjectTwo");

            projectsList.Add(projectOne);
            projectsList.Add(projectTwo);
        }

        public void AddProject(ProjectsDTO project)
        {
            ProjectsDTO lastProjectInList = projectsList[projectsList.Count - 1];
            project.ProjectId = lastProjectInList.ProjectId + 1;
            projectsList.Add(project);
        }

        public void DeleteProject(int id)
        {
            throw new NotImplementedException();
        }

        public void EditProject(ProjectsDTO project)
        {
            foreach (var p in projectsList)
            {
                if (p.ProjectId == project.ProjectId)
                {
                    int pIndex = projectsList.IndexOf(p);
                    projectsList[pIndex] = project;
                    break;
                }
            }
        }

        public IEnumerable<ProjectsDTO> GetAllProjects()
        {
            return projectsList;
        }

        public ProjectsDTO GetProject(int id)
        {
            foreach (var p in projectsList)
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
