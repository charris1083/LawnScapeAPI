using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnCare.Models
{
    public class ClientCreate
    {
        [Required]
        public string ClientName { get; set; }
        public string ClientCity { get; set; }
        public string ClientNeeds { get; set; }
    }
}
