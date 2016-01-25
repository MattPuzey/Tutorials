using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MovieAPI.Models
{
    public class MovieAppContextSeedData
    {
        private MoviesAppContext _context;
        private UserManager<ApplicationUser> _userManager;


        public void MoviesAppContextSeedData(MoviesAppContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task EnsureSeedDataAsync()
         {
            //if (await _userManager.FindByNameAsync("Stephen") == null)
            //{
            //    //Add the user.
            //    var stephen = new ApplicationUser
            //    {
            //        UserName = "Stephen"
            //    };
            //    await _userManager.CreateAsync(stephen, "P@ssw0rd!");
            //    await _userManager.AddClaimAsync(stephen, new Claim("CanEdit", "true"));
            //}

            //if (await _userManager.FindByNameAsync("Bob") == null)
            //{
            //    //Add the user.
            //    var bob = new ApplicationUser
            //    {
            //        UserName = "Bob",
            //    };
            //    await _userManager.CreateAsync(bob, "P@ssw0rd!");
            //}

            if (!_context.Movies.Any())
            {
                var movies = new List<Movie>
                {
                    new Movie {Title= "Star Wars: Force Awakens", Director= "JJ Abrams" },
                    new Movie {Title= "The Revenant", Director= "Alejandro Iñárritu" },
                    new Movie {Title= "The Hateful Eight", Director= "Quentin Tarantino"}
                };

                _context.Movies.AddRange(movies);
            }

            _context.SaveChanges();
        }
    }
}
