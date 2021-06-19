using System.ComponentModel.DataAnnotations.Schema;

namespace mango.shopping.cart.contracts.dtos
{

    public class CartDetailDto
    {
        public int CartHeaderId { get; set; }
        public CartHeaderDto CartHeader { get; set; }
        public ProductDto Product { get; set; }
        public int Count { get; set; }
    }
}
