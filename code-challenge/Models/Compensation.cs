using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace challenge.Models
{
    public class Compensation
    {
        [Newtonsoft.Json.JsonIgnore]
        public int id { get; set; }
        public String EmployeeId { get; set; }
        public Double Salary { get; set; }
        public DateTime EffectiveDate { get; set; }
    }
}
