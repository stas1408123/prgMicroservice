using ShoppingCart.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingCart.BLL.Interfaces
{
    public interface IShopCartService
    {
        Task<bool> AddNewShopCartItemAsync(ShopCartItem shopCartItem);

        Task<bool> DeleteShopCartItemAsync(int shopCartItemId);

        Task<ShopCart> CreateShopCartAsync(int userId);

        Task<ShopCart> GetCartByUserIdAsync(int userId);

        Task<IEnumerable<ShopCart>> GetAllShopCartsAsync();
    }
}
