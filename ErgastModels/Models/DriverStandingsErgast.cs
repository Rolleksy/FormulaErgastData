using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErgastModels.Models
{
    public class DriverStandingsErgast
    {
        public int driverStandingsId { get; set; }
        public int raceId { get; set; }
        public int driverId { get; set; }
        public string points { get; set; }
        public int position { get; set; }
        public string positionText { get; set; }
        public int wins { get; set; }
    }
}
