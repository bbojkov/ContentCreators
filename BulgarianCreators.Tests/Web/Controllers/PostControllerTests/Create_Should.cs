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
using TestStack.FluentMVCTesting;

namespace BulgarianCreators.Tests.Web.Controllers.PostControllerTests
{
    [TestFixture]
    public class Create_Should
    {
        [Test]
        public void ShouldReturnDefaultView()
        {
            // Arrange
            var mockedPostService = new Mock<IPostService>();
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedAdapter = new Mock<IMapperAdapter>();

            var controller = new PostController(
                mockedPostService.Object,
                mockedCategoryService.Object,
                mockedAdapter.Object,
                mockedUserService.Object);

            controller.WithCallTo(x => x.Create()).ShouldRenderView("Create");
        }
    }
}
