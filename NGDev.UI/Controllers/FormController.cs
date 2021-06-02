using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NGDev.Domain.Timesheets;
using NGDev.Domain.Timesheets.Models;
using Newtonsoft.Json;
using NGDev.UI.Models;
using System.IO.Pipelines;

namespace NGDev.UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FormController : ControllerBase
    {
        private readonly ITimesheetService _timesheetService;

        public FormController(ITimesheetService timesheetService)
        {
            _timesheetService = timesheetService ?? throw new ArgumentNullException(nameof(timesheetService));
        }

        [HttpGet]
        [Route("gettimesheetentries")]
        public async Task<IActionResult> GetTimesheetEntries()
        {
            IEnumerable<TimeEntryDetail> timeEntries = await _timesheetService.GetTimesheetDetails();
            var model = new TimesheetViewModel
            {
                TimeEntries = timeEntries
            };
            return Ok(model);
        }

        [HttpGet]
        [Route("runpayroll")]
        public async Task<IActionResult> RunPayroll()
        {
            var result = await _timesheetService.RunPayroll();
            return Ok(result);
            // Add try catch
        }

        [HttpPost]
        // Might need to be post
        [Route("add")]
        public async Task<IActionResult> Add(DateTime Date, decimal HoursWorked)
        {
            var model = new AddTimeEntryModel
            {
                Date = Date,
                HoursWorked = HoursWorked
            };
            await _timesheetService.AddTimeEntry(model);
            return Ok(1);
            // Add try catch
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> Update(EntryListModel request)
        {
            Console.WriteLine("Params: ");
            // Console.WriteLine(request[0]);
            // foreach(var entry in request.Entries) {
            //     string json = JsonConvert.SerializeObject(entry, Formatting.Indented);
            //     Console.WriteLine(json);
            // }
            string json = JsonConvert.SerializeObject(request, Formatting.Indented);
            Console.WriteLine(json);
            
            foreach(var Entry in request.Entries)
            {
                Console.WriteLine("Update");
                Console.WriteLine(Entry);
                var model = new AddTimeEntryModel
                {
                    Date = Entry.Date,
                    HoursWorked = Entry.HoursWorked
                };
                await _timesheetService.AddTimeEntry(model);
            }
            return Ok(1);
            // Add try catch
        }

        [HttpPost]
        [Route("delete")]
        public async Task<IActionResult> Delete([FromBody] int Id)
        {
            Console.WriteLine(Id);
            var model = new DeleteTimeEntryModel
            {
                Id = Id
            };
            await _timesheetService.DeleteTimeEntry(model);
            return Ok(1);
            // Add try catch
        }
    }
}