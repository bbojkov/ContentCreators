using BulgarianCreators.Data;
using BulgarianCreators.Data.Services;
using BulgarianCreators.Data.Services.Contracts;
using BulgarianCreators.Models;
using BulgarianCreators.Models.Contracts;
using BulgarianCreators.Models.Factories;
using BulgarianCreators.Tests.Mocks;
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
    public class AddToFavorites_Should
    {
        [Test]
        public void AddThePost_ToTheUserLikesCollection()
        {
            // Arrange
            var mockedDbContext = new Mock<ICreatorsDbContext>();
            var mockedDbSaveChangesContext = new Mock<ICreatorsDbSaveChangesContext>();
            var mockedPostFactory = new Mock<IPostFactory>();
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedUserService = new Mock<IUserService>();

            var userId = Guid.NewGuid().ToString();
            var expectedUser = new User() { Id = userId };

            var mockedUser = new Mock<IDbSet<User>>();

            mockedUser.Setup(x => x.Find(userId)).Returns(expectedUser);

            mockedDbContext.Setup(x => x.Users).Returns(mockedUser.Object);

            var mockedPost = new Mock<Post>();

            var mockedPostService = new Mock<IPostService>();
            mockedPostService.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(mockedPost.Object);

            var postService = new PostService(
                mockedDbContext.Object,
                mockedDbSaveChangesContext.Object,
                mockedPostFactory.Object,
                mockedCategoryService.Object,
                mockedUserService.Object);
            
            
        }


        private List<Post> GetAllPost()
        {
            List<Post> posts = new List<Post>()
            {
                new Post() {Id = Guid.NewGuid(), Title = "date time now", PostedOn = DateTime.Now },
                new Post() {Id = Guid.NewGuid(), Title = "date time max", PostedOn = DateTime.MaxValue },
                new Post() {Id = Guid.NewGuid(), Title = "date time min", PostedOn = DateTime.MinValue }
            };

            return posts;
        }
    }
}
