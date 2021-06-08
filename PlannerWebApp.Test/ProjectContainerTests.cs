﻿using System;
using System.Collections.Generic;

using DataAccesLayer.Data;
using DataAccesLayer.Data.InterfaceRepository;
using LogicLayer.Container;
using LogicLayer.DAO;
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
            Assert.Equal(projectId, project.ProjectId);
            Assert.Equal(projectName, project.ProjectName);
        }

        [Fact]
        public void GetProject_ShouldReturnNothing_WhenProjectDoesNotExist()
        {
            // Arrange
            var projectId = 1;
            var projectName = "ProjectOne";
            var project = new ProjectsDTO {ProjectId = projectId, ProjectName = projectName};
            _projectRepoMock.Setup(x => x.GetProject(projectId)).Returns(project);

            // Act
            var actualproject = _projectContainer.GetProjectById(projectId + 1);

            // Assert
            Assert.Null(actualproject);
        }

        [Fact]
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
            _projectRepoMock.Setup(x => x.GetAllProjects()).Returns(projectListOne);

            // Act
            projectListTwo = _projectContainer.GetAllProjects();

            // Assert

        }
    }
}
