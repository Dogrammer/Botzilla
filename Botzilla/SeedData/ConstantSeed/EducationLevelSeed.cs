using Botzilla.Domain.Domain;
using Botzilla.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Botzilla.Api.SeedData.ConstantSeed
{
    public class EducationLevelSeed
    {
        public static void SeedTestDataViaDbContext(ApplicationDbContext myDbContext)
        {
            if (!myDbContext.EducationLevels.Any(lt => lt.Name == "Preschool"))
            {
                myDbContext.EducationLevels.Add(new EducationLevel
                {
                    Name = "Preschool",
                    IsDeleted = false,
                    DateCreated = DateTimeOffset.UtcNow,
                });

                myDbContext.SaveChanges();
            }
            if (!myDbContext.EducationLevels.Any(lt => lt.Name == "Elementary school"))
            {
                myDbContext.EducationLevels.Add(new EducationLevel
                {
                    Name = "Elementary school",
                    IsDeleted = false,
                    DateCreated = DateTimeOffset.UtcNow,
                });

                myDbContext.SaveChanges();
            }
            if (!myDbContext.EducationLevels.Any(lt => lt.Name == "High school"))
            {
                myDbContext.EducationLevels.Add(new EducationLevel
                {
                    Name = "High school",
                    IsDeleted = false,
                    DateCreated = DateTimeOffset.UtcNow,
                });

                myDbContext.SaveChanges();
            }
            if (!myDbContext.EducationLevels.Any(lt => lt.Name == "University"))
            {
                myDbContext.EducationLevels.Add(new EducationLevel
                {
                    Name = "University",
                    IsDeleted = false,
                    DateCreated = DateTimeOffset.UtcNow,
                });

                myDbContext.SaveChanges();
            }
        }
    }
}
