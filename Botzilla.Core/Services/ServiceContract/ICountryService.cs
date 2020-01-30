using Botzilla.Core.Repository;
using Botzilla.Core.Repository.RepositoryImplementation;
using Botzilla.Domain.Domain;
using Botzilla.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Botzilla.Core.Services
{
    public class ICountryService : Repository<Country>
    {
        private readonly ApplicationDbContext _context;

        public ICountryService(ApplicationDbContext context) : base (context)
        {
            _context = context;
        }


    }
}
