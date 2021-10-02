
using ShoppingCart.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Core.Interfaces
{
    public interface IShopCartService
    {
        Task<bool> AddNewShopCartItemAsync(ShopCartItem shopCartItem);

        Task<bool> DeleteShopCartItemAsync(int shopCartItemId);

        Task<ShopCart> CreateShopCartAsync(int userId);

        Task<ShopCart> GetCartByUserIdAsync(int userId);

        Task<List<ShopCart>> GetAllShopCartsAsync();
    }
}
