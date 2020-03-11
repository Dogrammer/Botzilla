﻿using Botzilla.Domain.DomainInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Botzilla.Core.Repository.RepositoryImplementation
{
    public interface ITrackableRepository<TEntity> : IRepository<TEntity> where TEntity : class, ITrackable
    {
        void ApplyChanges(params TEntity[] entities);
        void AcceptChanges(params TEntity[] entities);
        void DetachEntities(params TEntity[] entities);
        Task LoadRelatedEntities(params TEntity[] entities);
    }
}
