using mango.infrstructure.common.Wrappers;
using mango.shopping.cart.contracts.dtos;
using System.Threading.Tasks;

namespace mango.shopping.cart.contracts.contracts
{
    public interface ShoppingCartManager
    {
        Task<Optional<CartDto>> GetCartByUserIdAsync(string userId);
        Task<CartDto> CreateUpdateCartAsync(CartDto cartDto);
        Task<bool> RemoveItemFromCartAsync(int CartDetailsId);
        Task<bool> ClearCartAsync(string userId);
    }
}
