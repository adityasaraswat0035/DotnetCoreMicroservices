using mango.shopping.cart.repository.NonEntities;
using System.Threading.Tasks;

namespace mango.shopping.cart.repository.repositories
{
    public interface ShoppingCartRepository
    {
        Task<Cart> GetCartByUserIdAsync(string userId);
        Task<Cart> CreateUpdateCartAsync(Cart cart);
        Task<bool> RemoveItemFromCartAsync(int CartDetailsId);
        Task<bool> ClearCartAsync(string userId);
    }
}
