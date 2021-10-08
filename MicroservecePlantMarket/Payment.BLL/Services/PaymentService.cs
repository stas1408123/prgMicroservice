using Payment.BLL.Api.Client;
using Payment.BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Order = Payment.BLL.Models.Order;
using OrderClientModel = Payment.BLL.Api.Client.Order;
using OrderedPlant = Payment.BLL.Models.OrderedPlant;
using OrderedPlantClientModel = Payment.BLL.Api.Client.OrderedPlant;


namespace Payment.BLL.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly OrderClient _orderOrderClient;

        private readonly ShopCartClient _shopCartClient;

        public PaymentService(
            OrderClient orderOrderClient,
            ShopCartClient shopCartClient)
        {
            _orderOrderClient = orderOrderClient;
            _shopCartClient = shopCartClient;
        }

        public async Task<bool> BuyAsync(Order order)
        {
            await _orderOrderClient.AddOrderAsync(OrderMappers.MapperToOrderClientModel(order));

            foreach(var OrderedItem in order.OrderedPlants)
            {
                //await _shopCartClient.DeleteShopCartItemAsync(OrderedItem.Id);
            }

            return true;
        }
       
    }

    public static class OrderMappers
    {
        public static OrderClientModel MapperToOrderClientModel(this Order order)
        {
            return new OrderClientModel()
            {
                Id = 0,
                UserId = order.UserId,
                Name = order.Name,
                SerName = order.SerName,
                Phone = order.Phone,
                Adress = order.Adress,
                Email = order.Email,
                CreationDate = DateTime.Now,
                OrderedPlants = OrderedItemMappers.MapperCollectionToOrderedPlantClientModel(order.OrderedPlants),
            };
        }
    }

    public static class OrderedItemMappers 
    {
        public static OrderedPlantClientModel MapperToOrderedPlantClientModel(this OrderedPlant orderedPlant)
        {
            return new OrderedPlantClientModel()
            {
                Id=0,
                PlantId=orderedPlant.PlantId,
                PictureLink=orderedPlant.PictureLink,
                ProductName=orderedPlant.ProductName,
                Price =orderedPlant.Price,
            };
        }

        public static List<OrderedPlantClientModel> MapperCollectionToOrderedPlantClientModel(this List<OrderedPlant> orderedPlants)
        {
            List<OrderedPlantClientModel> orderedPlantClientModels = new List<OrderedPlantClientModel>();

            foreach(OrderedPlant item in orderedPlants)
            {
                orderedPlantClientModels.Add(MapperToOrderedPlantClientModel(item));
            }

            return orderedPlantClientModels;
        }
    }


}
