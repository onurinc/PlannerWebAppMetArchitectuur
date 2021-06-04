﻿using System;
using System.Collections.Generic;
using System.Linq;
using DataAccesLayer.Data;
using DataAccesLayer.Data.InterfaceRepository;
using DataAccesLayer.Data.MockContext;
using DataAccesLayer.Data.MockRepository;
using LogicLayer.Container;
using LogicLayer.DAO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlannerWebApp.Test.LogicLayer.Test
{
    [TestClass]
    public class TestProjectsContainer
    {
        private readonly IProjectsRepository mockRepo;

        public TestProjectsContainer(IProjectsRepository mockRepo)
        {
            this.mockRepo = mockRepo;
        }

        public TestProjectsContainer()
        {
            mockRepo = new MockProjectsRepository();
        }

        //public TestProjectsContainer()
        //{
        //    mockRepo = new ProjectsRepository();
        //}

        [TestMethod]
        public void TestProjectContainer_Add_Project()
        {
            // Arrange 
            IEnumerable<ProjectsDTO> projects = new List<ProjectsDTO>();
            ProjectsDTO project = new ProjectsDTO()
            {
                ProjectName = "TestProject"
            };

            // Act
            mockRepo.AddProject(project);
            projects = mockRepo.GetAllProjects();
            var lastProject = projects.Last();

            // Assert
            Assert.AreEqual(lastProject.ProjectName, "TestProject");
        }

        [TestMethod]
        public void TestProjectContainer_Get_Project()
        {
            // Arrange 
            IEnumerable<ProjectsDTO> projects = new List<ProjectsDTO>();
            List<ProjectsDTO> projectsListTwo = projects.ToList();

            // Act
            mockRepo.GetProject(1);
            projectsListTwo.Add(mockRepo.GetProject(1));

            // Assert
            Assert.AreEqual(projectsListTwo.Count(), 1);
        }

        [TestMethod]
        public void TestProjectContainer_Edit_Project()
        {
            // Arrange 
            IEnumerable<ProjectsDTO> projects = new List<ProjectsDTO>();
            List<ProjectsDTO> projectsListTwo = projects.ToList();

            // Act
            mockRepo.EditProject(new ProjectsDTO() { ProjectId = 2, ProjectName = "Project edited by Unit Test" });
            projectsListTwo.Add(mockRepo.GetProject(2));
            var lastProject = projectsListTwo.Last();

            // Assert
            Assert.AreEqual(lastProject.ProjectName, "Project edited by Unit Test");
        }

        //[TestMethod]
        //public void TestProjectContainer_Get_All_Projects()
        //{
        //    // Arrange 
        //    MockProjectsContext mockContext = new MockProjectsContext();
        //    List<ProjectsDTO> ListOfProjects = new List<ProjectsDTO>();

        //    // Act
        //    ListOfProjects = mockRepo.GetAllProjects();

        //    // Assert
        //    Assert.AreEqual(ListOfProjects, mockContext.MockProjectsList);
        //}
    }
}
