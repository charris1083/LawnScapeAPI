using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnCare.Models
{
    public class MowerCreate
    {
        public string MowerName { get; set; }
        public string MowerCity { get; set; }
        public string MowerService { get; set; }
        public decimal MowerRate { get; set; }
    }
}
