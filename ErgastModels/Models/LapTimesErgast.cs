using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErgastModels.Models
{
    public class LapTimesErgast
    {
        public int raceId { get; set; }
        public int driverId { get; set; }
        public int lap { get; set; }
        public int position { get; set; }
        public string time { get; set; }
        public int milliseconds { get; set; }
    }
}
