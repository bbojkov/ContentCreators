using BulgarianCreators.Data;
using BulgarianCreators.Data.Services;
using BulgarianCreators.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Data.Entity;

namespace BulgarianCreators.Tests.Data.Services.UserServiceTests
{
    [TestFixture]
    public class GetUserById_Should
    {
        [Test]
        public void ReturnNull_IfProvidedId_IsNull()
        {
            // Arrange
            var mockedContext = new Mock<ICreatorsDbContext>();
            var userMock = new Mock<IDbSet<User>>();

            mockedContext.Setup(x => x.Users).Returns(userMock.Object);

            string userId = null;
            var userService = new UserService(mockedContext.Object);

            // Act
            User actualUser = userService.GetUserById(userId);

            // Assert
            Assert.IsNull(actualUser);
        }

        [Test]
        public void NotReturnNull_IfProvidedId_IsNotNull()
        {
            // Arrange
            var mockedContext = new Mock<ICreatorsDbContext>();
            var userMock = new Mock<IDbSet<User>>();

            mockedContext.Setup(x => x.Users).Returns(userMock.Object);

            string userId = Guid.NewGuid().ToString();
            User expectedUser = new User() { Id = userId };
            userMock.Setup(x => x.Find(userId)).Returns(expectedUser);

            var userService = new UserService(mockedContext.Object);

            // Act
            User actualUser = userService.GetUserById(userId);

            // Assert
            Assert.IsNotNull(actualUser);
        }

        [Test]
        public void Return_TheCorrectUser()
        {
            // Arrange
            var mockedContext = new Mock<ICreatorsDbContext>();
            var userMock = new Mock<IDbSet<User>>();

            mockedContext.Setup(x => x.Users).Returns(userMock.Object);

            string userId = Guid.NewGuid().ToString();
            var expectedUser = new User() { Id = userId };
            userMock.Setup(x => x.Find(userId)).Returns(expectedUser);

            UserService userService = new UserService(mockedContext.Object);

            // Act
            var actualUser = userService.GetUserById(userId);

            // Assert
            Assert.AreSame(expectedUser, actualUser);
        }
    }
}
