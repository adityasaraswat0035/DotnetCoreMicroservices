using mango.infrstructure.common.Wrappers;
using mango.product.contract.dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mango.product.contract.contracts
{
    public interface ProductManager
    {
        Task<IEnumerable<ProductDto>> GetProductsAsync();
        Task<Optional<ProductDto>> GetProductAsync(int productId);

        Task<ProductDto> SaveProductAsync(ProductDto productDto);

        Task DeleteProductAsync(int productId);
    }
}
