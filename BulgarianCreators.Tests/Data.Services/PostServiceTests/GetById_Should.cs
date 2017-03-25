using BulgarianCreators.Data;
using BulgarianCreators.Data.Services;
using BulgarianCreators.Data.Services.Contracts;
using BulgarianCreators.Models;
using BulgarianCreators.Models.Factories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulgarianCreators.Tests.Data.Services.PostServiceTests
{
    [TestFixture]
    public class GetById_Should
    {
        [Test]
        public void ReturnCorrectPost_WithProvidedId()
        {
            // Arrange
            Guid postId = Guid.NewGuid();
            Post expectedPost = new Post() { Id = postId };

            var mockedDbContext = new Mock<ICreatorsDbContext>();
            var mockedDbSaveChangesContext = new Mock<ICreatorsDbSaveChangesContext>();
            var mockedPostFactory = new Mock<IPostFactory>();
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedUserService = new Mock<IUserService>();

            var mockedPost = new Mock<IDbSet<Post>>();

            mockedPost.Setup(x => x.Find(It.Is<Guid>(g => g == expectedPost.Id))).Returns(expectedPost);

            mockedDbContext.Setup(x => x.Posts).Returns(mockedPost.Object);


            var postService = new PostService(
                    mockedDbContext.Object,
                    mockedDbSaveChangesContext.Object,
                    mockedPostFactory.Object,
                    mockedCategoryService.Object,
                    mockedUserService.Object);

            // Act
            var actualResult = postService.GetById(postId);

            // Assert
            Assert.AreEqual(expectedPost, actualResult);
        }

        [Test]
        public void ReturnNull_WhenPost_IsNotFound()
        {
            // Arrange
            Guid postId = Guid.NewGuid();
            Post expectedPost = new Post() { Id = postId };
            Post anotherPost = new Post() { Id = Guid.NewGuid() };

            var mockedDbContext = new Mock<ICreatorsDbContext>();
            var mockedDbSaveChangesContext = new Mock<ICreatorsDbSaveChangesContext>();
            var mockedPostFactory = new Mock<IPostFactory>();
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedUserService = new Mock<IUserService>();

            var mockedPost = new Mock<IDbSet<Post>>();

            mockedPost.Setup(x => x.Find(It.Is<Guid>(g => g == expectedPost.Id))).Returns(expectedPost);

            mockedDbContext.Setup(x => x.Posts).Returns(mockedPost.Object);


            var postService = new PostService(
                    mockedDbContext.Object,
                    mockedDbSaveChangesContext.Object,
                    mockedPostFactory.Object,
                    mockedCategoryService.Object,
                    mockedUserService.Object);

            // Act
            var actualResult = postService.GetById(anotherPost.Id);

            // Assert
            Assert.That(actualResult, Is.Null);
        }
    }
}
