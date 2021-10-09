using System.ComponentModel.DataAnnotations;

namespace Ordering.Infrastructure.Entities
{
    public class OrderedPlant
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PlantId { get; set; }

        public string ProductName { get; set; }

        public string PictureLink { get; set; }

        public double Price { get; set; }

        public virtual Order Order { get; set; }

        public int OrderId { get; set; }
    }
}
