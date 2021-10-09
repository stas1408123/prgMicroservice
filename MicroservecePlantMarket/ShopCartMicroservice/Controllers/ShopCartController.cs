using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Api.Services.Interfaces;
using ShoppingCart.BLL.Interfaces;
using ShoppingCart.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopCartMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopCartController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        private readonly IShopCartService _shopCartService;

        public ShopCartController(
            IIdentityService identityService, 
            IShopCartService shopCartService)
        {
            _shopCartService = shopCartService ?? throw new ArgumentNullException(nameof(shopCartService));
            _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
        }

        [HttpGet]
        public async Task<IEnumerable<ShopCart>> GetAllCart()
        {
            var products = await _shopCartService
                .GetAllShopCartsAsync();

            return products;
        }


        [Route("DeleteShopCartItem/{shopCartItemid}")]
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteShopCartItemAsync(int shopCartItemid)
        {
            await _shopCartService
                .DeleteShopCartItemAsync(shopCartItemid);
            /// если не проходит то кидаем эксепшен

            return Ok();
        }

        [Route("CreateCart")]
        [HttpPost]
        public async Task<ActionResult<ShopCart>> CreateShopCart(int userId)
        {

            var exUser = await _shopCartService
                .CreateShopCartAsync(userId);

            if (exUser==null)
            {
                return BadRequest();
            }

            return Ok(exUser);
        }

        [Route("GetCartByUserId")]
        [HttpGet]
        public async Task<ActionResult<ShopCart>> GetShopCartByUser(int userId)
        {

            var exCart = await _shopCartService
                .GetCartByUserIdAsync(userId);

            if (exCart == null)
            {
                return BadRequest();
            }

            return Ok(exCart);
        }

        [HttpGet]
        [Route("GetShopCart")]
        public async Task<ActionResult<ShopCart>> GetShopCart()
        {

            if (!int.TryParse(_identityService.GetUserIdentity(), out int userId))
            {
                return BadRequest();
            }

            var exCart = await _shopCartService
                .GetCartByUserIdAsync(userId);

            if (exCart == null)
            {
                return BadRequest();
            }

            return Ok(exCart);
        }


        [HttpPost]
        [Route("AddPlantToCart")]
        public async Task<ActionResult<bool>> AddPlantToCart([FromBody] ShopCartItem shopCartItem)
        {

            var IsAdd = await _shopCartService
                .AddNewShopCartItemAsync(shopCartItem);

            if (!IsAdd)
            {
                return BadRequest();
            }

            return Ok(IsAdd);
        }
    }
}
