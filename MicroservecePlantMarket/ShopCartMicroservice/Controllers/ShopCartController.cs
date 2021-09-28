using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Core.Interfaces;
using ShoppingCart.Infrastructure.Entities;
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
            _shopCartService = shopCartService;
            _identityService = identityService;
        }


        [HttpGet]
        public async Task<ActionResult<List<ShopCart>>> GetAllCart()
        {
            var products = await _shopCartService
                .GetAllShopCartsAsync();

            if (products is null)
            {
                return BadRequest();
            }

            return Ok(products);
        }


        [Route("DeleteShopCartItem/{shopCartItemid}")]
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteShopCartItemAsync(int shopCartItemid)
        {
            var isDelete = await _shopCartService
                .DeleteShopCartItemAsync(shopCartItemid);

            if (isDelete == false)
            {
                return BadRequest();
            }

            return Ok(isDelete);

        }

        [HttpPost]
        public async Task<ActionResult<bool>> AddNewPlantToCart([FromBody] ShopCartItem shopCartItem)
        {

            var IsAdd = await _shopCartService
                .AddNewShopCartItemAsync(shopCartItem);

            if (!IsAdd)
            {
                return BadRequest();
            }

            return Ok(IsAdd);
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

            //if (!int.TryParse(_identityService.GetUserIdentity(), out int userId))
            //{
            //    return BadRequest();
            //}


            var IsAdd = await _shopCartService
                .AddNewShopCartItemAsync(shopCartItem);

            if (!IsAdd)
            {
                return BadRequest();
            }

            return Ok(IsAdd);
        }

        //[HttpPost]
        //[Route("Buy")]
        //public async Task<ActionResult<Order>> Buy([FromBody] ShopCart shopCar)
        //{
            

        //    var result = await _shopCartService.BuyAsync(shopCar);


        //    if (result == null)
        //    {
        //        return BadRequest();
        //    }

        //    return Ok(result);
        //}


    }
}
