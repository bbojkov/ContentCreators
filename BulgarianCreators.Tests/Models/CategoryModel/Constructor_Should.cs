using BulgarianCreators.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulgarianCreators.Tests.Models.CategoryModel
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void HaveParameterlessConstructor()
        {
            // Arrange
            var category = new Category();

            // Act & Assert
            Assert.IsInstanceOf<Category>(category);
        }

        [Test]
        public void SetIdCorrectly()
        {
            // Arrange
            Guid categoryId = Guid.NewGuid();
            var category = new Category() { Id = categoryId };

            //Act & Assert
            Assert.AreEqual(categoryId, category.Id);
        }

        [TestCase("Vlog")]
        [TestCase("Photography")]
        public void SetCategoryName_Correctly(string categoryName)
        {
            // Arrange
            var category = new Category() { CategoryName = categoryName };

            // Act & Assert
            Assert.AreEqual(categoryName, category.CategoryName);
        }
    }
}
