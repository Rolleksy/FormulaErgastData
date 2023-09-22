using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErgastModels.Models
{
    public class PitStopsErgast
    {
        public int raceId { get; set; }
        public int driverId { get; set; }
        public int stop { get; set; }
        public int lap { get; set; }
        public string time { get; set; }
        public string duration { get; set; }
        public int milliseconds { get; set; }
    }
}
