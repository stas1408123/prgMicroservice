using Microsoft.Extensions.Logging;
using Ordering.Core.Interfaces;
using Ordering.Infrastructure.Entities;
using Ordering.Infrastructure.Repositories.Interfaces;
using Ordering.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ordering.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<OrderService> _logger;

        public OrderService(IOrderRepository orderRepository,
            ILogger<OrderService> logger)
        {
            _orderRepository = orderRepository;
            _logger = logger;
        }
        public async Task<List<Order>> GetAllAsync()
        {
            try
            {

                return await _orderRepository.GetAllAsync(); ;
            }
            catch (Exception ex)
            {
                _logger.LogErrorByTemplate(
                    nameof(OrderService),
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

                return await _orderRepository.GetOrderByIdAsync(orderId);
            }
            catch (Exception ex)
            {
                _logger.LogErrorByTemplate(
                    nameof(OrderService),
                    nameof(GetOrderByIdAsync),
                    $"Cannot get order id={orderId} from database",
                    ex);

                return null;
            }

        }

        public async Task<Order> AddOrderAsync(Order newOrder)
        {
            if (newOrder is null || newOrder.Id != 0)
            {
                return null;
            }

            try
            {
                return await _orderRepository.AddOrderAsync(newOrder);
            }
            catch (Exception ex)
            {
                _logger.LogErrorByTemplate(
                    nameof(OrderService),
                    nameof(AddOrderAsync),
                    $"Failed add order to database",
                    ex);

                return null;
            }
        }

        public async Task<bool> DeleteAsync(int orderId)
        {
            if (orderId == 0)
            {
                return false;
            }
            try
            {

                return await _orderRepository.DeleteAsync(orderId);
            }
            catch (Exception ex)
            {
                _logger.LogErrorByTemplate(
                    nameof(OrderService),
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
                return await _orderRepository.UpdateAsync(order);
            }
            catch (Exception ex)
            {
                _logger.LogErrorByTemplate(
                    nameof(OrderService),
                    nameof(UpdateAsync),
                    $"Cannot update order",
                    ex);

                return null;
            }

        }

        public async Task<IEnumerable<Order>> GetAllOrdersByUserIdAsync(int userId)
        {
            return await _orderRepository.GetAllOrdersByUserIdAsync(userId);
        }
    }
}
