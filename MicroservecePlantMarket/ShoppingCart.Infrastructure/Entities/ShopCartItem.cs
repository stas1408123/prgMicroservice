using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCart.Infrastructure.Entities
{
    public class ShopCartItem
    {

        [Key]
        public int Id { get; set; }

        public int PlantId { get; set; }

        [ForeignKey("ShopCartId")]
        public virtual ShopCart ShopCart { get; set; }

        public int ShopCartId { get; set; }
    }
}
