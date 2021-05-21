using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NGDev.Domain.Timesheets;
using NGDev.Persistence;

namespace NGDev
{
    public static class Startup
    {
        public static void AddNgAppLayer(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<NGDevContext>();
            services.AddScoped<ITimesheetService, TimesheetService>();
        }
    }
}
