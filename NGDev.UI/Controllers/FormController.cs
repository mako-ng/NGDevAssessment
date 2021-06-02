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
            try
            {
                var result = await _timesheetService.RunPayroll();
                return Ok(result);
            }
            catch(Exception Ex)
            {  
                return BadRequest(Ex);
            }
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(DateTime Date, decimal HoursWorked)
        {
            try 
            {
                var model = new AddTimeEntryModel
                {
                    Date = Date,
                    HoursWorked = HoursWorked
                };
                var result = _timesheetService.AddTimeEntry(model);
                await result;
            }
            catch(Exception Ex)
            {
                return BadRequest(Ex);
            }
            return Ok(1);
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> Update(EntryListModel request)
        {
            Console.WriteLine("Params: ");
            string json = JsonConvert.SerializeObject(request, Formatting.Indented);
            Console.WriteLine(json);
            try 
            {
                foreach(var Entry in request.Entries)
                {
                    Console.WriteLine("Update");
                    Console.WriteLine(Entry);
                    var model = new AddTimeEntryModel
                    {
                        Date = Entry.Date,
                        HoursWorked = Entry.HoursWorked
                    };
                    var result = _timesheetService.AddTimeEntry(model);
                    await result;
                }
                return Ok(1);
            }
            catch(Exception Ex)
            {
                return BadRequest(Ex);
            }
        }

        [HttpPost]
        [Route("delete")]
        public async Task<IActionResult> Delete([FromBody] int Id)
        {
            try
            {
                Console.WriteLine(Id);
                var model = new DeleteTimeEntryModel
                {
                    Id = Id
                };
                var result =  _timesheetService.DeleteTimeEntry(model);
                await result;
                return Ok(result);
            }
            catch(Exception Ex)
            {
                return BadRequest(Ex);
            }
        }
    }
}