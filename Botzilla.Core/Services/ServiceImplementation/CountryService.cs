using Botzilla.Core.Repository;
using Botzilla.Domain.Domain;
using Botzilla.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Botzilla.Core.Services
{
    public class CountryService : ICountryService
    {
        private readonly ApplicationDbContext _context;

        public CountryService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }


    }

    
}
