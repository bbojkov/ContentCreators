using BulgarianCreators.Data;
using BulgarianCreators.Data.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulgarianCreators.Tests.Data.Services.CategoryServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowIfDbContext_IsNull()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                CategoryService categoryService = new CategoryService(null);
            });
        }

        [Test]
        public void NotThrow_IfDbContext_IsNotNull()
        {
            // Arrange 
            var mockedContext = new Mock<ICreatorsDbContext>();

            // Act and Assert
            Assert.DoesNotThrow(() =>
            {
                CategoryService categoryService = new CategoryService(mockedContext.Object);
            });
        }
    }
}
