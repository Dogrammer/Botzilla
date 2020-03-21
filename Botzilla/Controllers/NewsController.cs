using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Botzilla.Core.CreateRequestModels;
using Botzilla.Core.Services;
using Botzilla.Core.Services.ServiceContract;
using Botzilla.Core.ViewModels;
using Botzilla.Domain.Domain;
using Botzilla.Infrastructure.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Botzilla.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase

    {
        private readonly INewsService _newsService;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        private readonly IWebHostEnvironment _environment;

        public NewsController(INewsService newsService,
            IMapper mapper,
            IFileService fileService,
            IWebHostEnvironment environment)
        {
            _newsService = newsService;
            _mapper = mapper;
            _fileService = fileService;
            _environment = environment;
        }

        [HttpGet]
        [Route("getNews")]
        public async Task<IActionResult> GetNewsAsync()
        {
            var news = await _newsService
                .Queryable()
                .AsNoTracking()
                .Where(c => !c.IsDeleted)
                .ProjectTo<NewsViewModel>(configuration: _mapper.ConfigurationProvider)
                .ToListAsync();

            return Ok(news);
        }

        [HttpPost]
        [Route("uploadImage")]
        public IActionResult UploadImage([FromForm]CreateImageRequest request)
        {
            News newsImage = new News()
            {
                Content = request.Content,
                Title = request.Title,
                ImageTitle = request.File.FileName,


            };

            //FileType = request.File.FileName.Substring(request.File.FileName.IndexOf("."), request.File.FileName.Length - 1)

            //var indexOfDot = request.File.FileName.LastIndexOf(".");
            //var lastIndex = request.File.FileName.Length - 1;

            //newsImage.FileType = request.File.FileName.Substring(indexOfDot, lastIndex);

            //newsImage.FileType = request.File.FileName.Substring(request.File.FileName.LastIndexOf("."), request.File.FileName.Length);

            MemoryStream ms = new MemoryStream();
            request.File.CopyTo(ms);
            newsImage.ImageData = ms.ToArray();

            ms.Close();
            ms.Dispose();

            _newsService.Insert(newsImage);
            _newsService.Save();

            return Ok();
        }



        //[HttpPost]
        //[Route("importImageForNews")]
        //public async Task<IActionResult> ImportImageNews([FromForm]CreateNewsRequest request)
        //{
        //        await _newsService.AddImageForNews(request);
        //        return Ok();
        //}

        //[HttpGet]
        //[Route("getAllImagesForNews")]
        //public async Task<IActionResult> GetAllImagesForNews()
        //{
        //    //basically get all news with images in array   
        //    return Ok();
        //}



        //[HttpGet]
        //[Route("getNewsImage/{imageId}")]
        //public async Task<IActionResult> GetNewsImageAsync(long imageId)
        //{
        //    var newsImage = _newsService.Queryable().FirstOrDefault(a => a.Id == imageId);
        //    if (imageId != null)
        //    {
        //        var base64 = await _fileService.GetFileInBase64(newsImage.FilePath);
        //        var returnFileInfo = new NewsViewModel
        //        {
        //            Base64 = base64,
        //            FileName = newsImage.FileName,
        //            Extension = newsImage.Extension
        //        };

        //        return Ok(returnFileInfo);
        //    }

        //    return BadRequest();

        //}
    }
}