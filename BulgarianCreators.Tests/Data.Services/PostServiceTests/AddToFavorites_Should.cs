using BulgarianCreators.Data;
using BulgarianCreators.Data.Services;
using BulgarianCreators.Data.Services.Contracts;
using BulgarianCreators.Models;
using BulgarianCreators.Models.Contracts;
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
    public class AddToFavorites_Should
    {
        [Test]
        public void AddThePost_TheTheUserLikesCollection()
        {
            //// Arrange
            //var mockedDbContext = new Mock<ICreatorsDbContext>();
            //var mockedDbSaveChangesContext = new Mock<ICreatorsDbSaveChangesContext>();
            //var mockedPostFactory = new Mock<IPostFactory>();
            //var mockedCategoryService = new Mock<ICategoryService>();
            //var mockedUserService = new Mock<IUserService>();
            //var mockedPostService = new Mock<IPostService>();

            //var post = new Post() { Id = Guid.NewGuid() };
            //var user = new User() { Id = Guid.NewGuid().ToString() };

            //mockedPostService.Setup(x => x.GetById(post.Id)).Returns(post);
            //mockedUserService.Setup(x => x.GetUserById(user.Id)).Returns(user);

            //var postService = new PostService(
            //    mockedDbContext.Object,
            //    mockedDbSaveChangesContext.Object,
            //    mockedPostFactory.Object,
            //    mockedCategoryService.Object,
            //    mockedUserService.Object);

            //postService.AddToFavorites(post.Id, user.Id);
        }
    }
}
