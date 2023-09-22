using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaErgastAPI.Models
{
    public class PitStopsErgast
    {
        [Key]
        public int raceId { get; set; }
        public int driverId { get; set; }
        public int stop { get; set; }
        public int lap { get; set; }
        public string time { get; set; }
        public string duration { get; set; }
        public int milliseconds { get; set; }
    }
}
