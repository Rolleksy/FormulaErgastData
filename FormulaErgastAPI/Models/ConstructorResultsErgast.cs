using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaErgastAPI.Models
{
    public class ConstructorResultsErgast
    {
        [Key]
        public int constructorResultsId { get; set; }
        public int raceId { get; set; }
        public int constructorId { get; set; }
        public string points { get; set; }
        public string status { get; set; }
    }
}
