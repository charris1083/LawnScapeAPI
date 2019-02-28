using LawnCare.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnCare.Models
{
    public class ClientListItem
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientCity { get; set; }
        public string ClientNeeds { get; set; }

        public virtual Client Client { get; set; }
        public virtual Mower Mower { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
