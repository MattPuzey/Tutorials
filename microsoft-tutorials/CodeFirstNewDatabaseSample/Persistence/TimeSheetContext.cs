using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;


namespace Persistence
{
    public class TimeSheetsContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<TimeCode> TimeCodes { get; set; }
        public DbSet<TimeSheet> Timesheets { get; set; }
    }
}
