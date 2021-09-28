using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Entities
{

    public class Order
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string SerName { get; set; }
        [Required]
        public string Adress { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }

        public int UserId { get; set; }

        public List<OrderedPlant> OrderedPlants { get; set; }
    }

}
