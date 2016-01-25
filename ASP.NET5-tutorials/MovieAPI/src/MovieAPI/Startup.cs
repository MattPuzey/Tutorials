using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MovieAPI.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Security.Claims;

namespace MovieAPI
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        //public IConfigurationRoot Configuration { get; set; }
        public static IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            //Add ASP.NET Entity
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<MoviesAppContext>();

            services.AddTransient<MovieAppContextSeedData>();

            // add ASP.NET Identity
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<MoviesAppContext>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, MovieAppContextSeedData seeder, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            //Use MVC 6 instead of default file routing
            //app.UseDefaultFiles();  
            app.UseStaticFiles();
           
            app.UseIISPlatformHandler();
            app.UseIdentity();
            app.UseMvc();

            //CreateSampleData(app.ApplicationServices).Wait();
            app.UseMvcWithDefaultRoute();
            await seeder.EnsureSeedDataAsync();
            
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);


        //private static async Task CreateSampleData(IServiceProvider applicationServices)
        //{
        //    using (var dbContext = applicationServices.GetService<MoviesAppContext>())
        //    {
        //        var sqlServerDatabase = dbContext.Database; //as SqlServerDatabase;
        //        if (sqlServerDatabase != null)
        //        {
        //            // Create database in user root (c:\users\your name)
        //            if (await sqlServerDatabase.EnsureCreatedAsync())
        //            {
        //                // add some movies
        //                var movies = new List<Movie>
        //                { 
        //                    new Movie {Title= "Star Wars: Force Awakens", Director= "JJ Abrams" },
        //                    new Movie {Title= "The Revenant", Director= "Alejandro Iñárritu" },
        //                    new Movie {Title= "The Hateful Eight", Director= "Quentin Tarantino"}
        //                 };
        //                movies.ForEach(m => dbContext.Movies.Add(m));

        //                // add some users
        //                var userManager = applicationServices.GetService<UserManager<ApplicationUser>>();

        //                // add editor user
        //                var stephen = new ApplicationUser 
        //                {
        //                    UserName = "Stephen"
        //                };
        //                var result = await userManager.CreateAsync(stephen, "P@ssw0rd");
        //                await userManager.AddClaimAsync(stephen, new Claim("CanEdit", "true"));

        //                // add normal user
        //                var bob = new ApplicationUser
        //                {
        //                    UserName = "Bob"
        //                };
        //                await userManager.CreateAsync(bob, "P@ssw0rd");
        //            }
        //        }
        //    }
        //}
    }
}
