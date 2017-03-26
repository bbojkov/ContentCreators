using BulgarianCreators.Data.Services.Contracts;
using BulgarianCreators.Models;
using BulgarianCreators.Web.Controllers;
using BulgarianCreators.Web.Mapping;
using BulgarianCreators.Web.Models;
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
    public class SingleBlogPost_Should
    {
        [Test]
        public void ReturnViewWithModel_WhenThereIsAProvidedId()
        {
            // Arrange

            var mockedPostService = new Mock<IPostService>();
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedAdapter = new Mock<IMapperAdapter>();

            Post post = new Post()
            {
                Id = Guid.NewGuid()
            };

            mockedPostService.Setup(x => x.GetById(post.Id)).Returns(post).Verifiable();

            var controller = new PostController(
                mockedPostService.Object,
                mockedCategoryService.Object,
                mockedAdapter.Object,
                mockedUserService.Object);
            
            controller.SingleBlogPost(post.Id);

            mockedPostService.Verify(x => x.GetById(post.Id), Times.Once);
        }

        [Test]
        public void MapPostToViewModel()
        {
            // Arrange

            var mockedPostService = new Mock<IPostService>();
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedAdapter = new Mock<IMapperAdapter>();

            var mockedPost = new Mock<Post>();
            mockedPostService.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(mockedPost.Object);

            mockedAdapter.Setup(x => x.Map<PostViewModel>(It.IsAny<Post>())).Verifiable();

            var controller = new PostController(
                mockedPostService.Object,
                mockedCategoryService.Object,
                mockedAdapter.Object,
                mockedUserService.Object);

            // Act
            controller.SingleBlogPost(Guid.NewGuid());

            // Assert
            mockedAdapter.Verify(x => x.Map<PostViewModel>(mockedPost.Object), Times.Once);
        }

        [Test]
        public void ReturnViewWithCorrectModel()
        {
            // Arrange

            var mockedPostService = new Mock<IPostService>();
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedAdapter = new Mock<IMapperAdapter>();

            var mockedPostViewModel = new Mock<PostViewModel>();

            var mockedPost = new Mock<Post>();
            mockedPostService.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(mockedPost.Object);

            mockedAdapter.Setup(x => x.Map<PostViewModel>(It.IsAny<Post>())).Returns(mockedPostViewModel.Object);

            var controller = new PostController(
                mockedPostService.Object,
                mockedCategoryService.Object,
                mockedAdapter.Object,
                mockedUserService.Object);

            // Act & Assert
            controller.WithCallTo(c => c.SingleBlogPost(Guid.NewGuid())).ShouldRenderDefaultView()
                .WithModel(mockedPostViewModel.Object);
        }

        [Test]
        public void ReturnErrorView_WhenPostNotFound()
        {
            // Arrange

            var mockedPostService = new Mock<IPostService>();
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedAdapter = new Mock<IMapperAdapter>();

            mockedPostService.Setup(x => x.GetById(It.IsAny<Guid>())).Returns((Post)null);

            var controller = new PostController(
                mockedPostService.Object,
                mockedCategoryService.Object,
                mockedAdapter.Object,
                mockedUserService.Object);

            // Act & Assert
            controller.WithCallTo(c => c.SingleBlogPost(Guid.NewGuid())).ShouldRenderView("Error");
        }
    }
}
