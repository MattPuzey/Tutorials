using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class TimeSheetEntry
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeCode TimeCode { get; set; }
        public int TimeSpent { get; set; }
    }
}
