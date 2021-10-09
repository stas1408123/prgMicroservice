using Microsoft.AspNetCore.Mvc;
using Ordering.Core.Interfaces;
using Ordering.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlantMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IIdentityService _identityService;

        public OrderController(
            IIdentityService identityService,
            IOrderService orderService)
        {
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
            _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
        }


        [HttpGet]
        [Route("GetAllOrders")]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrdersAsync()
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

            if (order == null)
            {
                return BadRequest();
            }

            return Ok(order);
        }

        [HttpPost]
        [Route("AddNewOrder")]
        public async Task<ActionResult<Order>> AddOrderAsync([FromBody] Order newOrder)
        {
            var Order = await _orderService
                .AddOrderAsync(newOrder);

            if (Order == null)
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

            if (!IsDelete)
            {
                return BadRequest();
            }

            return Ok(IsDelete);
        }

        //[Authorize]
        [HttpGet]
        [Route("GetAllUserOrders")]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllUserOrdersAsync()
        {
            if (!int.TryParse(_identityService.GetUserIdentity(), out int userId))
            {
                return BadRequest();
            }

            var orders = await _orderService
                .GetAllOrdersByUserIdAsync(userId);

            if (orders == null)
            {
                return BadRequest();
            }

            return Ok(orders);
        }

        [HttpGet]
        [Route("GetAllUserOrdersById")]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllUserOrdersByIdAsync(int id)
        {
            var orders = await _orderService
                .GetAllOrdersByUserIdAsync(id);

            if (orders == null)    //??
            {
                return BadRequest();
            }

            return Ok(orders);
        }
    }
}
