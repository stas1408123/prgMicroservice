using Payment.BLL.Models;
using System.Threading.Tasks;

namespace Payment.BLL.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<bool> BuyAsync(Order order);
    }
}
