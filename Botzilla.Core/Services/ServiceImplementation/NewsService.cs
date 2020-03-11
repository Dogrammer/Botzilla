using Botzilla.Core.CreateRequestModels;
using Botzilla.Core.Repository;
using Botzilla.Core.Repository.RepositoryImplementation;
using Botzilla.Core.Services.ServiceContract;
using Botzilla.Domain.Domain;
using Botzilla.Domain.DomainBaseClasses;
using Botzilla.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Botzilla.Core.Services.ServiceImplementation
{
    public class NewsService : Service<News>, INewsService
    {
        private readonly INewsService _newsService;
        private readonly IFileService _fileService;
        public NewsService(
            INewsService newsService,
            ITrackableRepository<News> repository
            , IFileService fileService
            ) : base(repository)
        {
            _newsService = newsService;
            _fileService = fileService;
        }

        public async Task AddImageForNews(CreateNewsRequest request)
        {

            var path = await _fileService.SaveToDisk(request.File);


            var newNews = new News
            {

                FileName = request.File.FileName,
                FileSize = request.File.Length,
                Extension = Path.GetExtension(request.File.FileName),
                FilePath = path,
                Content = request.File.ContentType

                 

            };
            _newsService.Attach(newNews);
            await _newsService.SaveChangesAsync();
        }
    }
}
