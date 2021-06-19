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
    public class CategoryService : BaseService, ICategoryService
    {
        private readonly ServicesUrl services;

        public CategoryService(IHttpClientFactory clientFactory,IOptions<ServicesUrl> services):base(clientFactory)
        { 
            this.services = services.Value;
        }
        public Task<T> GetCategoryAsync<T>(string token)
        {
            return SendAsync<T>(new ApiRequest()
            {
                AccessToken = "",
                Type = RequestType.GET,
                Url = $"{services.CategoryApiBase}/api/category"
            }) ;
        }

        public Task<T> GetCategoryAsync<T>(int categoryId, string token)
        {
            return SendAsync<T>(new ApiRequest()
            {
                AccessToken = "",
                Type = RequestType.GET,
                Url = $"{services.CategoryApiBase}/api/category/{categoryId}"
            });
        }
    }
}
