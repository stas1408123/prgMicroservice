using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.API.Models
{
    public class OrderedPlant
    {

        [Key]
        public int Id { get; set; }

        public int PlantId { get; set; }

        public virtual Order Order { get; set; }

        public int OrderId { get; set; }
    }
}
