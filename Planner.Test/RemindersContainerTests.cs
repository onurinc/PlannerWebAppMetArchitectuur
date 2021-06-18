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
    public class RemindersContainerTests
    {

        private readonly RemindersContainer _remindersContainer;

        private readonly Mock<IRemindersRepository> _mockremindersRepository = new Mock<IRemindersRepository>();

        public RemindersContainerTests()
        {
            _remindersContainer = new RemindersContainer(_mockremindersRepository.Object);
        }

        List<RemindersDTO> remindersList = new List<RemindersDTO>
        {
            new RemindersDTO()
            {
                ReminderId = 1, UserId = 1, ReminderName = "ReminderOneName", ReminderDescription = "ReminderOneDescription"
            },
            new RemindersDTO()
            {
                ReminderId = 2, UserId = 1, ReminderName = "ReminderTwoName", ReminderDescription = "ReminderTwoDescription"
            }
        };

        [TestMethod]
        public void GetAllReminders_ShouldReturnAllReminders_IfRemindersExist()
        {
            // Arrange
            List<RemindersModel> remindersListOne = new List<RemindersModel>();
            List<RemindersModel> remindersListTwo = new List<RemindersModel>();
            _mockremindersRepository.Setup(x => x.GetAllReminders()).Returns(remindersList);

            // Act
            remindersListOne = _remindersContainer.GetAllReminders();
            remindersListTwo = _remindersContainer.GetAllReminders();
            var lastReminder = _remindersContainer.GetAllReminders().Last();

            // Assert
            Assert.AreEqual(2, remindersListOne.Count);
            Assert.AreEqual(2, remindersListTwo.Count);
            Assert.AreEqual(2, lastReminder.ReminderId);
            Assert.AreEqual("ReminderTwoName", lastReminder.ReminderName);
            Assert.AreEqual("ReminderTwoDescription", lastReminder.ReminderDescription);
        }

        [TestMethod]
        public void GetReminder_ShouldReturnReminder_IfReminderExists()
        {
            // Arrange
            _mockremindersRepository.Setup(x => x.GetReminder(It.IsAny<int>()))
                .Returns((int i) => remindersList.Single(x => x.ReminderId == i));
            // Act
            var reminderWIthIdOne = _remindersContainer.GetReminder(1);
            var reminderWithIdTwo = _remindersContainer.GetReminder(2);

            // Assert
            Assert.IsInstanceOfType(reminderWIthIdOne, typeof(RemindersModel));
            Assert.AreEqual(1, reminderWIthIdOne.ReminderId);
            Assert.AreEqual(1, reminderWIthIdOne.UserId);
            Assert.AreEqual("ReminderOneName", reminderWIthIdOne.ReminderName);
            Assert.AreEqual("ReminderOneDescription", reminderWIthIdOne.ReminderDescription);
            Assert.IsInstanceOfType(reminderWithIdTwo, typeof(RemindersModel));
            Assert.AreEqual(2, reminderWithIdTwo.ReminderId);
            Assert.AreEqual(1, reminderWithIdTwo.UserId);
            Assert.AreEqual("ReminderTwoName", reminderWithIdTwo.ReminderName);
            Assert.AreEqual("ReminderTwoDescription", reminderWithIdTwo.ReminderDescription);
        }

        [TestMethod]
        public void AddReminder_ShouldAddReminder_IfReminderParametersAreReal()
        {
            // Arrange
            List<RemindersModel> remindersListToTestAddedReminder = new List<RemindersModel>();
            _mockremindersRepository.Setup(x => x.GetAllReminders()).Returns(remindersList);
            _mockremindersRepository.Setup(x => x.AddReminder(It.IsAny<RemindersDTO>())).Callback(
                (RemindersDTO reminder) =>
                {
                    if (reminder.ReminderId.Equals(default(int)))
                    {
                        reminder.ReminderId = remindersList.Count() + 1;
                        remindersList.Add(reminder);
                    }
                    else
                    {
                        throw new Exception(
                            "Reminder can not be added, make sure you enter the corresponding information");
                    }
                });

            // Act
            _remindersContainer.AddReminder(1, "ReminderThree", "ReminderThreeDescription");
            var addedReminder = remindersList.Last();
            remindersListToTestAddedReminder = _remindersContainer.GetAllReminders();

            // Assert
            Assert.IsInstanceOfType(addedReminder, typeof(RemindersDTO));
            Assert.AreEqual(3, addedReminder.ReminderId);
            Assert.AreEqual(1, addedReminder.UserId);
            Assert.AreEqual("ReminderThree", addedReminder.ReminderName);
            Assert.AreEqual("ReminderThreeDescription", addedReminder.ReminderDescription);
            Assert.AreEqual(3, remindersListToTestAddedReminder.Count);
        }
    }
}
