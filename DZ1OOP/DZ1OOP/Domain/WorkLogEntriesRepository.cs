using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ1OOP.Domain
{
    class WorkLogEntriesRepository
    {
        private readonly List<WorkLogEntry> _workLogEntries;

        public WorkLogEntriesRepository()
        {
            _workLogEntries = new List<WorkLogEntry>();
        }

        public WorkLogEntriesRepository(List<WorkLogEntry> workLogEntries)
        {
            _workLogEntries = workLogEntries;
        }

        public List<WorkLogEntry> GetAll()
        {
            return _workLogEntries;
        }

        public void AddWorkLogEntry(WorkLogEntry workLogEntry)
        {
            _workLogEntries.Add(workLogEntry);
        }

        public int Count
        {
            get { return _workLogEntries.Count; }
        }
    }
}
