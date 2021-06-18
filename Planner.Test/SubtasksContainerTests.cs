 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccesLayer.Data.Data_Transfer_Object;
using DataAccesLayer.Data.InterfaceRepository;
using LogicLayer.Container;
using LogicLayer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Planner.Test
{
    [TestClass]
    public class SubtasksContainerTests
    {

        private readonly SubtasksContainer _subtasksContainer;

        private readonly Mock<ISubtasksRepository> _mockSubtasksRepository = new Mock<ISubtasksRepository>();

        public SubtasksContainerTests()
        {
            _subtasksContainer = new SubtasksContainer(_mockSubtasksRepository.Object);
        }

        List<SubtasksDTO> subtasksList = new List<SubtasksDTO>
        {
            new SubtasksDTO()
            {
                SubtaskId = 1, ProjectId = 1, SubtaskName = "SubtaskOneName",
                SubtaskDescription = "SubtaskOneDescription", SubtaskStatus = true, SubtaskLabel = "TestLabel"
            },
            new SubtasksDTO()
            {
                SubtaskId = 2, ProjectId = 1, SubtaskName = "SubtaskTwoName",
                SubtaskDescription = "SubtaskTwoDescription", SubtaskStatus = true, SubtaskLabel = "TestLabel"
            }
        };

        [TestMethod]
        public void GetAllSubtasks_IfThereIsExistingSubtasks()
        {
            // Arrange
            List<SubtasksModel> subtasksListOne = new List<SubtasksModel>();
            List<SubtasksModel> subtasksListTwo = new List<SubtasksModel>();
            _mockSubtasksRepository.Setup(x => x.GetAllSubtasks()).Returns(subtasksList);

            // Act
            subtasksListOne = _subtasksContainer.GetAllSubtasks();
            subtasksListTwo = _subtasksContainer.GetAllSubtasks();

            var lastSubtask = _subtasksContainer.GetAllSubtasks().Last();

            // Assert
            Assert.AreEqual(2, subtasksListOne.Count);
            Assert.AreEqual(2, subtasksListTwo.Count);
            Assert.AreEqual(lastSubtask.SubtaskId, 2);
            Assert.AreEqual(lastSubtask.ProjectId, 1);
            Assert.AreEqual(lastSubtask.SubtaskName, "SubtaskTwoName");
            Assert.AreEqual(lastSubtask.SubtaskDescription, "SubtaskTwoDescription");
            Assert.AreEqual(lastSubtask.SubtaskStatus, true);
            Assert.AreEqual(lastSubtask.SubtaskLabel, "TestLabel");
        }

        [TestMethod]
        public void GetSubtask_ShouldReturnSubtask_IfSubtaskExists()
        {
            // Arrange
            _mockSubtasksRepository.Setup(x => x.GetSubtask(It.IsAny<int>()))
                .Returns((int i) => subtasksList.Single(x => x.SubtaskId == i));

            // Act
            var subtaskWithIdOne = _subtasksContainer.GetSubtask(1);
            var subtaskWithIdTwo = _subtasksContainer.GetSubtask(2);


            // Assert
            Assert.AreEqual(subtaskWithIdOne.SubtaskId, 1);
            Assert.AreEqual(subtaskWithIdOne.ProjectId, 1);
            Assert.AreEqual(subtaskWithIdOne.SubtaskName, "SubtaskOneName");
            Assert.AreEqual(subtaskWithIdOne.SubtaskDescription, "SubtaskOneDescription");
            Assert.AreEqual(subtaskWithIdOne.SubtaskStatus, true);
            Assert.AreEqual(subtaskWithIdOne.SubtaskLabel, "TestLabel");
            Assert.AreEqual(subtaskWithIdTwo.SubtaskId, 2);
            Assert.AreEqual(subtaskWithIdTwo.ProjectId, 1);
            Assert.AreEqual(subtaskWithIdTwo.SubtaskName, "SubtaskTwoName");
            Assert.AreEqual(subtaskWithIdTwo.SubtaskDescription, "SubtaskTwoDescription");
            Assert.AreEqual(subtaskWithIdTwo.SubtaskStatus, true);
            Assert.AreEqual(subtaskWithIdTwo.SubtaskLabel, "TestLabel");
        }

    }
}
