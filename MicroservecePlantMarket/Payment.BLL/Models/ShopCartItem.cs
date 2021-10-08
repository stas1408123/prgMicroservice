using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Payment.BLL.Models
{
    public record ShopCartItem
    {
        public int Id { get; init; }
        public int PlantId { get; init; }
        public string ProductName { get; init; }
        public string PictureLink { get; init; }
        public double Price { get; init; }
        public virtual ShopCart ShopCart { get; init; }
        public int ShopCartId { get; init; }
    }
}
