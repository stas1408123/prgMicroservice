using Microsoft.AspNetCore.Mvc;
using Payment.BLL.Models;
using Payment.BLL.Services.Interfaces;
using System;
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
            _paymentService = paymentService ?? throw new ArgumentNullException(nameof(paymentService));
        }

        //  метод если пользователь залогинен инфа о заказе из Id token
        [HttpPost]
        [Route("Buy")]
        public async Task<ActionResult<bool>> Buy([FromBody] Order order)
        {
            if(order is null)
            {
                return BadRequest();
            }

            var result = await _paymentService.BuyAsync(order);

            if(result==false)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}
