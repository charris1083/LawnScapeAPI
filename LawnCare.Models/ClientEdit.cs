using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnCare.Models
{
    public class ClientEdit
    {
        public int ClientId { get; set; }
        public Guid CustomerId { get; set; }
        public string ClientName { get; set; }
        public string ClientCity { get; set; }
        public string ClientNeeds { get; set; }
    }
}
