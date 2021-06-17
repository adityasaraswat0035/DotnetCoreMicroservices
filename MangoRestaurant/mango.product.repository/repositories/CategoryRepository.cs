using mango.product.repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mango.product.repository.repositories
{
    public interface CategoryRepository
    {
        Task<IEnumerable<Category>> GetAsync();
        Task<Category> GetAsync(int categoryId);

        Task<Category> SaveAsync(Category category);

        Task DeleteAsync(int categoryId);
    }
}
