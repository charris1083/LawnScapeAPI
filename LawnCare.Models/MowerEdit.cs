using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnCare.Models
{
    public class MowerEdit
    {
        public int MowerId { get; set; }
        public Guid LandscapeId { get; set; }
        public string MowerName { get; set; }
        public string MowerCity { get; set; }
        public string MowerService { get; set; }
        public decimal MowerRate { get; set; }
    }
}
