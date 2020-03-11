using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Botzilla.Core.CreateRequestModels;
using Botzilla.Core.Services;
using Botzilla.Core.Services.ServiceContract;
using Botzilla.Core.ViewModels;
using Botzilla.Domain.Domain;
using Botzilla.Infrastructure.Context;
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
        private readonly IFileService _fileService;

        public NewsController(INewsService newsService, IFileService fileService)
        {
            _newsService = newsService;
            _fileService = fileService;
        }

        [HttpPost]
        [Route("importImageForNews")]
        public async Task<IActionResult> ImportImageNews([FromForm]CreateNewsRequest request)
        {
                await _newsService.AddImageForNews(request);
                return Ok();
        }

        [HttpGet]
        [Route("getAllImagesForNews")]
        public async Task<IActionResult> GetAllImagesForNews()
        {
            //basically get all news with images in array   
            return Ok();
        }



        [HttpGet]
        [Route("getNewsImage/{imageId}")]
        public async Task<IActionResult> GetAdditionalProfileDocumentsAsync(long imageId)
        {
            var newsImage = _newsService.Queryable().FirstOrDefault(a => a.Id == imageId);
            if (imageId != null)
            {
                var base64 = await _fileService.GetFileInBase64(newsImage.FilePath);
                var returnFileInfo = new NewsViewModel
                {
                    Base64 = base64,
                    FileName = newsImage.FileName,
                    Extension = newsImage.Extension
                };

                return Ok(returnFileInfo);
            }

            return BadRequest();

        }
    }
}