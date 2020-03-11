using Botzilla.Core.CreateRequestModels;
using Botzilla.Core.Repository.RepositoryImplementation;
using Botzilla.Domain.Domain;
using Botzilla.Domain.DomainBaseClasses;
using Botzilla.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Botzilla.Core.Services.ServiceContract
{
    public interface INewsService : IService<News>
    {
        Task AddImageForNews(CreateNewsRequest request);
    }
}
