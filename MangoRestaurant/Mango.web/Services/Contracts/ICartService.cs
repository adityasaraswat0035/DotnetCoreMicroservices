using mango.web.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mango.web.Services.Contracts
{
    public interface ICartService
    {
        Task<T> GetCartByUserIdAsync<T>(string userId,string token=null);
        Task<T> AddToCartAsync<T>(CartDto cartDto,string token=null);
        Task<T> UpdateCartAsync<T>(CartDto cartDto, string token = null);
        Task<T> RemoveFromCartAsync<T>(int cartDetailId,string token=null);
        Task<T> RemoveCouponOnCartAsync<T>(CartDto cartDto,string token=null);
        Task<T> ApplyCouponOnCartAsync<T>(CartDto cartDto, string token = null);

    }
}
