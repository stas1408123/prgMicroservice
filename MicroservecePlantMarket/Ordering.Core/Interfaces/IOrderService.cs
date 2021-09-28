﻿using Ordering.Infrastructure.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ordering.Core.Interfaces
{
    public interface IOrderService
    {
        Task<List<Order>> GetAllAsync();

        Task<Order> GetOrderByIdAsync(int orderId);

        Task<Order> AddOrderAsync(Order newOrder);

        Task<bool> DeleteAsync(int orderId);

        Task<Order> UpdateAsync(Order order);
    }
}