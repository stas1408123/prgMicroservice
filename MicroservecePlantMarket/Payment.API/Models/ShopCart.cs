using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Payment.API.Models
{
    public record ShopCart
    {
        public int Id { get; init; }
        public double Price { get; init; }
        public int UserId { get; init; }
        public List<ShopCartItem> ShopItems { get; init; }
    }
}
