using BulgarianCreators.Data.Services.Contracts;
using BulgarianCreators.Models;
using BulgarianCreators.Web.Controllers;
using BulgarianCreators.Web.Mapping;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.FluentMVCTesting;

namespace BulgarianCreators.Tests.Web.Controllers.PostControllerTests
{
    [TestFixture]
    public class Index_Should
    {
        [Test]
        public void CallPostService_GetAllPosts()
        {
            // Arrange

            var mockedPostService = new Mock<IPostService>();
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedAdapter = new Mock<IMapperAdapter>();

            IList<Post> mockedPostList = new List<Post>();

            mockedPostService.Setup(x => x.GetAllPost()).Returns(mockedPostList.AsQueryable()).Verifiable();

            var controller = new PostController(
                mockedPostService.Object,
                mockedCategoryService.Object,
                mockedAdapter.Object,
                mockedUserService.Object);

            // Act
            controller.Index();

            // Assert
            mockedPostService.Verify(x => x.GetAllPost(), Times.Once);
        }

        [Test]
        public void RenderView_WhenPostServiceCallGetAllPosts()
        {
            // Arrange

            var mockedPostService = new Mock<IPostService>();
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedAdapter = new Mock<IMapperAdapter>();

            IList<Post> mockedPostList = new List<Post>();

            mockedPostService.Setup(x => x.GetAllPost()).Returns(mockedPostList.AsQueryable()).Verifiable();

            var controller = new PostController(
                mockedPostService.Object,
                mockedCategoryService.Object,
                mockedAdapter.Object,
                mockedUserService.Object);

            // Act
            controller.Index();

            // Assert
            controller.WithCallTo(x => x.Index()).ShouldRenderView("Index");
        }

        [Test]
        public void ReturnErrorView_WhenPostsAreNotFound()
        {
            // Arrange

            var mockedPostService = new Mock<IPostService>();
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedAdapter = new Mock<IMapperAdapter>();

            mockedPostService.Setup(x => x.GetAllPost()).Returns((IQueryable<Post>)null);

            var controller = new PostController(
                mockedPostService.Object,
                mockedCategoryService.Object,
                mockedAdapter.Object,
                mockedUserService.Object);

            // Act & Assert
            controller.WithCallTo(c => c.Index()).ShouldRenderView("Error");
        }
    }
}
