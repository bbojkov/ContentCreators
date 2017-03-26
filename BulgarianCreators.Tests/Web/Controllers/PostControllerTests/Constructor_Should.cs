using BulgarianCreators.Data.Services.Contracts;
using BulgarianCreators.Web.Controllers;
using BulgarianCreators.Web.Mapping;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulgarianCreators.Tests.Web.Controllers.PostControllerTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowAgrumentNullException_WhenPostServiceIsNull()
        {
            // Arrange

            //var mockedPoservice = new Mock<IPostService>();
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedAdapter = new Mock<IMapperAdapter>();

            // Act & Assert

            Assert.That(() =>
                new PostController(null, mockedCategoryService.Object, mockedAdapter.Object, mockedUserService.Object),
                Throws.ArgumentNullException.With.Message.Contains("postService")
            );
        }

        [Test]
        public void ThrowsArgumentNullException_WhenCategoryServiceIsNull()
        {
            // Arrange

            var mockedPoservice = new Mock<IPostService>();
            //var mockedCategoryService = new Mock<ICategoryService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedAdapter = new Mock<IMapperAdapter>();

            // Act & Assert

            Assert.That(() =>
                new PostController(mockedPoservice.Object, null, mockedAdapter.Object, mockedUserService.Object),
                Throws.ArgumentNullException.With.Message.Contains("categoryService")
            );
        }

        [Test]
        public void ThrowsArgumentNullException_WhenUserServiceIsNull()
        {
            // Arrange

            var mockedPoservice = new Mock<IPostService>();
            var mockedCategoryService = new Mock<ICategoryService>();
            //var mockedUserService = new Mock<IUserService>();
            var mockedAdapter = new Mock<IMapperAdapter>();

            // Act & Assert

            Assert.That(() =>
                new PostController(mockedPoservice.Object, mockedCategoryService.Object, mockedAdapter.Object, null),
                Throws.ArgumentNullException.With.Message.Contains("userService")
            );
        }

        [Test]
        public void ThrowsArgumentNullException_WhenMapperAdapterIsNull()
        {
            // Arrange

            var mockedPoservice = new Mock<IPostService>();
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedUserService = new Mock<IUserService>();
            //var mockedAdapter = new Mock<IMapperAdapter>();

            // Act & Assert

            Assert.That(() =>
                new PostController(mockedPoservice.Object, mockedCategoryService.Object, null, mockedUserService.Object),
                Throws.ArgumentNullException.With.Message.Contains("mapperAdapter")
            );
        }

        [Test]
        public void NotThrow_IfAllPassedServices_AreLegit()
        {
            // Arrange

            var mockedPoservice = new Mock<IPostService>();
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedAdapter = new Mock<IMapperAdapter>();

            // Act & Assert
            Assert.DoesNotThrow(() =>
            {
                new PostController(
                    mockedPoservice.Object,
                    mockedCategoryService.Object,
                    mockedAdapter.Object,
                    mockedUserService.Object);
            });
        }
    }
}
