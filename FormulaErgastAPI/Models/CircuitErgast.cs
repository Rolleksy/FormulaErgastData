﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaErgastAPI.Models
{
    public class CircuitErgast
    {
        [Key]
        public int circuitId { get; set; }
        public string circuitRef { get; set; }
        public string name { get; set; }
        public string location { get; set; }
        public string country { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }
        public string alt { get; set; }
        public string url { get; set; }
    }
}
