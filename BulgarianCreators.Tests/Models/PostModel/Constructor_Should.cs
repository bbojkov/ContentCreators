using BulgarianCreators.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulgarianCreators.Tests.Models.PostModel
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void SetParameterlessConstructor()
        {
            // Arrange
            var post = new Post();

            // Act & Assert
            Assert.IsInstanceOf<Post>(post);
        }

        [Test]
        public void SetIdCorrectly()
        {
            // Arrange
            var postId = Guid.NewGuid();
            var post = new Post() { Id = postId };

            // Act & Assert
            Assert.AreEqual(postId, post.Id);
        }

        [TestCase("Walk in the park")]
        [TestCase("You wouldn't believe this!")]
        [TestCase("Title")]
        public void SetTitleCorrectly(string title)
        {
            // Arrange
            var post = new Post() { Title = title };

            // Act & Assert
            Assert.AreEqual(title, post.Title);
        }

        [Test]
        public void SetTheAuthorCorrectly()
        {
            // Arrange
            var user = new User() { UserName = "Pesho" };
            var post = new Post() { PostedBy = user };

            // Act & Assert
            Assert.AreEqual(user, post.PostedBy);
        }

        [Test]
        public void SetTheImageCorrectly()
        {
            // Arrange
            var image = "Some image url";
            var post = new Post() { ImageUrl = image };

            // Act & Assert
            Assert.AreEqual(image, post.ImageUrl);
        }

        [Test]
        public void SetTheContentCorrectly()
        {
            // Arrange
            var content = "Some body for the content bla bla";
            var post = new Post() { Content = content };

            // Act & Assert
            Assert.AreEqual(content, post.Content);
        }

        [Test]
        public void SetCommentsCorrectlyForThePost()
        {
            // Arrange
            IList<Comment> comments = new List<Comment>()
            {
                new Comment() { commentBody = "First comment" },
                new Comment() { commentBody = "Second comment" },
                new Comment() { commentBody = "Third comment" }
            };

            var post = new Post();
            post.Comments.Add(comments[0]);
            post.Comments.Add(comments[1]);
            post.Comments.Add(comments[2]);

            // Act & Assert
            CollectionAssert.AreEqual(post.Comments, comments);
        }
    }
}
