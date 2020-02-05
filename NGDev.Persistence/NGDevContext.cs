using Microsoft.EntityFrameworkCore;
using NGDev.Domain;
using System;

namespace NGDev.Persistence
{
    public class NGDevContext : DbContext
    {
        public NGDevContext()
        {
        }

        public NGDevContext(DbContextOptions<NGDevContext> options)
            : base(options)
        {
        }

        public DbSet<TimeEntry> TimeEntries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=NGDevDb; Trusted_Connection=True;");
            }
        }
    }
}
