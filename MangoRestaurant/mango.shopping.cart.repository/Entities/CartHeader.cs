using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mango.shopping.cart.repository.Entities
{
    [Table("CartHeader")]
    public class CartHeader:BaseEntity<int>
    {
        [Column("UserId")]
        [Required]
        public string UserId { get; set; }
        [Column("CouponCode")]
        public string CouponCode { get; set; }
        public virtual List<CartDetail> CartDetail { get; set; }

    }
}
