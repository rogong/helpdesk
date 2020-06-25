using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CallogApp.Data;
using CallogApp.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CallogApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();

            var host = CreateHostBuilder(args).Build();


            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<ApplicationDbContext>();
                //var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                //var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                try
                {



                    context.Database.Migrate();
                    //Seed.SeedData(context, userManager, roleManager).Wait();
                    //Seed.SeedData(context).Wait();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occured during migration");
                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateHostBuilder(string[] args) =>
            //Host.CreateDefaultBuilder(args)
            //    .ConfigureWebHostDefaults(webBuilder =>
            //    {
            //        webBuilder.UseStartup<Startup>();
            //    });
            WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();

    }
}
