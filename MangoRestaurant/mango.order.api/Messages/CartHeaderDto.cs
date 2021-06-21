using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mango.order.api.Messages
{
    public class CartHeaderDto
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string CouponCode { get; set; }
    }
}
