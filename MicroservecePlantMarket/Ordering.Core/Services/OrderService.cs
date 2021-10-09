using Ordering.Core.Interfaces;
using Ordering.Infrastructure.Entities;
using Ordering.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ordering.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _orderRepository.GetAllAsync(); ;
        }

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            return await _orderRepository.GetOrderByIdAsync(orderId);
        }

        public async Task<Order> AddOrderAsync(Order newOrder)
        {
            return await _orderRepository.AddOrderAsync(newOrder);
        }

        public async Task<bool> DeleteAsync(int orderId)
        {
            return await _orderRepository.DeleteAsync(orderId);
        }

        public async Task<Order> UpdateAsync(Order order)
        {
            return await _orderRepository.UpdateAsync(order);
        }

        public async Task<IEnumerable<Order>> GetAllOrdersByUserIdAsync(int userId)
        {
            return await _orderRepository.GetAllOrdersByUserIdAsync(userId);
        }
    }
}
