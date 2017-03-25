using BulgarianCreators.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulgarianCreators.Tests.Models.CommentModel
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void HaveParameterlessConstructor()
        {
            // Arrange
            var comment = new Comment();

            // Act & Assert
            Assert.IsInstanceOf<Comment>(comment);
        }

        [Test]
        public void SetIdCorrectly()
        {
            // Arrange
            Guid commentId = Guid.NewGuid();
            var comment = new Comment() { Id = commentId };

            //Act & Assert
            Assert.AreEqual(commentId, comment.Id);
        }

        [Test]
        public void SetTheRightAuthor()
        {
            // Arrange 
            var user = new User();
            var comment = new Comment() { PostedBy = user };

            // Act & Assert
            Assert.AreEqual(user, comment.PostedBy);
        }

        [Test]
        public void SetsTheRightDate_ToAComment()
        {
            // Arrange
            var datePostedOn = DateTime.Now;
            var comment = new Comment() { PostedOn = datePostedOn };

            // Act & Assert
            Assert.AreEqual(datePostedOn, comment.PostedOn);
        }

        [Test]
        public void SetTheCommentBody()
        {
            // Arrange
            var commentBody = "Some comment trololo";

            var comment = new Comment() { commentBody = commentBody };

            // Act & Assert 
            Assert.AreEqual(commentBody, comment.commentBody);
        }
    }
}
