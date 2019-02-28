using LawnCare.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnCare.Models
{
    public class ContractDetail
    {
        public int ContractId { get; set; }
        public Guid OwnerId { get; set; }
        public int ClientId { get; set; }
        public int MowerId { get; set; }
        public string MowerName { get; set; }
        public string ClientName { get; set; }
        public decimal MowerRate { get; set; }
        public string ClientCity { get; set; }
        public string MowerService { get; set; }

        public virtual Client Client { get; set; }
        public virtual Mower Mower { get; set; }
    }
}
