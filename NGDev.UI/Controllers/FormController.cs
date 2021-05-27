using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NGDev.Domain.Timesheets;
using NGDev.Domain.Timesheets.Models;
using NGDev.UI.Models;

namespace NGDev.UI.Controllers
{
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

        [HttpGet]
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

        [HttpGet]
        [Route("delete")]
        public async Task<IActionResult> Delete(int Id)
        {
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