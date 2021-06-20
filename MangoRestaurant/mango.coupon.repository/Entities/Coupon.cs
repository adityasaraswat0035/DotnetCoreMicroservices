using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mango.coupon.repository.Entities
{
    public class Coupon:BaseEntity<int>
    {
        public string CouponCode { get; set; }
        public double DiscountAmount { get; set; }
    }
}
