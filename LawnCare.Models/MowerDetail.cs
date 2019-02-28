﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnCare.Models
{
    public class MowerDetail
    {
        public int MowerId { get; set; }
        public string MowerName { get; set; }
        public string MowerCity { get; set; }
        public string MowerService { get; set; }
        public decimal MowerRate { get; set; }

        public override string ToString() => $"[MowerId] {MowerName}";
    }
}
