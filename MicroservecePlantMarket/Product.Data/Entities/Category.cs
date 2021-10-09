using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Product.DAL.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public List<Plant> Plants { get; set; }
    }
}
