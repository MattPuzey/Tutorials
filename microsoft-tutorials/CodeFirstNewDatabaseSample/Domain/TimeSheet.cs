using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class TimeSheet
    {
        public int Id { get; set; }
        public ICollection<TimeSheetEntry> Entries { get; set; }
        public bool IsAuthorised { get; set; }
    }
}
