using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaErgastAPI.Models
{
    public class ConstructorStandingsErgast
    {
        [Key]
        public int constructorStandingsId { get; set; }
        public int raceId { get; set; }
        public int constructorId { get; set; }
        public string points { get; set; }
        public int position { get; set; }
        public string positionText { get; set; }
        public int wins { get; set; }
    }
}
