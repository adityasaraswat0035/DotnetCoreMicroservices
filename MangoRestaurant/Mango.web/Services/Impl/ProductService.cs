using mango.web.Configuration;
using mango.web.Contracts;
using mango.web.Services.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;


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
        public async Task<T> CreateProductAsync<T>(ProductDto productDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Type = RequestType.POST,
                Body = productDto,
                Url = $"{services.ProductApiBase}/api/product",
                AccessToken = ""
            });
        }

        public async Task<T> DeleteProductAsync<T>(int productId)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Type = RequestType.DELETE,
                Url = $"{services.ProductApiBase}/api/product/{productId}",
                AccessToken = ""
            });
        }

        public async Task<T> GetProductAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Type = RequestType.GET,
                Url = $"{services.ProductApiBase}/api/product/",
                AccessToken = ""
            });
        }

        public async Task<T> GetProductAsync<T>(int productId)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Type = RequestType.GET,
                Url = $"{services.ProductApiBase}/api/product/{productId}",
                AccessToken = ""
            });
        }

        public async Task<T> UpdateProductAsync<T>(ProductDto productDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Type = RequestType.PUT,
                Url = $"{services.ProductApiBase}/api/product",
                Body = productDto,
                AccessToken = ""
            });
        }
    }
}
