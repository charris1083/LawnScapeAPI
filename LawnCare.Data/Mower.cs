using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnCare.Data
{
   public class Mower
    {
        [Key]
        public int MowerId { get; set; }
        [Required]
        public Guid LandscapeId { get; set; }
        [Required]
        public string MowerCity { get; set; }
        [Required]
        public string MowerService { get; set; }
        [Required]
        public string MowerName { get; set; }

        public decimal MowerRate { get; set; }
    }
}
