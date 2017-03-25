using BulgarianCreators.Data;
using BulgarianCreators.Data.Services;
using BulgarianCreators.Data.Services.Contracts;
using BulgarianCreators.Models;
using BulgarianCreators.Models.Factories;
using BulgarianCreators.Tests.Mocks;
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
    public class GetAllPost_Should
    {
        [Test]
        public void Return_AllPosts_SortedByDate()
        {
            // Arrange
            var mockedDbContext = new Mock<ICreatorsDbContext>();
            var mockedDbSaveChangesContext = new Mock<ICreatorsDbSaveChangesContext>();
            var mockedPostFactory = new Mock<IPostFactory>();
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedUserService = new Mock<IUserService>();

            var posts = GetAllPost();

            var expectedResult = posts.OrderBy(x => x.PostedOn);
            var mockedPost = QueryableDbSetMock.GetQueryableMockDbSet(posts);

            mockedDbContext.Setup(x => x.Posts).Returns(mockedPost);

            var postService = new PostService(
                mockedDbContext.Object,
                mockedDbSaveChangesContext.Object,
                mockedPostFactory.Object,
                mockedCategoryService.Object,
                mockedUserService.Object);

            // Act
            var actualResult = postService.GetAllPost();

            // Assert
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }
        
        private IEnumerable<Post> GetAllPost()
        {
            IList<Post> posts = new List<Post>()
            {
                new Post() {Id = Guid.NewGuid(), Title = "date time now", PostedOn = DateTime.Now },
                new Post() {Id = Guid.NewGuid(), Title = "date time max", PostedOn = DateTime.MaxValue },
                new Post() {Id = Guid.NewGuid(), Title = "date time min", PostedOn = DateTime.MinValue }
            };

            return posts;
        }
    }
}
