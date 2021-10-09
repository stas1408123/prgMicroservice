using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Product.DAL.Entities
{
    public class Plant
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public string PictureLink { get; set; }

        public bool IsFavourite { get; set; }

        public bool IsAvailable { get; set; }

        public int? CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
