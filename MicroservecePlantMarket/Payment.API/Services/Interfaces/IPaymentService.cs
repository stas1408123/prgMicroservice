using Payment.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.API.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<bool> BuyAsync(ShopCart shopCar);
    }
}
