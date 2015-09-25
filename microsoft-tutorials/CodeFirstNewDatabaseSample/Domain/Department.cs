using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Department
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        ICollection<Employee> Employees { get; set; }
        ICollection<TimeCode> TimeCodes { get; set; }
    }

}
