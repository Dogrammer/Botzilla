using Botzilla.Domain.Domain;
using Botzilla.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Botzilla.Api.SeedData.ConstantSeed
{
    public class EmailSubjectSeed
    {
        public static void SeedTestDataViaDbContext(ApplicationDbContext myDbContext)
        {
            if (!myDbContext.EmailSubjects.Any(lt => lt.Name == "Subject 1"))
            {
                myDbContext.EmailSubjects.Add(new EmailSubject
                {
                    Name = "Subject 1",
                    IsDeleted = false,
                    DateCreated = DateTimeOffset.UtcNow,
                });

                myDbContext.SaveChanges();
            }
            if (!myDbContext.EmailSubjects.Any(lt => lt.Name == "Subject 2"))
            {
                myDbContext.EmailSubjects.Add(new EmailSubject
                {
                    Name = "Subject 2",
                    IsDeleted = false,
                    DateCreated = DateTimeOffset.UtcNow,
                });

                myDbContext.SaveChanges();
            }
        }
    }
}
