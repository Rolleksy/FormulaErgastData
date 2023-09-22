using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaErgastAPI.Models
{
    public class StatusErgast
    {
        [Key]
        public int statusId { get; set; }
        public string status { get; set; }
    }
}
