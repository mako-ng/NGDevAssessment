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
        [Route("runpayroll")]
        public async Task<IActionResult> RunPayroll()
        {
            // var model = new PayrollResultsModel
            // {
            //     RegularHours = 1,
            //     OvertimeHours = 0
            // };
            await _timesheetService.RunPayroll();
            return Ok(1);
        }
    }
}