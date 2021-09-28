using ShoppingCart.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Infrastructure.Repositories.Interfaces
{
    public interface IShopCartRepository
    {
        Task<ShopCart> Update(ShopCart shopCart);

        Task<bool> DeleteShopCartItemAsync(int shopCartItemId);

        Task<ShopCart> CreateShopCartAsync(int userId);

        Task<ShopCart> GetCartByUserIdAsync(int userId);

        Task<List<ShopCart>> GetAllShopCartsAsync();

        Task<bool> AddNewShopCartItemAsync(ShopCartItem shopCartItem);
    }
}
