using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Rapidlaunch.Data;
using System;

namespace Rapidlaunch
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();// calling the variable with the propperties of the build function 

            using (var scope = host.Services.CreateScope()) // create scope as a variable
            {
                var services = scope.ServiceProvider; // renaming scope so we dont then have to add it to the host and injecting the dependancy on the database
                try
                {

                    var context = services.GetRequiredService<ApplicationDbContext>();
                    DbInitializer.Initialize(context);
                }
                catch(Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex,"An error occured while seeding the database");

                }
            }

            host.Run();
            }


        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

        


    }
}
