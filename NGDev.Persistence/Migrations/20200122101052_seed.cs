using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace NGDev.Persistence.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TimeEntries",
                columns: new[] { "Id", "Date", "HoursWorked" },
                values: new object[] { 1, DateTime.Now.Date.AddDays(-4), 8.0M });

            migrationBuilder.InsertData(
                table: "TimeEntries",
                columns: new[] { "Id", "Date", "HoursWorked" },
                values: new object[] { 2, DateTime.Now.Date.AddDays(-2), 6.5M });

            migrationBuilder.InsertData(
                table: "TimeEntries",
                columns: new[] { "Id", "Date", "HoursWorked" },
                values: new object[] { 3, DateTime.Now.Date.AddDays(-1), 10.0M });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
