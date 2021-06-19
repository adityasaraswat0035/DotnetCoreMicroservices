using mango.web.Configuration;
using mango.web.Services.Models;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using System.Net.Http;
using mango.web.Services.Contracts;

namespace mango.web.Services.Impl
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ServicesUrl services;
        public ProductService(IHttpClientFactory httpClientFactory, IOptions<ServicesUrl> services) : base(httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
            this.services = services.Value;
        }
        public async Task<T> CreateProductAsync<T>(ProductDto productDto, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Type = RequestType.POST,
                Body = productDto,
                Url = $"{services.ProductApiBase}/api/product",
                AccessToken = token
            });
        }

        public async Task<T> DeleteProductAsync<T>(int productId, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Type = RequestType.DELETE,
                Url = $"{services.ProductApiBase}/api/product/{productId}",
                AccessToken = token
            });
        }

        public async Task<T> GetProductAsync<T>(string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Type = RequestType.GET,
                Url = $"{services.ProductApiBase}/api/product/",
                AccessToken = token
            });
        }

        public async Task<T> GetProductAsync<T>(int productId, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Type = RequestType.GET,
                Url = $"{services.ProductApiBase}/api/product/{productId}",
                AccessToken = token
            });
        }

        public async Task<T> UpdateProductAsync<T>(ProductDto productDto, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Type = RequestType.PUT,
                Url = $"{services.ProductApiBase}/api/product",
                Body = productDto,
                AccessToken = token
            });
        }
    }
}
