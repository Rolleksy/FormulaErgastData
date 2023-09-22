using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaErgastAPI.Models
{
    public class DriversErgast
    {
        [Key]
        public int driverId { get; set; }
        public string driverRef { get; set; }
        public string number { get; set; }
        public string code { get; set; }
        public string forename { get; set; }
        public string surname { get; set; }
        public string dob { get; set; }
        public string nationality { get; set; }
        public string url { get; set; }
    }
}
