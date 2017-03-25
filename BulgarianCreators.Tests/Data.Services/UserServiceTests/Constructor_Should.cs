using BulgarianCreators.Data;
using BulgarianCreators.Data.Services;
using BulgarianCreators.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

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

        [Test]
        public void ShouldGetAndSetLikedPostsData_Correctly()
        {
            // Arrange & Act
            var post = new Post() { Id = Guid.NewGuid() };
            var set = new HashSet<Post> { post };

            var user = new User() { LikedPosts = set };

            // Assert
            Assert.AreEqual(user.LikedPosts.First().Id, post.Id);
        }

        [Test]
        public void ShouldGetAndSetPostedByUserData_Correctly()
        {
            // Arrange & Act
            // Arrange & Act
            var post = new Post() { Id = Guid.NewGuid() };
            var set = new HashSet<Post> { post };

            var user = new User() { PostedByUser = set };

            // Assert
            Assert.AreEqual(user.PostedByUser.First().Id, post.Id);
        }
    }
}
