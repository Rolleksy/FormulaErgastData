using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaErgastAPI.Models
{
    public class RacesErgast
    {
        [Key]
        public int raceId { get; set; }
        public int year { get; set; }
        public int round { get; set; }
        public int circuitId { get; set; }
        public string name { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public string url { get; set; }
        public string fp1_date { get; set; }
        public string fp1_time { get; set; }
        public string fp2_date { get; set; }
        public string fp2_time { get; set; }
        public string fp3_date { get; set; }
        public string fp3_time { get; set; }
        public string quali_date { get; set; }
        public string quali_time { get; set; }
        public string sprint_date { get; set; }
        public string sprint_time { get; set; }
    }
}
