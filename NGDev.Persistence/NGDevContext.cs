using NGDev.Domain.Timesheets.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;

namespace NGDev.Persistence
{
    public class NGDevContext : IDisposable
    {
        private readonly string _mockDbFile = null;
        private readonly List<TimeEntry> _timeEntries = null;

        public NGDevContext()
        {
            string currentPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            _mockDbFile = Path.Combine(currentPath, "mockdb.json");
            var fileContents = System.IO.File.ReadAllText(_mockDbFile);
            _timeEntries = JsonSerializer.Deserialize<List<TimeEntry>>(fileContents) ?? new List<TimeEntry>();
        }

        public IList<TimeEntry> TimeEntries => _timeEntries;

        public void Dispose()
        {
            try
            {
                File.WriteAllText(_mockDbFile, JsonSerializer.Serialize(_timeEntries));
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error updating mockdb (do you have the file open?): {ex.Message}");
            }
        }
    }
}
