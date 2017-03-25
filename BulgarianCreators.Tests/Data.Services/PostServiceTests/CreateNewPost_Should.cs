using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulgarianCreators.Data;
using BulgarianCreators.Models.Factories;
using BulgarianCreators.Data.Services.Contracts;
using BulgarianCreators.Models;
using System.Data.Entity;
using BulgarianCreators.Data.Services;

namespace BulgarianCreators.Tests.Data.Services.PostServiceTests
{
    [TestFixture]
    public class CreateNewPost_Should
    {
        [Test]
        public void CreateNewPost()
        {
            // Arrange
            var mockedDbContext = new Mock<ICreatorsDbContext>();
            var mockedDbSaveChangesContext = new Mock<ICreatorsDbSaveChangesContext>();
            var mockedPostFactory = new Mock<IPostFactory>();
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedUserService = new Mock<IUserService>();

            var category = new Category() { Id = Guid.NewGuid(), CategoryName = "Music" };
            var user = new User() { Id = Guid.NewGuid().ToString() };
            var post = new Post();

            mockedCategoryService.Setup(x => x.GetCategoryByName(category.CategoryName)).Returns(category);
            mockedUserService.Setup(x => x.GetUserById(user.Id)).Returns(user);
            mockedPostFactory.Setup(x => x.CreatePostInstance()).Returns(post);

            var postDbList = new List<Post>();
            var mockedPostDbList = new Mock<IDbSet<Post>>();

            mockedPostDbList.Setup(set => set.Add(It.IsAny<Post>()))
                .Callback((Post p) => postDbList.Add(p));

            mockedDbContext.Setup(x => x.Posts).Returns(mockedPostDbList.Object);

            var postService = new PostService(
                mockedDbContext.Object,
                mockedDbSaveChangesContext.Object,
                mockedPostFactory.Object,
                mockedCategoryService.Object,
                mockedUserService.Object);

            var postTitle = "Some title";
            var postImageUrl = "url bro";
            var postCategory = category.CategoryName;
            var postContent = "bla bla bla content";

            // Act
            postService.CreateNewPost(postTitle, postImageUrl, postCategory, postContent);

            // Assert
            Assert.That(postDbList.Count(), Is.EqualTo(1));
            Assert.That(postDbList[0].Category, Is.SameAs(category));
        }

        [Test]
        public void ThrowIfInvalidParametersArePassed()
        {
            // Arrange
            var mockedDbContext = new Mock<ICreatorsDbContext>();
            var mockedDbSaveChangesContext = new Mock<ICreatorsDbSaveChangesContext>();
            var mockedPostFactory = new Mock<IPostFactory>();
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedUserService = new Mock<IUserService>();

            var postService = new PostService(
                mockedDbContext.Object,
                mockedDbSaveChangesContext.Object,
                mockedPostFactory.Object,
                mockedCategoryService.Object,
                mockedUserService.Object);

            // Act & Assert
            Assert.Throws<NullReferenceException>(() =>
            {
                postService.CreateNewPost(null, null, null, null);
            });
        }
    }
}
