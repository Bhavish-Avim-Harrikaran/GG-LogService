using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogService
{
    public class LogEntry
    {
        public Guid ID { get; set; }
        public DateTime DateTime { get; set; }
        public string Severity { get; set; }
        public string Message { get; set; }
    }
}
