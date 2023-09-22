using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaErgastAPI.Models
{
    public class SeasonsErgast
    {
        [Key]
        public int year { get; set; }
        public string url { get; set; }
    }
}
