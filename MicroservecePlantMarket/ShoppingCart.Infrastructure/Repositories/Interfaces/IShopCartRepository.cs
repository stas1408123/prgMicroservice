using ShoppingCart.Infrastructure.Entities;
using System.Collections.Generic;
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
