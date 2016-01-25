using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MovieAPI.Models
{

    public class ApplicationUser : IdentityUser {}

    public class MoviesAppContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Movie> Movies { get; set; }


        //Self describing context configuration to use SQL server for the exposed entities
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connString = Startup.Configuration["Data:MoviesAppContextConnection"];
            optionsBuilder.UseSqlServer(connString);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
