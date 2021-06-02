using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccesLayer.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataAccessLayer.Test
{
    [TestClass]
    public class TestProjectContext
    {
        [TestMethod] 
        public void TestProjectContainer_Get_All_Projects()
        {
            // Arrange 
            ProjectsContext pContext = new ProjectsContext();
            IEnumerable<ProjectsDTO> projectsOne = new List<ProjectsDTO>();
            IEnumerable<ProjectsDTO> projectsTwo = new List<ProjectsDTO>();
            // Act

            projectsOne = pContext.GetAllProjects();
            projectsTwo = pContext.GetAllProjects();

            // Assert
            Assert.AreEqual(projectsOne, projectsTwo);
        }

        [TestMethod]
        public void TestProjectContainer_Add_Project()
        {
            // Arrange 
            ProjectsContext pContext = new ProjectsContext();
            IEnumerable<ProjectsDTO> projects = new List<ProjectsDTO>();
            ProjectsDTO project = new ProjectsDTO()
            {
                ProjectName = "Project from Unit Test in TestProjectsContext"
            };

            // Act
            pContext.AddProject(project);
            projects = pContext.GetAllProjects();
            var lastProject = projects.Last();

            // Assert
            Assert.AreEqual (lastProject, "Project from Unit Test in TestProjectsContext");
        }

        [TestMethod]
        public void TestProjectContainer_Get_Project_By_Id()
        {
            // Arrange 
            ProjectsContext pContext = new ProjectsContext();
            IEnumerable<ProjectsDTO> projects = new List<ProjectsDTO>();
            List<ProjectsDTO> projectsListTwo = projects.ToList();

            // Act
            pContext.GetProject(1);
            projectsListTwo.Add(pContext.GetProject(24));

            // Assert
            Assert.AreEqual(projectsListTwo.Count(), 1);
        }

        [TestMethod]
        public void TestProjectContainer_Edit_Project()
        {
            // Arrange 
            ProjectsContext pContext = new ProjectsContext();
            IEnumerable<ProjectsDTO> projects = new List<ProjectsDTO>();
            List<ProjectsDTO> projectsListTwo = projects.ToList();

            // Act
            pContext.EditProject(new ProjectsDTO() { ProjectId = 45, ProjectName = "Project edited by Unit Test in TestProjectsContext" });
            projectsListTwo.Add(pContext.GetProject(45));
            var lastProject = projectsListTwo.Last();

            // Assert
            Assert.AreEqual(lastProject.ProjectName, "Project edited by Unit Test in TestProjectsContext");
        }

        [TestMethod]
        public void TestProjectContainer_Delete_Project()
        {
            // Arrange 
            ProjectsContext pContext = new ProjectsContext();

            // Act
            pContext.DeleteProject(44);
            var test = pContext.GetProject(44);

            // Assert
            Assert.AreEqual(null, test );
        }

    }
}
