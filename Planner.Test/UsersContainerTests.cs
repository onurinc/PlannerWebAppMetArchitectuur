using System.Collections.Generic;
using System.Linq;
using DataAccesLayer.Data.Data_Transfer_Object;
using DataAccesLayer.Data.InterfaceRepository;
using LogicLayer.Container;
using LogicLayer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Planner.Test
{
    [TestClass]
    public class UsersContainerTests
    {
        private readonly UsersContainer _usersContainer;

        private readonly Mock<IUsersRepository> _mockUsersRepository = new Mock<IUsersRepository>();

        public UsersContainerTests()
        {
            _usersContainer = new UsersContainer(_mockUsersRepository.Object);
        }

        List<UsersDTO> usersList = new List<UsersDTO>
        {
            new UsersDTO()
            {
                UserId = 1, Username = "UsernameOne", Password = "PasswordOne"
            },
            new UsersDTO()
            {
                UserId = 2, Username = "UsernameTwo", Password = "PasswordTwo"
            }
        };

        [TestMethod]
        public void GetAllUsers_IfThereIsUsersInTheDb()
        {
            // Arrange
            List<UsersModel> UserListOne = new List<UsersModel>();
            List<UsersModel> UserListTwo = new List<UsersModel>();
            _mockUsersRepository.Setup(x => x.GetAllUsers()).Returns(usersList);

            // Act
            UserListOne = _usersContainer.GetAllUsers();
            UserListTwo = _usersContainer.GetAllUsers();

            var lastUser = _usersContainer.GetAllUsers().Last();

            // Assert
            Assert.AreEqual(2, UserListOne.Count);
            Assert.AreEqual(2, UserListTwo.Count);
            Assert.AreEqual(lastUser.UserId, 2);
            Assert.AreEqual(lastUser.Username, "UsernameTwo");
        }

        [TestMethod]
        public void GetUser_ShouldReturnUser_IfUserExists()
        {
            // Arrange
            _mockUsersRepository.Setup(x => x.GetUser(It.IsAny<int>()))
                .Returns((int i) => usersList.Single(x => x.UserId == i));

            // Act
            var userWithIdOne = _usersContainer.GetUser(1);
            var userWithIdTwo = _usersContainer.GetUser(2);


            // Assert
            Assert.IsInstanceOfType(userWithIdTwo, typeof(UsersModel));
            Assert.AreEqual(2, userWithIdTwo.UserId);
            Assert.AreEqual("UsernameTwo", userWithIdTwo.Username);
            Assert.AreEqual(1, userWithIdOne.UserId);
            Assert.AreEqual("UsernameOne", userWithIdOne.Username);
        }

    }
}
