using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnCare.Data
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }

        [Required]
        public Guid CustomerId { get; set; }

        [Required]
        public string ClientName { get; set; }

        [Required]
        public string ClientCity { get; set; }

        [Required]
        public string ClientNeeds { get; set; }
    }
}
