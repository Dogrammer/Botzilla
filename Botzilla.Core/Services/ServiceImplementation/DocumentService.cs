using Botzilla.Core.CreateRequestModels;
using Botzilla.Core.Repository.RepositoryImplementation;
using Botzilla.Core.Services.ServiceContract;
using Botzilla.Domain.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Botzilla.Core.Services.ServiceImplementation
{
    public class DocumentService : Service<NewsImage>, IDocumentService
    {
        private readonly IFileService _fileService;

        public DocumentService(
            ITrackableRepository<NewsImage> repository
            , IFileService fileService
            ) : base(repository)
        {
            _fileService = fileService;
        }

        //public async Task AddImageForNews(CreateNewsRequest request)
        //{
        //    try
        //    {
        //        var path = await _fileService.SaveToDisk(request.File);

        //        var newImage = new NewsImage
        //        {

        //            NewsId = request.NewsId,
        //            Filename = request.File.FileName,
        //            FileSize = request.File.Length,
        //            Extension = Path.GetExtension(request.File.FileName),
        //            FilePath = path,
        //            ContentType = request.File.ContentType,
        //            Description = request.Description,

        //        };
        //        Repository.Insert(newImage);
        //        await Repository.SaveChangesAsync();
        //    }
        //    catch (Exception ex)
        //    {

        //        //return ex.Message.ToString();
        //    }
        //    //var path = await _fileService.SaveToDisk(request.File);

        //    //var newImage = new NewsImage
        //    //{

        //    //    //ChildId = request.ChildId,
        //    //    Filename = request.File.FileName,
        //    //    FileSize = request.File.Length,
        //    //    Extension = Path.GetExtension(request.File.FileName),
        //    //    FilePath = path,
        //    //    ContentType = request.File.ContentType,
        //    //    Description = request.Description,

        //    //};
        //    //Repository.Attach(newImage);
        //    //await Repository.SaveChangesAsync();
        //}
    }
}
