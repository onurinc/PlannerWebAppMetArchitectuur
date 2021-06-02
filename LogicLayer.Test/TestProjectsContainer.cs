using System;
using System.Collections.Generic;
using System.Linq;
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
            List<ProjectModel> projectsListOne = new List<ProjectModel>();
            List<ProjectModel> projectsListTwo = new List<ProjectModel>();

            // Act
            projectsListOne = pContainer.GetAllProjects();
            projectsListTwo = pContainer.GetAllProjects();

            // Assert
            Assert.AreEqual(projectsListOne.Count, projectsListTwo.Count);
        }

        [TestMethod]
        public void TestProjectContainer_Add_Project()
        {
            // Arrange 
            ProjectContainer pContainer = new ProjectContainer();
            List<ProjectModel> projects = new List<ProjectModel>();

            // Act
            pContainer.AddProject("projectOne");
            projects = pContainer.GetAllProjects();
            var lastProject = projects.Last();

            // Assert
            Assert.AreEqual(lastProject.Name, "projectOne");
        }

        [TestMethod]
        public void TestProjectContainer_Edit_Project()
        {
            // Arrange 
            ProjectContainer pContainer = new ProjectContainer();
            List<ProjectModel> projects = new List<ProjectModel>();

            // Act
            pContainer.EditProject(32, "Test");
            projects.Add(pContainer.GetProjectById(32));
            var lastProject = projects.Last();
 
            // Assert
            Assert.AreEqual(lastProject.Name, "Test");
        }

        [TestMethod]
        public void TestProjectContainer_Get_Project_By_Id()
        {
            // Arrange 
            ProjectContainer pContainer = new ProjectContainer();
            List<ProjectModel> projects = new List<ProjectModel>();

            // Act
            projects.Add(pContainer.GetProjectById(24));

            // Assert
            Assert.AreEqual(projects.Count, 1);
        }

        [TestMethod]
        public void TestProjectContainer_Delete_Project_By_Id()
        {
            // Arrange 
            ProjectContainer pContainer = new ProjectContainer();
            List<ProjectModel> projects = new List<ProjectModel>();
            bool deleted;

            // Act
            try
            {
                pContainer.DeleteProject(44);
                deleted = true;
            }
            catch (Exception)
            {
                deleted = false;
            }

            // Assert
            Assert.IsTrue(deleted);
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
