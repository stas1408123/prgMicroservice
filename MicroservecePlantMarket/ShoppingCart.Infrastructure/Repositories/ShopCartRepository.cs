using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShoppingCart.DAL.Context;
using ShoppingCart.DAL.Entities;
using ShoppingCart.DAL.Repositories.Interfaces;
using ShoppingCart.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingCart.DAL.Repositories.Implementations
{
    internal class ShopCartRepository : IShopCartRepository
    {
        private readonly ShoppingCartContext _shoppingCartContext;
        private readonly ILogger<ShopCartRepository> _logger;

        public ShopCartRepository(
            ShoppingCartContext shoppingCartContext,
            ILogger<ShopCartRepository> logger)
        {
            _shoppingCartContext = shoppingCartContext;
            _logger = logger;
        }

        public async Task<bool> AddNewShopCartItemAsync(ShopCartItem shopCartItem)
        {
            try
            {
                _shoppingCartContext.ShopCartItems
                    .Add(shopCartItem);

                await _shoppingCartContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogErrorByTemplate(
                    nameof(ShopCartRepository),
                    nameof(AddNewShopCartItemAsync),
                    $"Failed to add new item to cart",
                    ex);

                return false;
            }
        }

        public async Task<ShopCart> CreateShopCartAsync(int userId)
        {
            try
            {
                var newShopCart = new ShopCart
                {
                    UserId = userId,
                };

                await _shoppingCartContext.ShopCarts.AddAsync(newShopCart);

                await _shoppingCartContext.SaveChangesAsync();

                return newShopCart;
            }
            catch (Exception ex)
            {
                _logger.LogErrorByTemplate(
                    nameof(ShopCartRepository),
                    nameof(CreateShopCartAsync),
                    $"Failed creating cart",
                    ex);

                return null;
            }
        }

        public async Task<bool> DeleteShopCartItemAsync(int shopCartItemId)
        {
            try
            {
                var exCartItem = await _shoppingCartContext.ShopCartItems
                    .FirstOrDefaultAsync(item => item.Id == shopCartItemId);

                _shoppingCartContext.ShopCartItems
                    .Remove(exCartItem);

                await _shoppingCartContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogErrorByTemplate(
                    nameof(ShopCartRepository),
                    nameof(DeleteShopCartItemAsync),
                    $"Cannot dalete ShopCart item shopcart id={shopCartItemId}",
                    ex);

                return false;
            }
        }

        public async Task<ICollection<ShopCart>> GetAllShopCartsAsync()
        {
            try
            {
                var shopCarts = await _shoppingCartContext.ShopCarts
                    .Include(item => item.ShopItems)
                    .ToListAsync();

                return shopCarts;
            }
            catch (Exception ex)
            {
                _logger.LogErrorByTemplate(
                    nameof(ShopCartRepository),
                    nameof(GetAllShopCartsAsync),
                    $"Cannot get data from database",
                    ex);

                return null;
            }
        }

        public async Task<ShopCart> GetCartByUserIdAsync(int userId)
        {
            try
            {
                var exShopCart = await _shoppingCartContext.ShopCarts
                    .Include(p => p.ShopItems)
                    .FirstOrDefaultAsync(item => item.UserId == userId);

                return exShopCart;
            }
            catch (Exception ex)
            {
                _logger.LogErrorByTemplate(
                    nameof(ShopCartRepository),
                    nameof(GetCartByUserIdAsync),
                    $"Cannot get data from database",
                    ex);

                return null;
            }
        }
    }
}
