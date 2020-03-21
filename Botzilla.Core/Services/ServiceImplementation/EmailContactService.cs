using Botzilla.Core.Repository.RepositoryImplementation;
using Botzilla.Core.Services.ServiceContract;
using Botzilla.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Botzilla.Core.Services.ServiceImplementation
{
    public class EmailContactService : Service<EmailContact>, IEmailContactService
    {
        public EmailContactService(ITrackableRepository<EmailContact> repository) : base(repository)
        {

        }
    }
}
