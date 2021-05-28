using NGDev.Domain.Timesheets.Models;
using NGDev.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
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
            var entryToUpdate = _db.TimeEntries.Where(p=> p.Date == model.Date).FirstOrDefault();

            if (entryToUpdate != null)
            {
                entryToUpdate.HoursWorked = model.HoursWorked;
                return Task.FromResult(entryToUpdate);
            }

            // Get last ID in DB to increment
            var LastId = _db.TimeEntries.OrderByDescending(p => p.Id).FirstOrDefault().Id;
            var TimeEntry = new TimeEntry
                {
                    Id = LastId + 1,
                    Date = model.Date,
                    HoursWorked = model.HoursWorked
                };
            _db.TimeEntries.Add(TimeEntry);
            return Task.FromResult(TimeEntry);
        }
        public Task DeleteTimeEntry(DeleteTimeEntryModel model)
        {
            // throw new NotImplementedException();
            var EntryToDelete = _db.TimeEntries.Where(entry => entry.Id == model.Id).FirstOrDefault();
            if (EntryToDelete != null)
            {
                _db.TimeEntries.Remove(EntryToDelete);
            }
            return Task.FromResult(EntryToDelete);
        }
        public Task<PayrollResultsModel> RunPayroll()
        {
        var Weekly = _db.TimeEntries.GroupBy(i => i.Date.StartOfWeek(DayOfWeek.Sunday));
        Console.WriteLine("All entries");
        string ListJson = JsonConvert.SerializeObject(Weekly, Formatting.Indented);
        Console.WriteLine(ListJson);
        Decimal RegularHours = 0;
        Decimal OverTimeHours = 0;
        foreach(var Week in Weekly)
        {
            Decimal RegularHoursPerWeek = 0;
            Decimal OverTimeHoursPerWeek = 0;
            foreach(var Entry in Week)
            {
                RegularHoursPerWeek += Entry.HoursWorked;
            }
            if (RegularHoursPerWeek >= 40)
            {
                OverTimeHoursPerWeek = RegularHoursPerWeek - 40;
                RegularHoursPerWeek = 40;
            }
            RegularHours += RegularHoursPerWeek;
            OverTimeHours += OverTimeHoursPerWeek;
            string json = JsonConvert.SerializeObject(Week, Formatting.Indented);
            Console.WriteLine("date");
            Console.WriteLine(Week);
            Console.WriteLine(json);
        }
        Console.WriteLine(RegularHours);
        Console.WriteLine(OverTimeHours);
        var PayrollResults = new PayrollResultsModel{};
        return Task.FromResult(PayrollResults);
        }
    }
}
public static class DateTimeExtensions
{
    public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
    {
        int diff = dt.DayOfWeek - startOfWeek;
        if (diff < 0)
        {
            diff += 7;
        }
        return dt.AddDays(-1 * diff).Date;
    }
}