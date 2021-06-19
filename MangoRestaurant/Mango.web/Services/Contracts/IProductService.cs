using mango.web.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mango.web.Services.Contracts
{
    public interface IProductService : IBaseService
    {
        Task<T> GetProductAsync<T>(string token);
        Task<T> GetProductAsync<T>(int productId, string token);
        Task<T> CreateProductAsync<T>(ProductDto productDto, string token);
        Task<T> UpdateProductAsync<T>(ProductDto productDto, string token);
        Task<T> DeleteProductAsync<T>(int productId, string token);
    }
}
