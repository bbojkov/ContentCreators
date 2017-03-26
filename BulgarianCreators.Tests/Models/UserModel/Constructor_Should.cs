using BulgarianCreators.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulgarianCreators.Tests.Models.UserModel
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void SetTheCountry()
        {
            // Arrange
            var country = new Country() { CountryName = "Bulgaria" };
            var user = new User() { Country = country };

            // Act && Assert
            Assert.AreEqual(country, user.Country);
        }

        [Test]
        public void AddPostToUserLikes()
        {
            // Arrange 
            var posts = new List<Post>()
            {
                new Post() {Id = Guid.NewGuid() },
                new Post() {Id = Guid.NewGuid() },
                new Post() {Id = Guid.NewGuid() }
            };

            var user = new User() { Id = Guid.NewGuid().ToString() };

            // Act
            user.LikedPosts.Add(posts[0]);
            user.LikedPosts.Add(posts[1]);
            user.LikedPosts.Add(posts[2]);

            // Assert
            CollectionAssert.AreEqual(posts, user.LikedPosts);
        }
    }
}
