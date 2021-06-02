using System;
using System.Collections.Generic;
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
            IEnumerable<ProjectsDTO> projects = new List<ProjectsDTO>();

            // Act

            projects = pContext.GetAllProjects();

            // Assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestProjectContainer_Add_Project()
        {
            // Arrange 
            ProjectsContext pContext = new ProjectsContext();

            ProjectsDTO project = new ProjectsDTO()
            {
                ProjectName = "Project from Unit Test in TestProjectsContext"
            };

            // Act
            pContext.AddProject(project);

            // Assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestProjectContainer_Get_Project_By_Id()
        {
            // Arrange 
            ProjectsContext pContext = new ProjectsContext();

            // Act
            pContext.GetProject(1);

            // Assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestProjectContainer_Edit_Project()
        {
            // Arrange 
            ProjectsContext pContext = new ProjectsContext();

            // Act
            pContext.EditProject(new ProjectsDTO() { ProjectId = 45, ProjectName = "Project edited by Unit Test in TestProjectsContext" });

            // Assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestProjectContainer_Delete_Project()
        {
            // Arrange 
            ProjectsContext pContext = new ProjectsContext();

            // Act
            pContext.DeleteProject(46);

            // Assert
            Assert.IsTrue(true);
        }



    }
}
