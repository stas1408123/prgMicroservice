using Ordering.Infrastructure.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<ICollection<Order>> GetAllAsync();

        Task<Order> GetOrderByIdAsync(int orderId);

        Task<Order> AddOrderAsync(Order newOrder);

        Task<bool> DeleteAsync(int orderId);

        Task<Order> UpdateAsync(Order order);

        Task<ICollection<Order>> GetAllOrdersByUserIdAsync(int userid);
    }
}
