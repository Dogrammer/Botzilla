using Botzilla.Domain.Domain;
using Botzilla.Domain.DomainBaseClasses;
using Botzilla.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Botzilla.Api.SeedData.TemporarySeed
{
    public class CountrySeed
    {
        public static void SeedTestDataViaDbContext(ApplicationDbContext myDbContext)
        {
            if (!myDbContext.Countries.Any(lt => lt.Name == "Croatia"))
            {
                myDbContext.Countries.Add(new Country
                {
                    Name = "Croatia",
                    IsPrimary = true,
                    ActiveFrom = DateTimeOffset.Now,
                    ActiveTo = DateTimeOffset.Now.AddYears(20),
                    IsActive = true,
                    IsDeleted = false,
                    DateCreated = DateTimeOffset.UtcNow,
                });

                myDbContext.SaveChanges();
            }
            if (!myDbContext.Countries.Any(lt => lt.Name == "Serbia"))
            {
                myDbContext.Countries.Add(new Country
                {
                    Name = "Serbia",
                    IsPrimary = false,
                    ActiveFrom = DateTimeOffset.Now,
                    ActiveTo = DateTimeOffset.Now.AddYears(20),
                    IsActive = true,
                    IsDeleted = false,
                    DateCreated = DateTimeOffset.UtcNow,
                });

                myDbContext.SaveChanges();
            }
        }
    }
}
