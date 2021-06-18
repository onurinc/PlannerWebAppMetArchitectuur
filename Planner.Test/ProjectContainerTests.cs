using System;
using System.Collections.Generic;
using System.Linq;
using DataAccesLayer.Data;
using DataAccesLayer.Data.InterfaceRepository;
using LogicLayer.Container;
using LogicLayer.DAO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Planner.Test
{
    [TestClass]
    public class ProjectContainerTests
    {
        private readonly ProjectContainer _projectContainer;

        private readonly Mock<IProjectsRepository> _mockProjectsRepository = new Mock<IProjectsRepository>();

        public ProjectContainerTests()
        {
            _projectContainer = new ProjectContainer(_mockProjectsRepository.Object);
        }

        List<ProjectsDTO> ProjectList = new List<ProjectsDTO>
        {
            new ProjectsDTO()
            {
                ProjectId = 1, ProjectName = "ProjectOne", ProjectDescription = "ProjectOne Description"
            },
            new ProjectsDTO()
            {
                ProjectId = 2, ProjectName = "ProjectTwo", ProjectDescription = "ProjectTwo Description"
            }
        };

        [TestMethod]
        public void GetProject_ShouldReturnProject_WhenProjectExists()
        {
            // Arrange
            _mockProjectsRepository.Setup(x => x.GetProject(It.IsAny<int>()))
                .Returns((int i) => ProjectList.Single(x => x.ProjectId == i));

            // Act
            var project = _projectContainer.GetProjectById(2);

            // Assert
            Assert.IsInstanceOfType(project, typeof(ProjectModel));
            Assert.AreEqual(2, project.ProjectId);
            Assert.AreEqual(project.ProjectName, "ProjectTwo");
        }

        [TestMethod]
        public void GetAllProjects_ShouldReturnProjects_IfThereAreProjects()
        {
            // Arrange
            List<ProjectModel> ProjectListOne = new List<ProjectModel>();
            List<ProjectModel> ProjectListTwo = new List<ProjectModel>();
            _mockProjectsRepository.Setup(x => x.GetAllProjects()).Returns(ProjectList);

            // Act
            ProjectListOne = _projectContainer.GetAllProjects();
            // ProjectListTwo = _projectContainer.GetAllProjects();


            // Assert
            Assert.AreEqual(2, ProjectListOne.Count);
            // Assert.AreEqual(ProjectListTwo, ProjectListOne.Count);
        }

        [TestMethod]
        public void AddProject_ShouldAddAProject_WhenALegitimateProjectIsGiven()
        {
            // Arrange
            _mockProjectsRepository.Setup(x => x.AddProject(It.IsAny<ProjectsDTO>())).Callback(
                (ProjectsDTO project) =>
                {
                    if (project.ProjectId.Equals(default(int)))
                    {
                        project.ProjectId = ProjectList.Count() + 1;
                        ProjectList.Add(project);
                    }
                    else
                    {
                        throw new Exception(
                            "Project can not be added, make sure you enter the corresponding information");
                    }
                });

            // Act
            _projectContainer.AddProject(3, "ProjectThree", "ProjectThreeDescription");
            var addedProject = ProjectList.Last();

            // Assert
            Assert.IsInstanceOfType(addedProject, typeof(ProjectsDTO));
            Assert.AreEqual(3, addedProject.ProjectId);
            Assert.AreEqual("ProjectThree", addedProject.ProjectName);
            Assert.AreEqual("ProjectThreeDescription", addedProject.ProjectDescription);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ShouldThrowException_IfFalseProjectIsGiven()
        {
            // Arrange
            _mockProjectsRepository.Setup(x => x.AddProject(It.IsAny<ProjectsDTO>())).Callback(
                (ProjectsDTO project) =>
                {
                    if (project.ProjectId.Equals(default(int)))
                    {
                        project.ProjectId = ProjectList.Count() + 1;
                        ProjectList.Add(project);
                    }
                    else
                    {
                        throw new Exception(
                            "Project can not be added, make sure you enter the corresponding information");
                    }
                });

            // Act
            _projectContainer.AddProject(Int32.Parse("numberThree"), "ProjectThree", "ProjectThreeDescription");
            var addedProject = ProjectList.Last();

            // Assert

        }

        //[TestMethod]
        //public void DeleteProject_IfProjectExists()
        //{
        //    // Arrange
        //    var projects = new List<ProjectsDTO>
        //    {
        //        new ProjectsDTO()
        //        {
        //            ProjectId = 1, ProjectName = "ProjectOne", ProjectDescription = "ProjectOne Description"
        //        },
        //        new ProjectsDTO()
        //        {
        //            ProjectId = 2, ProjectName = "ProjectTwo", ProjectDescription = "ProjectTwo Description"
        //        }
        //    };

        //    //_mockProjectsRepository.Setup(x => x.DeleteProject(It.IsAny<int>())).Callback<ProjectsDTO>((entity) => ProjectList.Remove(entity));
        //    _mockProjectsRepository.Setup(x => x.DeleteProject(It.IsAny<int>())).Callback<ProjectsDTO>((entity) => projects.Remove(entity));
        //    _mockProjectsRepository.Setup(x => x.GetAllProjects()).Returns(ProjectList);
        //    List<ProjectModel> ProjectListForCheck = new List<ProjectModel>();
        //    int projectToDelete = 1;

        //    // Act
        //    _projectContainer.DeleteProject(projectToDelete);
        //    ProjectListForCheck = _projectContainer.GetAllProjects();

        //    // Assert
        //    Assert.AreEqual(ProjectListForCheck.Count, 1);
        //}

        //[TestMethod]
        //public void EditProject_ShouldEdit_IfLegitimateInformationIsEntered()
        //{
        //    // Arrange

        //    // Act


        //    // Assert
        //}
    }
}
