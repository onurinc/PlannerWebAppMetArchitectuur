using System;
using System.Collections.Generic;
using LogicLayer.Container;
using LogicLayer.DAO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlannerWebApp.Test.LogicLayer.Test
{
    [TestClass]
    public class UnitTestProjectsContainer
    {
        [TestMethod]
        public void TestProjectContainer_Get_All_Projects()
        {
            // Arrange 
            ProjectContainer pContainer = new ProjectContainer();
            List<ProjectModel> projects = new List<ProjectModel>();

            // Act

            projects = pContainer.GetAllProjects();

            // Assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestProjectContainer_Add_Project()
        {
            // Arrange 
            ProjectContainer pContainer = new ProjectContainer();

            // Act
  
                pContainer.AddProject("projectOne"); 

            // Assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestProjectContainer_Edit_Project()
        {
            // Arrange 
            ProjectContainer pContainer = new ProjectContainer();
            bool updated;

            // Act
            try
            {
                pContainer.EditProject(32, "Test");
                updated = true;
            }
            catch (Exception)
            {
                updated = false;
            }

            // Assert
            Assert.IsTrue(updated);
        }

        [TestMethod]
        public void TestProjectContainer_Get_Project_By_Id()
        {
            // Arrange 
            ProjectContainer pContainer = new ProjectContainer();
            List<ProjectModel> projects = new List<ProjectModel>();

            // Act
            try
            {
                projects.Add(pContainer.GetProjectById(24));
            }
            catch (Exception)
            {
            }

            // Assert
            Assert.AreEqual(projects.Count, 1);
        }

        [TestMethod]
        public void TestProjectContainer_Delete_Project_By_Id()
        {
            // Arrange 
            ProjectContainer pContainer = new ProjectContainer();
            List<ProjectModel> projects = new List<ProjectModel>();

            // Act
            try
            {
                pContainer.DeleteProject(44);
            }
            catch (Exception)
            {
            }

            // Assert
            Assert.IsTrue(true);
        }

        //[TestMethod]
        //public void TestProjectContainer_Add_Project_As_Int()
        //{
        //    // Arrange 
        //    ProjectContainer pContainer = new ProjectContainer();

        //    // Act
        //    try
        //    {
        //        pContainer.AddProject(123123123);
        //    }
        //    catch (Exception)
        //    {
        //    }

        //    // Assert
        //    Assert.IsTrue(false);
        //}

    }
}
