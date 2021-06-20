using mango.shopping.cart.repository.DbContexts;
using mango.shopping.cart.repository.NonEntities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace mango.shopping.cart.repository.repositories.impl
{
    public class ShoppingCartRepositoryImpl : ShoppingCartRepository
    {
        private readonly ShoppingCartDbContext shoppingCartDb;

        public ShoppingCartRepositoryImpl(ShoppingCartDbContext shoppingCartDb)
        {
            this.shoppingCartDb = shoppingCartDb;
        }

        public async Task<bool> ClearCartAsync(string userId)
        {
            var userCart = await shoppingCartDb.CartHeaders.FirstOrDefaultAsync(x => x.UserId == userId);
            if (userCart != null)
            {
                shoppingCartDb.CartHeaders.Remove(userCart);
                await shoppingCartDb.SaveChangesAsync();
            }
            return true;
        }

        public async Task<Cart> CreateUpdateCartAsync(Cart cart)
        {
            var productInDb = await shoppingCartDb.Products.FirstOrDefaultAsync(x => x.Id == cart.CartDetails.FirstOrDefault().Product.Id);
            if (productInDb == null)
            {
                shoppingCartDb.Products.Add(cart.CartDetails.FirstOrDefault().Product);
                await shoppingCartDb.SaveChangesAsync();
            }
            var userCartInDb = await shoppingCartDb.CartHeaders.AsNoTracking().FirstOrDefaultAsync(x => x.UserId == cart.CartHeader.UserId);
            if (userCartInDb == null)
            {
                shoppingCartDb.CartHeaders.Add(cart.CartHeader);
                await shoppingCartDb.SaveChangesAsync();
                cart.CartDetails.FirstOrDefault().CartHeaderId = cart.CartHeader.Id;
                cart.CartDetails.FirstOrDefault().Product = null;
                shoppingCartDb.CartDetails.Add(cart.CartDetails.FirstOrDefault());
                await shoppingCartDb.SaveChangesAsync();

            }
            else
            {
                var cartDetailsFromDb = await shoppingCartDb.CartDetails.AsNoTracking().
                    FirstOrDefaultAsync(u => u.Product.Id == cart.CartDetails.FirstOrDefault().Product.Id && u.CartHeaderId == cart.CartHeader.Id);
                if (cartDetailsFromDb == null)
                {
                    cart.CartDetails.FirstOrDefault().CartHeaderId = cartDetailsFromDb.CartHeaderId;
                    cart.CartDetails.FirstOrDefault().Product = null;
                    shoppingCartDb.CartDetails.Add(cart.CartDetails.FirstOrDefault());
                    await shoppingCartDb.SaveChangesAsync();
                }
                else
                {
                    cart.CartDetails.FirstOrDefault().Count += cartDetailsFromDb.Count + cart.CartDetails.FirstOrDefault().Count;
                    cart.CartDetails.FirstOrDefault().Product = null;
                    shoppingCartDb.CartDetails.Update(cart.CartDetails.FirstOrDefault());
                    await shoppingCartDb.SaveChangesAsync();
                }

            }

            return cart;
        }

        public async Task<Cart> GetCartByUserIdAsync(string userId)
        {
            var userCart = await shoppingCartDb.CartHeaders.Include(x => x.CartDetail).ThenInclude(x => x.Product).FirstOrDefaultAsync(x => x.UserId == userId);
            return new Cart()
            {
                CartHeader = userCart,
                CartDetails = userCart.CartDetail
            };
        }

        public async Task<bool> RemoveItemFromCartAsync(int CartDetailsId)
        {
            try
            {
                var cartDetails = await shoppingCartDb.CartDetails.FirstOrDefaultAsync(x => x.Id == CartDetailsId);
                int totalCartProduct = shoppingCartDb.CartDetails.Where(u => u.CartHeaderId == cartDetails.CartHeaderId).Count();
                shoppingCartDb.Remove(cartDetails);
                if (totalCartProduct == 1)
                {
                    var cartHeader = await shoppingCartDb.CartHeaders.FirstOrDefaultAsync(x => x.Id == cartDetails.CartHeaderId);
                    shoppingCartDb.Remove(cartHeader);
                }
                await shoppingCartDb.SaveChangesAsync();
                return true;
            }
            catch (System.Exception ex)
            {
                //log error
                throw;
            }
        }
    }
}
