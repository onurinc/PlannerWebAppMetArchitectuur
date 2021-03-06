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
        public void TestProjectContainer_Add_Project()
        {
            // Arrange 
            ProjectsContext pContext = new ProjectsContext();
            IEnumerable<ProjectsDTO> projects = new List<ProjectsDTO>();
            ProjectsDTO project = new ProjectsDTO()
            {
                UserId = 1,
                ProjectName = "Project from Test in TestProjectsContext",
                ProjectDescription = "Test Description from Test in TestProjectsContext"
            };

            // Act
            pContext.AddProject(project);
            projects = pContext.GetAllProjects();
            var lastProject = projects.Last();

            // Assert
            Assert.AreEqual (lastProject.ProjectName, "Project from Test in TestProjectsContext");
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
            projectsListTwo.Add(pContext.GetProject(3));

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
            pContext.EditProject(new ProjectsDTO() { ProjectId = 9, UserId = 1, ProjectName = "Project edited by Test in TestProjectsContext", ProjectDescription = "Project Description Edited By Test"});
            projectsListTwo.Add(pContext.GetProject(9));
            var lastProject = projectsListTwo.Last();

            // Assert
            Assert.AreEqual(lastProject.ProjectName, "Project edited by Test in TestProjectsContext");
        }

        [TestMethod]
        public void TestProjectContainer_Delete_Project()
        {
            // Arrange 
            ProjectsContext pContext = new ProjectsContext();

            // Act
            pContext.DeleteProject(8);
            var test = pContext.GetProject(8);

            // Assert
            Assert.AreEqual(null, test );
        }

        //[TestMethod] 
        //public void TestProjectContainer_Get_All_Projects()
        //{
        //    // Arrange 
        //    ProjectsContext pContext = new ProjectsContext();
        //    IEnumerable<ProjectsDTO> projectsOne = new List<ProjectsDTO>();
        //    IEnumerable<ProjectsDTO> projectsTwo = new List<ProjectsDTO>();
        //    // Act

        //    projectsOne = pContext.GetAllProjects();
        //    projectsTwo = pContext.GetAllProjects();

        //    // Assert
        //    Assert.AreEqual(projectsOne, projectsTwo);
        //}
    }
}
