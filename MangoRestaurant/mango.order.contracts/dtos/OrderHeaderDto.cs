using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mango.order.contracts.dtos
{
    public class OrderHeaderDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string CouponCode { get; set; }
        public double OrderTotal { get; set; }
        public double DiscountTotal { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime PickupDateTime { get; set; } = DateTime.Now;
        public DateTime OrderTime { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string CardNumber { get; set; }
        public string CVV { get; set; }
        public string ExpiryMonthYear { get; set; }
        public int TotalItems { get; set; }
        public List<OrderDetailsDto> OrderDetails { get; set; }
        public bool PaymentStatus { get; set; }
    }
}
