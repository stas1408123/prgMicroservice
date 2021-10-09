using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCart.DAL.Entities
{
    public class ShopCartItem
    {
        [Key]
        public int Id { get; set; }

        public int PlantId { get; set; }

        public string ProductName { get; set; }

        public string PictureLink { get; set; }

        public double Price { get; set; }

        [ForeignKey("ShopCartId")]
        public virtual ShopCart ShopCart { get; set; }

        public int ShopCartId { get; set; }
    }
}
