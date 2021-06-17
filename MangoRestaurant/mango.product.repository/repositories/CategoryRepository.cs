using mango.product.repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mango.product.repository.repositories
{
    interface CategoryRepository
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryAsync(int productId);

        Task<Category> SaveCategoryAsync(Product product);

        Task DeleteCategoryAsync(int productId);
    }
}
