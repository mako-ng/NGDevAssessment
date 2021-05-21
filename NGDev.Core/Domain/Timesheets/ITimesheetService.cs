using NGDev.Domain.Timesheets.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NGDev.Domain.Timesheets
{
    public interface ITimesheetService
    {
        Task<IEnumerable<TimeEntryDetail>> GetTimesheetDetails();
        Task AddTimeEntry(AddTimeEntryModel model);
        Task DeleteTimeEntry(DeleteTimeEntryModel model);
        Task<PayrollResultsModel> RunPayroll();
    }
}
