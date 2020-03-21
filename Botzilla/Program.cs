using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Botzilla.Domain.Domain;
using Botzilla.Infrastructure.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Botzilla
{
    //public class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        CreateHostBuilder(args).Build().Run();
    //    }

    //    public static IHostBuilder CreateHostBuilder(string[] args) =>
    //        Host.CreateDefaultBuilder(args)
    //            .ConfigureWebHostDefaults(webBuilder =>
    //            {
    //                webBuilder.UseStartup<Startup>();
    //            });
    //}


    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var newScope = host.Services.CreateScope())
            {
                //var userManager = newScope.ServiceProvider.GetRequiredService<UserManager<User>>();
                //var dbContext = newScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                //IdentitySeed.SeedUsers(userManager, dbContext);

                ////ROLE MANAGER DODAT
                //var roleManager = newScope.ServiceProvider.GetRequiredService<RoleManager<Role>>();
                //IdentitySeed.SeedRoles(roleManager);

                var myDbContext = newScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var roleManager = newScope.ServiceProvider.GetRequiredService<RoleManager<Role>>();


                Api.SeedData.TemporarySeed.CountrySeed.SeedTestDataViaDbContext(myDbContext);
                Api.SeedData.ConstantSeed.RoleSeed.SeedTestDataViaDbContext(roleManager);
                Api.SeedData.ConstantSeed.EmailSubjectSeed.SeedTestDataViaDbContext(myDbContext);


                try
                {
                    myDbContext.SaveChanges();
                }
                catch (Exception saveChangesException)
                {

                    throw;
                }
                finally
                {
                    myDbContext.Dispose();
                }

            }

            host.Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });



    }
    //public class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        var host = CreateWebHostBuilder(args).Build();

    //        using (var newScope = host.Services.CreateScope())
    //        {
    //            //var userManager = newScope.ServiceProvider.GetRequiredService<UserManager<User>>();
    //            //var dbContext = newScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    //            //IdentitySeed.SeedUsers(userManager, dbContext);

    //            ////ROLE MANAGER DODAT
    //            //var roleManager = newScope.ServiceProvider.GetRequiredService<RoleManager<Role>>();
    //            //IdentitySeed.SeedRoles(roleManager);

    //            var myDbContext = newScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();


    //            Api.SeedData.TemporarySeed.CountrySeed.SeedTestDataViaDbContext(myDbContext);

    //            try
    //            {
    //                myDbContext.SaveChanges();
    //            }
    //            catch (Exception saveChangesException)
    //            {

    //                throw;
    //            }
    //            finally
    //            {
    //                myDbContext.Dispose();
    //            }

    //        }

    //        host.Run();
    //    }

    //    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
    //        WebHost.CreateDefaultBuilder(args)
    //            .UseStartup<Startup>()
    //            .UseSentry()
    //            .UseNLog();
    //}
}
