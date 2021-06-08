using System;
using DataAccesLayer.Data;
using DataAccesLayer.Data.InterfaceRepository;
using LogicLayer.Container;
using Moq;
using Xunit;

namespace PlannerWebApp.Test
{
    public class ProjectContainerTests
    {
        private readonly ProjectContainer _projectContainer;
        private readonly Mock<IProjectsRepository> _projectRepoMock = new Mock<IProjectsRepository>();

        public ProjectContainerTests()
        {
            _projectContainer = new ProjectContainer(_projectRepoMock.Object);
        }


        [Fact]
        public void GetProject_ShouldReturnProject_WhenProjectExists()
        {
            // Arrange
            var id = 1;
            var projectsDTO = new ProjectsDTO
            {
                ProjectId = 1,
                ProjectName = "ProjectOne"
            };

            _projectRepoMock.Setup(x => x.GetProject(id)).Returns(projectsDTO);


            // Act
            var project = _projectContainer.GetProjectById(id);

            // Assert
            Assert.Equal(id, project.ProjectId);

        }
    }
}
