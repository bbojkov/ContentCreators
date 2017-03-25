using BulgarianCreators.Data.Services.Contracts;
using System.Linq;
using BulgarianCreators.Models;
using BulgarianCreators.Models.Factories;
using Bytes2you.Validation;

namespace BulgarianCreators.Data.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICreatorsDbContext dbContext;

        public CategoryService(
            ICreatorsDbContext dbContext)
        {
            Guard.WhenArgument(dbContext, "dbContext").IsNull().Throw();

            this.dbContext = dbContext;
        }

        public IQueryable<Category> GetAllCategories()
        {
            return this.dbContext.Categories.OrderBy(x => x.CategoryName);
        }

        public Category GetCategoryByName(string categoryName)
        {
            return this.dbContext.Categories.FirstOrDefault(x => x.CategoryName == categoryName);
        }
    }
}
