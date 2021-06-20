using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mango.web.Services.Models
{

    public class CartHeaderDto
    {
        public string UserId { get; set; }
        public string CouponCode { get; set; }
    }
}
