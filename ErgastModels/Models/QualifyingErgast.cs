using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErgastModels.Models
{
    public class QualifyingErgast
    {
        public int qualifyId { get; set; }
        public int raceId { get; set; }
        public int driverId { get; set; }
        public int constructorId { get; set; }
        public int number { get; set; }
        public int position { get; set; }
        public string q1 { get; set; }
        public string q2 { get; set; }
        public string q3 { get; set; }
    }
}
