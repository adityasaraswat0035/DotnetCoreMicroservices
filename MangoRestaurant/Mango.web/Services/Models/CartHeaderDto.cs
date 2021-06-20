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
        public double CartTotal { get; set; }
        public int Id { get; set; }
        public double discountTotal { get; set; }

        //For Processing Order  
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        [DataType(DataType.Date)]
        public DateTime PickupDateTime { get; set; } = DateTime.Now;
        public string Phone { get; set; }
        public string Email { get; set; }
        public string CardNumber { get; set; }
        public string CVV { get; set; }
        public string ExpiryMonthYear { get; set; }
    }
}
