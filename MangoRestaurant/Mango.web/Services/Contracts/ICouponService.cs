using mango.web.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mango.web.Services.Contracts
{
    public interface ICouponService
    {
        Task<T> GetCouponByCode<T>(string couponCode,string token);

    }
}
