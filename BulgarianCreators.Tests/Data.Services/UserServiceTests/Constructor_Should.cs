using BulgarianCreators.Data;
using BulgarianCreators.Data.Services;
using Moq;
using NUnit.Framework;
using System;

namespace BulgarianCreators.Tests.Data.Services.UserServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowIfDbContext_IsNull()
        {
            // Arrange Act Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                var userService = new UserService(null);
            });
        }

        [Test]
        public void NotThrow_IfDbContext_IsNotNull()
        {
            // Arrange
            var mockedContext = new Mock<ICreatorsDbContext>();

            // Act and Assert
            Assert.DoesNotThrow(() =>
            {
                var userService = new UserService(mockedContext.Object);
            });
        }
    }
}
