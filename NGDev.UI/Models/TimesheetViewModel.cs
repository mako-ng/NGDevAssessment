using NGDev.Domain.Timesheets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NGDev.UI.Models
{
    public class TimesheetViewModel
    {
        public IEnumerable<TimeEntryDetail> TimeEntries { get; set; }
    }
}
