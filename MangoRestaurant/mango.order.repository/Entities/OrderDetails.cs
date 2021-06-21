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
    public class OrderDetails : BaseEntity<int>
    {
        public int OrderHeaderId { get; set; }
        public OrderHeader OrderHeader { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
    }
}
