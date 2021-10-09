using ShoppingCart.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingCart.DAL.Repositories.Interfaces
{
    public interface IShopCartRepository
    {
        Task<bool> DeleteShopCartItemAsync(int shopCartItemId);

        Task<ShopCart> CreateShopCartAsync(int userId);

        Task<ShopCart> GetCartByUserIdAsync(int userId);

        Task<ICollection<ShopCart>> GetAllShopCartsAsync();

        Task<bool> AddNewShopCartItemAsync(ShopCartItem shopCartItem);
    }
}
