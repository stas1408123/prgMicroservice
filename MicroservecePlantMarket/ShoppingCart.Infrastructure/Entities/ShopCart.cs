using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Infrastructure.Entities
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
