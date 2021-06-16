using mango.infrstructure.common.Wrappers;
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
        Task<IEnumerable<Product>> GetProducts();
        Task<Optional<Product>> GetProduct(int productId);

        Task<Optional<Product>> SaveProduct(Product product);

        Task<Optional<Product>> DeleteProduct(Product product);
    }
}
