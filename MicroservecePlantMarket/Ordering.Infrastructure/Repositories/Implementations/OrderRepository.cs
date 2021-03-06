using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Ordering.Infrastructure.Context;
using Ordering.Infrastructure.Entities;
using Ordering.Infrastructure.Repositories.Interfaces;
using Ordering.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Repositories.Implementations
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext _orderContext;
        private readonly ILogger<OrderRepository> _logger;

        public OrderRepository(OrderContext orderContext,
            ILogger<OrderRepository> logger)
        {
            _orderContext = orderContext;
            _logger = logger;
        }

        public async Task<ICollection<Order>> GetAllAsync()
        {
            try
            {
                var orders = await _orderContext.Orders
                    .Include(item => item.OrderedPlants)
                    .ToListAsync();

                return orders;
            }
            catch (Exception ex)
            {
                _logger.LogErrorByTemplate(
                    nameof(OrderRepository),
                    nameof(GetAllAsync),
                    $"Cannot get data from database",
                    ex);

                return null;
            }
        }

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            try
            {
                var order = await _orderContext.Orders
                    .Include(item => item.OrderedPlants)
                    .FirstOrDefaultAsync(item => item.Id == orderId);

                return order;
            }
            catch (Exception ex)
            {
                _logger.LogErrorByTemplate(
                    nameof(OrderRepository),
                    nameof(GetOrderByIdAsync),
                    $"Cannot get order id={orderId} from database",
                    ex);

                return null;
            }
        }

        public async Task<Order> AddOrderAsync(Order newOrder)
        {
            try
            {
                _orderContext.Orders
                    .Add(newOrder);

                await _orderContext.SaveChangesAsync();

                var exOrder = await _orderContext.Orders
                    .FirstOrDefaultAsync(item => item.CreationDate == newOrder.CreationDate
                        && item.UserId == newOrder.UserId);

                return exOrder;
            }
            catch (Exception ex)
            {
                _logger.LogErrorByTemplate(
                    nameof(OrderRepository),
                    nameof(AddOrderAsync),
                    $"Failed add order to database",
                    ex);

                return null;
            }
        }

        public async Task<bool> DeleteAsync(int orderId)
        {
            try
            {
                var exOrder = await _orderContext.Orders
                        .Include(item => item.OrderedPlants)
                        .FirstOrDefaultAsync(item => item.Id == orderId);

                await _orderContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogErrorByTemplate(
                    nameof(OrderRepository),
                    nameof(DeleteAsync),
                    $"Cannot delete order id ={orderId}",
                    ex);

                return false;
            }
        }

        public async Task<Order> UpdateAsync(Order order)
        {
            if (order is null)
            {
                return null;
            }
            try
            {
                var exOrder = await _orderContext.Orders
                        .Include(item => item.OrderedPlants)
                        .FirstOrDefaultAsync(item => item.Id == order.Id);

                if (exOrder != null)
                {
                    exOrder.UserId = order.UserId;

                    if (exOrder.OrderedPlants.Count != 0)
                    {
                        _orderContext.OrderedPlants
                            .RemoveRange(exOrder.OrderedPlants);
                    }

                    exOrder.OrderedPlants.AddRange(order.OrderedPlants);
                }

                await _orderContext.SaveChangesAsync();

                return exOrder;
            }
            catch (Exception ex)
            {
                _logger.LogErrorByTemplate(
                    nameof(OrderRepository),
                    nameof(UpdateAsync),
                    $"Cannot update order",
                    ex);

                return null;
            }
        }

        public async Task<ICollection<Order>> GetAllOrdersByUserIdAsync(int userid)
        {
            try
            {
                var orders = await _orderContext.Orders
                    .Include(item => item.OrderedPlants)
                    .Where(order => order.UserId == userid)
                    .ToListAsync();

                return orders;
            }
            catch (Exception ex)
            {
                _logger.LogErrorByTemplate(
                    nameof(OrderRepository),
                    nameof(GetAllOrdersByUserIdAsync),
                    $"Cannot get order by user ID",
                    ex);

                return null;
            }
        }
    }
}
