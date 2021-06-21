using mango.coupon.repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mango.order.repository.Entities
{
    [Table("OrderDetail")]
    public class OrderHeader:BaseEntity<int>
    {
        public string UserId { get; set; }
        public string CouponCode { get; set; }
        public double CartTotal { get; set; }
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
        public IEnumerable<OrderDetails> OrderDetails { get; set; }
        public bool PaymentStatus { get; set; }
    }
}
