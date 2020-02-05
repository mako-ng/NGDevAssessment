using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NGDev.Domain.Timesheets;
using NGDev.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace NGDev
{
    public static class Startup
    {
        public static void AddNgAppLayer(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<NGDevContext>(options =>
            {
                options = options.EnableSensitiveDataLogging();
                options = options.UseSqlServer(config.GetConnectionString("NGDevSqlDb"));
            });

            services.AddScoped<ITimesheetService, TimesheetService>();
        }

    }
}
