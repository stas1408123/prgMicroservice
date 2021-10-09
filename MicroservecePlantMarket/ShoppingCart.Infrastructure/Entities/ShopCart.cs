using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.DAL.Entities
{
    public class ShopCart
    {
        [Key]
        public int Id { get; set; }

        public double Price { get; set; }

        public int UserId { get; set; }

        public List<ShopCartItem> ShopItems { get; set; }
    }
}
