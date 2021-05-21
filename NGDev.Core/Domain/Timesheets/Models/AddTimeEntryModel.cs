using System;
using System.Collections.Generic;
using System.Text;

namespace NGDev.Domain.Timesheets.Models
{
    public class AddTimeEntryModel
    {
        public DateTime Date { get; set; }
        public decimal HoursWorked { get; set; }
    }
}
