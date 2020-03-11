using Botzilla.Core.Repository;
using Botzilla.Core.Repository.RepositoryImplementation;
using Botzilla.Domain.DomainInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Botzilla.Core.Services.ServiceContract
{
    public interface IService<TEntity> : ITrackableRepository<TEntity> where TEntity : class, ITrackable
    {
        
    }
}
