using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mango.shopping.cart.contracts.dtos
{

    public class CartHeaderDto
    {
        public string UserId { get; set; }
        public string CouponCode { get; set; }
    }
}
