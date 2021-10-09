using ShoppingCart.BLL.Interfaces;
using ShoppingCart.DAL.Entities;
using ShoppingCart.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingCart.BLL.Services
{
    internal class ShopCartService : IShopCartService
    {
        private readonly IShopCartRepository _shopCartRepository;

        public ShopCartService(IShopCartRepository shopCartRepository)
        {
            _shopCartRepository = shopCartRepository ?? throw new ArgumentNullException(nameof(shopCartRepository));
        }

        public async Task<bool> AddNewShopCartItemAsync(ShopCartItem shopCartItem)
        {
            return await _shopCartRepository.AddNewShopCartItemAsync(shopCartItem);
        }

        public async Task<ShopCart> CreateShopCartAsync(int userId)
        {
            return await _shopCartRepository.CreateShopCartAsync(userId);
        }

        public async Task<bool> DeleteShopCartItemAsync(int shopCartItemId)
        {
            return await _shopCartRepository.DeleteShopCartItemAsync(shopCartItemId);
        }

        public async Task<ShopCart> GetCartByUserIdAsync(int userId)
        {
            return await _shopCartRepository.GetCartByUserIdAsync(userId);
        }

        public async Task<IEnumerable<ShopCart>> GetAllShopCartsAsync()
        {
            return await _shopCartRepository.GetAllShopCartsAsync();
        }
    }
}
