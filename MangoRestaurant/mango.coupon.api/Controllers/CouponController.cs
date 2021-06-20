using mango.coupon.api.Controllers.Base;
using mango.coupon.contracts.contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mango.coupon.api.Controllers
{
    [Route("api/coupon")]
    [ApiController]
    public class CouponController : ApiBaseController
    {
        private CouponManager couponManager;
        public CouponController(CouponManager couponManager)
        {
            this.couponManager = couponManager;
        }

        [HttpGet]
        [Route("{couponCode}")]
        public async Task<IActionResult> Get(string couponCode)
        {
            return OptionalOK(await couponManager.GetCouponByCodeAsync(couponCode));
        }
    }
}
