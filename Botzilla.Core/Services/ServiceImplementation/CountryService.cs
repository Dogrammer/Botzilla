using Botzilla.Core.Repository;
using Botzilla.Core.Repository.RepositoryImplementation;
using Botzilla.Core.Services.ServiceImplementation;
using Botzilla.Domain.Domain;
using Botzilla.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Botzilla.Core.Services
{
    public class CountryService : Service<Country>, ICountryService
    {
        public CountryService(ITrackableRepository<Country> repository) : base(repository)
        {

        }


    }

    
}
