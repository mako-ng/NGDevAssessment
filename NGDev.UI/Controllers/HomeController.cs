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
    public class HomeController : Controller
    {
        private readonly ITimesheetService _timesheetService;

        public HomeController(ITimesheetService timesheetService)
        {
            _timesheetService = timesheetService ?? throw new ArgumentNullException(nameof(timesheetService));
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<TimeEntryDetail> timeEntries = await _timesheetService.GetTimesheetDetails();
            var model = new TimesheetViewModel
            {
                TimeEntries = timeEntries
            };
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
