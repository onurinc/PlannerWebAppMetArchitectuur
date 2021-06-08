using System.Collections.Generic;
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
        private readonly Mock<IProjectsRepository> _projectRepoMock = new Mock<IProjectsRepository>();

        public ProjectContainerTests()
        {
            _projectContainer = new ProjectContainer(_projectRepoMock.Object);
        }

        [TestMethod]
        public void GetProject_ShouldReturnProject_WhenProjectExists()
        {
            // Arrange
            var projectId = 1;
            var projectName = "ProjectOne";
            var projectsDtoOne = new ProjectsDTO
            {
                ProjectId = projectId,
                ProjectName = projectName
            };

            _projectRepoMock.Setup(x => x.GetProject(projectId)).Returns(projectsDtoOne);

            // Act
            var project = _projectContainer.GetProjectById(projectId);

            // Assert
            Assert.AreEqual(projectId, project.ProjectId);
            Assert.AreEqual(projectName, project.ProjectName);
        }

        [TestMethod]
        public void GetAllProjects_ShouldReturnProjects()
        {
            // Arrange
            List<ProjectModel> projectListTwo = new List<ProjectModel>();
            List<ProjectsDTO> projectListOne = new List<ProjectsDTO>();
            projectListOne.Add(new ProjectsDTO()
            {
                ProjectId = 1,
                ProjectName = "ProjectOne",
                ProjectDescription = "ProjectOne Description"
            });
            projectListOne.Add(new ProjectsDTO()
            {
                ProjectId = 2,
                ProjectName = "ProjectTwo",
                ProjectDescription = "ProjectTwo Description"
            });

            _projectRepoMock.Setup(x => x.GetAllProjects()).Returns(projectListOne);

            // Act
            projectListTwo = _projectContainer.GetAllProjects();

            // Assert
            Assert.AreEqual(projectListTwo.Count, 2);
        }

        //[TestMethod]
        //public void AddProject_ShouldAddAProject_WhenALegitProjectIsGiven()
        //{
        //    // Arrange
        //    _projectRepoMock.Setup(x => x.AddProject(It.IsAny<ProjectsDTO>()));

        //    // Act
        //    _projectContainer.AddProject(1, "ProjectOne", "ProjectOneDescription");

        //    // Assert
        //    Assert.AreEqual();
        //}

        //[TestMethod]
        //public void GetProject_ShouldReturnNothing_WhenProjectDoesNotExist()
        //{
        //    // Arrange
        //    bool boolCheck;
        //    var projectId = 1;
        //    var projectName = "ProjectOne";
        //    var project = new ProjectsDTO { ProjectId = projectId, ProjectName = projectName };
        //    _projectRepoMock.Setup(x => x.GetProject(projectId)).Returns(project);

        //    // Act
        //    var actualproject = _projectContainer.GetProjectById(projectId + 1);

        //    if (actualproject == null)
        //    {
        //        boolCheck = true;

        //    }
        //    else
        //    {
        //        boolCheck = false;
        //    }
        //    // Assert
        //    Assert.IsTrue(boolCheck);
        //}
    }
}
