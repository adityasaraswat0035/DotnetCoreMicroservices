using mango.web.Configuration;
using mango.web.Services.Contracts;
using mango.web.Services.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace mango.web.Services.Impl
{
    public class CartService : BaseService, ICartService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ServicesUrl services;
        public CartService(IHttpClientFactory httpClientFactory, IOptions<ServicesUrl> services) : base(httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
            this.services = services.Value;
        }
        public async Task<T> AddToCartAsync<T>(CartDto cartDto, string token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Type = RequestType.POST,
                Body = cartDto,
                Url = $"{services.ShoppingCartApiBase}/api/cart",
                AccessToken = token
            });
        }

        public async Task<T> GetCartByUserIdAsync<T>(string userId, string token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Type = RequestType.GET,
                Url = $"{services.ShoppingCartApiBase}/api/cart/{userId}",
                AccessToken = token
            });
        }

        public async Task<T> RemoveFromCartAsync<T>(int cartDetailId, string token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Type = RequestType.DELETE,
                Url = $"{services.ShoppingCartApiBase}/api/cart/{cartDetailId}",
                AccessToken = token
            });
        }

        public async Task<T> UpdateCartAsync<T>(CartDto cartDto, string token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Type = RequestType.PUT,
                Url = $"{services.ShoppingCartApiBase}/api/cart/",
                Body= cartDto,
                AccessToken = token
            });
        }
    }
}
