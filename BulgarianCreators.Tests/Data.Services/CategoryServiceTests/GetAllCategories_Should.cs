using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using Moq;
using BulgarianCreators.Data;
using BulgarianCreators.Models.Factories;
using BulgarianCreators.Models;
using BulgarianCreators.Tests.Mocks;
using BulgarianCreators.Data.Services;

namespace BulgarianCreators.Tests.Data.Services.CategoryServiceTests
{
    [TestFixture]
    public class GetAllCategories_Should
    {
        [Test]
        public void Returns_SortedCategories_ByName()
        {
            // Arrange
            var mockedContext = new Mock<ICreatorsDbContext>();

            var categories = this.GetCategories();

            var expectedResult = categories.OrderBy(x => x.CategoryName);

            var categoriesSetMock = QueryableDbSetMock.GetQueryableMockDbSet(categories);

            mockedContext.Setup(x => x.Categories).Returns(categoriesSetMock);

            var categoryService = new CategoryService(mockedContext.Object);

            // Act
            var actualResult = categoryService.GetAllCategories();

            // Assert
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void ReturnsTheRightCount_OfCategories()
        {
            // Arrange
            var mockedContext = new Mock<ICreatorsDbContext>();
            var mockedCategoryFactory = new Mock<ICategoryFactory>();

            var categories = this.GetCategories();

            var expectedResult = categories.OrderBy(x => x.CategoryName);

            var categoriesSetMock = QueryableDbSetMock.GetQueryableMockDbSet(categories);

            mockedContext.Setup(x => x.Categories).Returns(categoriesSetMock);

            var categoryService = new CategoryService(mockedContext.Object);

            // Act
            var actualResult = categoryService.GetAllCategories();

            // Assert
            Assert.That(expectedResult.ToList().Count() == actualResult.Count());
        }

        [Test]
        public void ReturnsACollection_WithInstancesOfCategories()
        {
            // Arrange
            var mockedContext = new Mock<ICreatorsDbContext>();
            var mockedCategoryFactory = new Mock<ICategoryFactory>();

            var categories = this.GetCategories();

            var expectedResult = categories.OrderBy(x => x.CategoryName);

            var categoriesSetMock = QueryableDbSetMock.GetQueryableMockDbSet(categories);

            mockedContext.Setup(x => x.Categories).Returns(categoriesSetMock);

            var categoryService = new CategoryService(mockedContext.Object);

            // Act
            var actualResult = categoryService.GetAllCategories();

            // Assert
            CollectionAssert.AllItemsAreInstancesOfType(actualResult, typeof(Category));
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
