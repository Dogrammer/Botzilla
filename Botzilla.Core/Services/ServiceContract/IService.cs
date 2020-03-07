using Botzilla.Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Botzilla.Core.Services.ServiceContract
{
    public interface IService<TEntity> : IRepository<TEntity> where TEntity : class
    {
    }
}
