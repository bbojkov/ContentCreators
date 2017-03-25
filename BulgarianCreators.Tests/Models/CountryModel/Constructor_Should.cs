using BulgarianCreators.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulgarianCreators.Tests.Models.CountryModel
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void HaveParameterlessConstructor()
        {
            // Arrange
            var country = new Country();

            // Act & Assert
            Assert.IsInstanceOf<Country>(country);
        }

        [Test]
        public void SetIdCorrectly()
        {
            // Arrange
            var countryId = Guid.NewGuid();
            var country = new Country() { Id = countryId };

            // Act & Assert
            Assert.AreEqual(countryId, country.Id);
        }

        [TestCase("USA")]
        [TestCase("Bulgaria")]
        [TestCase("Malta")]
        public void SetCountryNameCorrectly(string countryName)
        {
            // Arrange
            var country = new Country() { CountryName = countryName };

            // Act & Assert
            Assert.AreEqual(countryName, country.CountryName);
        }
    }
}
