using mango.web.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mango.web.Contracts
{
    public interface IProductService:IBaseService
    {
        Task<T> GetProductAsync<T>();
        Task<T> GetProductAsync<T>(int productId);
        Task<T> CreateProductAsync<T>(ProductDto productDto);
        Task<T> UpdateProductAsync<T>(ProductDto productDto);
        Task<T> DeleteProductAsync<T>(int productId);
    }
}
