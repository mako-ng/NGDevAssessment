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
            IEnumerable<TimeEntryDetail> entryList = _db.TimeEntries.Select(t => new TimeEntryDetail
            {
                Id = t.Id,
                Date = t.Date,
                HoursWorked = t.HoursWorked
            }).ToList();

            return await Task.FromResult(entryList);
        }

        public Task AddTimeEntry(AddTimeEntryModel model)
        {
            // throw new NotImplementedException();
            var TimeEntry = new TimeEntry
                {
                    Date = model.Date,
                    HoursWorked = model.HoursWorked
                };

            _db.TimeEntries.Add(TimeEntry);
            // _db.SaveChanges();
            return Task.FromResult(TimeEntry);
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
