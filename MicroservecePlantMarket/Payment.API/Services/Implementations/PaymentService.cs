using Payment.API.Models;
using Payment.API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;

namespace Payment.API.Services.Implementations
{
    public class PaymentService : IPaymentService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PaymentService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> BuyAsync(ShopCart shopCar)
        {
            var client = _httpClientFactory.CreateClient();
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", HttpContext.GetTokenAsync("access_token").GetAwaiter().GetResult());

            Order order = new Order()
            {
                Name = "1",
                SerName = "1",
                Adress = "1",
                Phone = "1",
                Email = "1",
                UserId = 1,
            };

            var content = new StringContent(
                JsonConvert.SerializeObject(order),
                Encoding.UTF8,
                "application/json");

            var result = await client.PostAsync(
                "https://localhost:8001/api/Order/AddNewOrder",
                content);

            if(result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
