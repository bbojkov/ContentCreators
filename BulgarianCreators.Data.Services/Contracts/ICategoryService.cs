using BulgarianCreators.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulgarianCreators.Data.Services.Contracts
{
    public interface ICategoryService
    {
        Category GetCategoryByName(string categoryName);

        IQueryable<Category> GetAllCategories();
    }
}
