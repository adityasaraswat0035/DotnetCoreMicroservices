using mango.integration.kafka.Contract;
using mango.shopping.cart.contracts.dtos;
using mango.shopping.cart.repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mango.shopping.cart.api.Messages
{
    public class CheckoutHeaderDto:IMessage
    {
        public string UserId { get; set; }
        public string CouponCode { get; set; }
        public double CartTotal { get; set; }
        public int Id { get; set; }
        public double discountTotal { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime PickupDateTime { get; set; } = DateTime.Now;
        public string Phone { get; set; }
        public string Email { get; set; }
        public string CardNumber { get; set; }
        public string CVV { get; set; }
        public string ExpiryMonthYear { get; set; }
        public int TotalItems { get; set; }
        public IEnumerable<CartDetailDto> CartDetails { get; set; }
    }
}
