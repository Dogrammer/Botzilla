using Botzilla.Core.CreateRequestModels;
using Botzilla.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Botzilla.Core.Services.ServiceContract
{
    public interface IDocumentService : IService<NewsImage>
    {
        //Task AddImageForNews(CreateNewsRequest request);

    }
}
