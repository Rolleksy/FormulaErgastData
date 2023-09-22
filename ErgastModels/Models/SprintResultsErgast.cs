using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErgastModels.Models
{
    public class SprintResultsErgast
    {
        public int resultId { get; set; }
        public int raceId { get; set; }
        public int driverId { get; set; }
        public int constructorId { get; set; }
        public string number { get; set; }
        public int grid { get; set; }
        public string position { get; set; }
        public string positionText { get; set; }
        public string positionOrder { get; set; }
        public string points { get; set; }
        public int laps { get; set; }
        public string time { get; set; }
        public string milliseconds { get; set; }
        public string fastestLap { get; set; }
        public string fastestLapTime { get; set; }
        public int statusId { get; set; }
    }
}
