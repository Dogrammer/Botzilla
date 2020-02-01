using Botzilla.Domain.Domain;
using Botzilla.Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Botzilla.Api.SeedData.ConstantSeed
{
    public class RoleSeed
    {
        public static void SeedTestDataViaDbContext(RoleManager<Role> roleManager)
        {
            if (!roleManager.RoleExistsAsync("PremiumUser").Result)
            {
                var role = new Role();
                role.Name = "PremiumUser";
                role.Description = "Can use tutorial, but have no privilege to manage the application data";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                var role = new Role();
                role.Name = "Admin";
                role.Description = "Super admin privileges";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }

        }
    }
}
