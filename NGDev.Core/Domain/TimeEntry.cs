using System;
using System.Collections.Generic;
using System.Text;

namespace NGDev.Domain
{
    public class TimeEntry
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal HoursWorked { get; set; }
    }
}
