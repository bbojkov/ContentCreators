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
    }
}
