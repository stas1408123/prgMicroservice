using Microsoft.Extensions.Logging;
using ShoppingCart.Core.Interfaces;
using ShoppingCart.Infrastructure.Entities;
using ShoppingCart.Infrastructure.Repositories.Interfaces;
using ShoppingCart.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Core.Services
{
    public class ShopCartService : IShopCartService
    {
        private readonly IShopCartRepository _shopCartRepository;
        private readonly ILogger<ShopCartService> _logger;

        public ShopCartService(
            IShopCartRepository shopCartRepository,
            ILogger<ShopCartService> logger)
        {
            _shopCartRepository = shopCartRepository;
            _logger = logger;
        }

        public async Task<bool> AddNewShopCartItemAsync(ShopCartItem shopCartItem)
        {
            return await _shopCartRepository.AddNewShopCartItemAsync(shopCartItem);
        }

        public async Task<ShopCart> CreateShopCartAsync(int userId)
        {
            try
            {
                return await _shopCartRepository.CreateShopCartAsync(userId);
            }
            catch (Exception ex)
            {
                _logger.LogErrorByTemplate(
                    nameof(ShopCartService),
                    nameof(CreateShopCartAsync),
                    "Failed creating cart",
                    ex);

                return null;
            }

        }

        public async Task<bool> DeleteShopCartItemAsync(int shopCartItemId)
        {
            try
            {
                return await _shopCartRepository.DeleteShopCartItemAsync(shopCartItemId);
            }
            catch (Exception ex)
            {
                _logger.LogErrorByTemplate(
                    nameof(ShopCartService),
                    nameof(DeleteShopCartItemAsync),
                    $"Cannot dalete ShopCart item shopcart id={shopCartItemId}",
                    ex);

                return false;
            }

        }


        public async Task<ShopCart> GetCartByUserIdAsync(int userId)
        {
            try
            {
                return await _shopCartRepository.GetCartByUserIdAsync(userId);
            }
            catch (Exception ex)
            {
                _logger.LogErrorByTemplate(
                    nameof(ShopCartService),
                    nameof(GetCartByUserIdAsync),
                    $"Cannot get data from database",
                    ex);

                return null;
            }

        }


        public async Task<List<ShopCart>> GetAllShopCartsAsync()
        {
            try
            {
                return await _shopCartRepository.GetAllShopCartsAsync();
            }
            catch (Exception ex)
            {
                _logger.LogErrorByTemplate(
                    nameof(ShopCartService),
                    nameof(GetAllShopCartsAsync),
                    $"Cannot get data from database",
                    ex);

                return null;
            }
        }

        public Task<ShopCart> GetCartByUserIDAsync(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
