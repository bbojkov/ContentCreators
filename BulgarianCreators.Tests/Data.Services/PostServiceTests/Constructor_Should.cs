using BulgarianCreators.Data;
using BulgarianCreators.Data.Services;
using BulgarianCreators.Data.Services.Contracts;
using BulgarianCreators.Models.Factories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulgarianCreators.Tests.Data.Services.PostServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        //var mockedDbContext = new Mock<ICreatorsDbContext>();
        //var mockedDbSaveChangesContext = new Mock<ICreatorsDbSaveChangesContext>();
        //var mockedPostFactory = new Mock<IPostFactory>();

        //var mockedCategoryService = new Mock<ICategoryService>();
        //var mockedUserService = new Mock<IUserService>();

        [Test]
        public void ThrowIfDbContextIsNull()
        {
            // Arrange 
            var mockedDbSaveChangesContext = new Mock<ICreatorsDbSaveChangesContext>();
            var mockedPostFactory = new Mock<IPostFactory>();

            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedUserService = new Mock<IUserService>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                var postService = new PostService(
                    null,
                    mockedDbSaveChangesContext.Object,
                    mockedPostFactory.Object,
                    mockedCategoryService.Object,
                    mockedUserService.Object
                    );
            });
        }

        [Test]
        public void ThrowsIf_SaveChangesContext_IsNull()
        {
            // Arrange
            var mockedDbContext = new Mock<ICreatorsDbContext>();
            var mockedPostFactory = new Mock<IPostFactory>();

            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedUserService = new Mock<IUserService>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                var postService = new PostService(
                    mockedDbContext.Object,
                    null,
                    mockedPostFactory.Object,
                    mockedCategoryService.Object,
                    mockedUserService.Object);
            });
        }

        [Test]
        public void ThrowsIf_PostFactory_IsNull()
        {
            // Arrange
            var mockedDbContext = new Mock<ICreatorsDbContext>();
            var mockedDbSaveChangesContext = new Mock<ICreatorsDbSaveChangesContext>();

            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedUserService = new Mock<IUserService>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                var postService = new PostService(
                    mockedDbContext.Object,
                    mockedDbSaveChangesContext.Object,
                    null,
                    mockedCategoryService.Object,
                    mockedUserService.Object);
            });
        }

        [Test]
        public void ThrowsIf_CategoryService_IsNull()
        {
            // Arrange 
            var mockedDbContext = new Mock<ICreatorsDbContext>();
            var mockedDbSaveChangesContext = new Mock<ICreatorsDbSaveChangesContext>();
            var mockedPostFactory = new Mock<IPostFactory>();

            var mockedUserService = new Mock<IUserService>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                var postService = new PostService(
                    mockedDbContext.Object,
                    mockedDbSaveChangesContext.Object,
                    mockedPostFactory.Object,
                    null,
                    mockedUserService.Object
                    );
            });
        }

        [Test]
        public void ThrowIf_UserService_IsNull()
        {
            // Arrange
            var mockedDbContext = new Mock<ICreatorsDbContext>();
            var mockedDbSaveChangesContext = new Mock<ICreatorsDbSaveChangesContext>();
            var mockedPostFactory = new Mock<IPostFactory>();

            var mockedCategoryService = new Mock<ICategoryService>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                var postService = new PostService(
                    mockedDbContext.Object,
                    mockedDbSaveChangesContext.Object,
                    mockedPostFactory.Object,
                    mockedCategoryService.Object,
                    null);
            });
        }

        [Test]
        public void NotThrows_IfAllPassedParameters_AreNotNull()
        {
            // Arrange
            var mockedDbContext = new Mock<ICreatorsDbContext>();
            var mockedDbSaveChangesContext = new Mock<ICreatorsDbSaveChangesContext>();
            var mockedPostFactory = new Mock<IPostFactory>();

            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedUserService = new Mock<IUserService>();

            // Act & Assert
            Assert.DoesNotThrow(() =>
            {
                var postService = new PostService(
                    mockedDbContext.Object,
                    mockedDbSaveChangesContext.Object,
                    mockedPostFactory.Object,
                    mockedCategoryService.Object,
                    mockedUserService.Object);
            });
        }
    }
}
