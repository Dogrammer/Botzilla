using Botzilla.Domain.DomainBaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Botzilla.Core.Repository
{
    public interface IRepository<T> where T: class
    {
            Task<IEnumerable<T>> GetAll();
            Task<T> Get(long id);
            Task<T> Add(T entity);
            Task<T> Update(T entity);
            Task<T> Delete(long id);
            Task Save();
            IQueryable<T> Queryable();


    }
}
