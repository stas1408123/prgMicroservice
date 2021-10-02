using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payment.API.Models;
using Payment.API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopCartController : Controller
    {

        private readonly IPaymentService _paymentService;

        public ShopCartController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        [Route("Buy")]
        public async Task<ActionResult<bool>> Buy([FromBody] ShopCart shopCart)
        {
            if(shopCart is null)
            {
                return BadRequest();
            }

            var result = await _paymentService.BuyAsync(shopCart);

            if(result==false)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}
