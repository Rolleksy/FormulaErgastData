using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaErgastAPI.Models
{
    public class DriverStandingsErgast
    {
        [Key]
        public int driverStandingsId { get; set; }
        public int raceId { get; set; }
        public int driverId { get; set; }
        public string points { get; set; }
        public int position { get; set; }
        public string positionText { get; set; }
        public int wins { get; set; }
    }
}
