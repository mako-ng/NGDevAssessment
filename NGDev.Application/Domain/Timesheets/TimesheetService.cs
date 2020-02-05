using Microsoft.EntityFrameworkCore;
using NGDev.Domain.Timesheets.Models;
using NGDev.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGDev.Domain.Timesheets
{
    public class TimesheetService : ITimesheetService
    {
        private readonly NGDevContext _db;

        public TimesheetService(NGDevContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<IEnumerable<TimeEntryDetail>> GetTimesheetDetails()
        {
            IEnumerable<TimeEntryDetail> entryList = await _db.TimeEntries.Select(t => new TimeEntryDetail
            {
                Id = t.Id,
                Date = t.Date,
                HoursWorked = t.HoursWorked
            }).ToListAsync();

            return entryList;
        }

        public Task AddTimeEntry(AddTimeEntryModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTimeEntry(DeleteTimeEntryModel model)
        {
            throw new NotImplementedException();
        }

        public Task<PayrollResultsModel> RunPayroll()
        {
            throw new NotImplementedException();
        }
    }
}
