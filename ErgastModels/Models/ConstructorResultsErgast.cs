using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErgastModels.Models
{
    public class ConstructorResultsErgast
    {
        public int constructorResultsId { get; set; }
        public int raceId { get; set; }
        public int constructorId { get; set; }
        public string points { get; set; }
        public string status { get; set; }
    }
}
