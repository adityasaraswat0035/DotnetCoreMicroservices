using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mango.shopping.cart.repository.Entities
{
    [Table("CartDetail")]
    public class CartDetail : BaseEntity<int>
    {
        [Column("CartHeaderId")]
        public int CartHeaderId { get; set; }
        public virtual CartHeader CartHeader { get; set; }
        public virtual Product Product { get; set; }
        [Column("ItemQuantity")]
        public int Count { get; set; }
    }
}
