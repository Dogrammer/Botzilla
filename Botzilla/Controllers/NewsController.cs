using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Botzilla.Core.CreateRequestModels;
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
        public NewsController(IArticleService)
        {
            

        }

        [HttpPost]
        [Route("addNews")]
        public async Task<IActionResult> AddNews([FromForm]CreateNewsRequest request)
        {
                await _documentService.Add(request);
                return Ok(FleksbitResponse.CreateResponse(HttpStatusCode.OK));
            //return Unauthorized(FleksbitResponse.CreateResponse(HttpStatusCode.Unauthorized));

        }

        [HttpGet]
        [Route("getNewsImage/{imageId}")]
        public async Task<IActionResult> GetAdditionalProfileDocumentsAsync(long imageId)
        {
            var newsImage = _newsService.Queryable().FirstOrDefault(a => a.Id == documentId);
            if (documentId != null)
            {
                var base64 = await _fileService.GetFileInBase64(childAdditionalProfileDocument.FilePath);
                var returnFileInfo = new AdditionalProfileDocumentViewModel
                {
                    Base64 = base64,
                    FileName = childAdditionalProfileDocument.Filename,
                    ContentType = childAdditionalProfileDocument.ContentType,
                    Extension = childAdditionalProfileDocument.Extension
                };

                return Ok(FleksbitResponse.CreateResponse(returnFileInfo));
            }

            return BadRequest(FleksbitResponse.CreateResponse(HttpStatusCode.BadRequest));

        }






    }
}