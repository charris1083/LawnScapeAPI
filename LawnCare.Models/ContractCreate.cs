using LawnCare.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnCare.Models
{
    public class ContractCreate
    {
        public int ClientId { get; set; }
        public int MowerId { get; set; }

        public virtual Client Client { get; set; }
        public virtual Mower Mower { get; set; }
    }
    
}
