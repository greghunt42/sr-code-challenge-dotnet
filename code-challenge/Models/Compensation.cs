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

        [ForeignKey("Employee")]
        [Key]
        public String EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public Double Salary { get; set; }
        public DateTime EffectiveDate { get; set; }
    }
}
