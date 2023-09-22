using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaErgastAPI.Models
{
    public class ConstructorsErgast
    {
        [Key]
        public int constructorId { get; set; }
        public string constructorRef { get; set; }
        public string name { get; set; }
        public string nationality { get; set; }
        public string url { get; set; }
    }
}
