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
    public class CouponService : BaseService, ICouponService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ServicesUrl services;
        public CouponService(IHttpClientFactory httpClientFactory, IOptions<ServicesUrl> services) : base(httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
            this.services = services.Value;
        }
        public async Task<T> GetCouponByCode<T>(string couponCode, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Type = RequestType.GET,
                Url = $"{services.CouponApiBase}/api/coupon/{couponCode}",
                AccessToken = token
            });
        }
    }
}
