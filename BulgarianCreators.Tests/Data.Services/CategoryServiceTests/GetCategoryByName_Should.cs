using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulgarianCreators.Models;
using BulgarianCreators.Data;
using BulgarianCreators.Models.Factories;
using BulgarianCreators.Tests.Mocks;
using BulgarianCreators.Data.Services;

namespace BulgarianCreators.Tests.Data.Services.CategoryServiceTests
{
    [TestFixture]
    public class GetCategoryByName_Should
    {
        [Test]
        public void Return_TheRightCategory()
        {
            // Arrange
            var mockedContext = new Mock<ICreatorsDbContext>();

            var categories = this.GetCategories();

            var expectedResult = categories.FirstOrDefault(x => x.CategoryName == "Music");

            var categoriesSetMock = QueryableDbSetMock.GetQueryableMockDbSet(categories);

            mockedContext.Setup(x => x.Categories).Returns(categoriesSetMock);

            var categoryService = new CategoryService(mockedContext.Object);

            // Act
            var actualResult = categoryService.GetCategoryByName("Music");

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        private IEnumerable<Category> GetCategories()
        {
            return new List<Category>()
            {
                new Category() { Id=Guid.NewGuid(), CategoryName="Music" },
                new Category() { Id=Guid.NewGuid(), CategoryName="Lifestyle" },
                new Category() { Id=Guid.NewGuid(), CategoryName="Traveling" },
                new Category() { Id=Guid.NewGuid(), CategoryName="Comedy" }
            };
        }
    }
}
