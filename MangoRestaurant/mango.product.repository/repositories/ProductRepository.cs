using mango.product.repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mango.product.repository.repositories
{
    public interface ProductRepository
    {
        Task<IEnumerable<Product>> GetAsync();
        Task<Product> GetAsync(int productId);

        Task<Product> SaveAsync(Product product);

        Task<Product> DeleteAsync(int productId);
    }
}
