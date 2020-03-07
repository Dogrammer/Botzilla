using Botzilla.Core.Services.ServiceContract;
using Botzilla.Domain.DomainInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Botzilla.Core.Services.ServiceImplementation
{
    public abstract class Service<TEntity> : IService<TEntity> where TEntity : class, ITrackable
    {
        public Task<TEntity> Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> Get(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> Queryable()
        {
            throw new NotImplementedException();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
