using Microsoft.AspNetCore.Mvc;
using Ordering.Core.Interfaces;
using Ordering.Infrastructure.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlantMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }


        [HttpGet]
        [Route("GetAllOrders")]
        public async Task<ActionResult<List<Order>>> GetAllOrdersAsync()
        {
            var orders = await _orderService
                .GetAllAsync();

            if (orders == null)
            {
                return BadRequest();
            }

            return Ok(orders);
        }


        [HttpGet]
        [Route("GetOrderById")]
        public async Task<ActionResult<Order>> GetOrderByIdAsync(int id)
        {
            var order = await _orderService
                .GetOrderByIdAsync(id);

            if(order==null)
            {
                return BadRequest();
            }

            return Ok(order);
        }


        [HttpPost]
        [Route("AddNewOrder")]
        public async Task<ActionResult<Order>> AddOrderAsync([FromBody]Order newOrder)
        {
            var Order = await _orderService
                .AddOrderAsync(newOrder);

            if(Order==null)
            {
                return BadRequest(); 
            }
            return Ok(Order);

        }

        [HttpDelete]
        [Route("DeleteOrder")]
        public async Task<ActionResult<bool>> DeleteOrderAsync(int id)
        {

            var IsDelete = await _orderService
                .DeleteAsync(id);

            if(!IsDelete)
            {
                return BadRequest();
            }

            return Ok(IsDelete);
        }

        //[HttpGet]
        //[Route("GetAllUserOrders")]
        //public async Task<ActionResult<List<Order>>> GetAllUserOrdersAsync()
        //{
        //    var userIdString = User.FindFirst("userid")?.Value;

        //    if (!int.TryParse(userIdString, out int userId))
        //    {
        //        return BadRequest();
        //    }

        //    var user = await _userService
        //        .GetUserById(userId);

        //    var orders = await _orderService
        //        .GetAllUserAsync(user);

        //    if (orders == null)
        //    {
        //        return BadRequest();
        //    }

        //    return Ok(orders);
        //}

    }
}
