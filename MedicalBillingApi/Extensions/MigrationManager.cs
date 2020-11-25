using MedicalBillingApi.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NLog.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MedicalBillingApi.Entities.DataInitializer;

namespace MedicalBillingApi.Extensions
{
    public static class MigrationManager
    {
        public static IWebHost MigrateDatabase(this IWebHost webHost)
        {
            using (var scope = webHost.Services.CreateScope())
            {
                var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
                var services = scope.ServiceProvider;

                try
                {
                    var db = services.GetRequiredService<AppDataContext>();
                    db.Database.Migrate();
                    var userManager = services.GetRequiredService<UserManager<AppUser>>();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                    UserAndRoleDataInitializer.SeedData(userManager, roleManager, db);
                    logger.Debug("Migration applied sucessfully");
                }
                catch (Exception ex)
                {
                    logger.Error(ex, "An error occurred while migrating the database.");
                }
                finally
                {
                   
                }
            }

            return webHost;
        }
    }
    
}
