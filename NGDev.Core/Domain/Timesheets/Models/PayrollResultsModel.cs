using System;
using System.Collections.Generic;
using System.Text;

namespace NGDev.Domain.Timesheets.Models
{
    public class PayrollResultsModel
    {
        public decimal RegularHours { get; set; }
        public decimal OvertimeHours { get; set; }
    }
}
