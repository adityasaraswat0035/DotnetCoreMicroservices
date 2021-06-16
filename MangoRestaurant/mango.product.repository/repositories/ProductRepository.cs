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
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductAsync(int productId);

        Task<Product> SaveProductAsync(Product product);

        Task DeleteProductAsync(int productId);
    }
}
