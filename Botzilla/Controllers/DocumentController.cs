using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Botzilla.Core.CreateRequestModels;
using Botzilla.Core.Services;
using Botzilla.Core.Services.ServiceContract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Botzilla.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {

        private readonly IDocumentService _documentService;
        private readonly IFileService _fileService;

        public DocumentController(
             IMapper mapper
            , IDocumentService documentService
            , IFileService fileService
            )
        {
            _documentService = documentService;
            _fileService = fileService;
        }
        //[HttpPost]
        //[Route("importDocument")]
        //public async Task<IActionResult> ImportDocument([FromForm]CreateNewsRequest request)
        //{
        //    try
        //    {
        //        await _documentService.AddImageForNews(request);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //        return Ok();


        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[HttpDelete("{id}", Name = nameof(DeleteDocumentAsync))]
        //public async Task<IActionResult> DeleteDocumentAsync(long id)
        //{
        //    var document = await _documentService.Queryable().FirstOrDefaultAsync(a => a.Id == id);
        //    if (document != null)
        //    {
        //        _documentService.Delete(document);
        //        await _unitOfWork.SaveChangesAsync();
        //    }
        //    return Ok(FleksbitResponse.CreateResponse(HttpStatusCode.OK));
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="request"></param>
        ///// <returns></returns>
        //[HttpPost]
        //[Route("setDocumentVerified")]
        //public async Task<IActionResult> SetDocumentVerifiedAsync(SetDocumentVerifiedRequest request)
        //{
        //    if (_jwtApplicationType == ApplicationTypeEnum.EvidencijaDjece)
        //    {
        //        if (_jwtUserRight == ApplicationRightEnum.ReadWrite)
        //        {
        //            var document = _mergedDocumentService.Queryable().FirstOrDefault(a => a.Id == request.DocumentId);
        //            if (document != null)
        //            {
        //                document.IsVerified = request.IsVerified;
        //                await _unitOfWork.SaveChangesAsync();
        //            }
        //        }
        //    }
        //    return Ok(FleksbitResponse.CreateResponse(HttpStatusCode.OK));
        //}


        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="requestId"></param>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("getAdditionalDocumentTypes/{requestId}")]
        //public async Task<IActionResult> GetAdditionalDocumentTypes(long requestId)
        //{
        //    var tempRequest = await _tempEnrollmentRequestService.Queryable().FirstOrDefaultAsync(a => a.GroupTempEnrollmentRequest.Id == requestId && a.IsLast);
        //    if (tempRequest != null)
        //    {
        //        RequestTypePerAgeEnum? RequestTypePerAge = null;

        //        if (tempRequest.ProgrammePerAgeId == (int)ProgrammePerAgeEnum.Jaslice || tempRequest.ProgrammePerAgeId == (int)ProgrammePerAgeEnum.Vrtić)
        //        {
        //            RequestTypePerAge = RequestTypePerAgeEnum.Jaslice_Vrtić;
        //        }
        //        else if (tempRequest.ProgrammePerAgeId == (int)ProgrammePerAgeEnum.Predškola)
        //        {
        //            RequestTypePerAge = RequestTypePerAgeEnum.Predškola;
        //        }

        //        var returnValue = new List<DocumentType>();
        //        if (RequestTypePerAge == RequestTypePerAgeEnum.Jaslice_Vrtić)
        //        {
        //            returnValue = await _documentTypeService.Queryable().Where(a => a.RequestTypePerAge.Id == (int)RequestTypePerAgeEnum.Jaslice_Vrtić && a.PedagogicalYearId == tempRequest.PedagogicalYearId).ToListAsync();
        //        }
        //        else if (RequestTypePerAge == RequestTypePerAgeEnum.Predškola)
        //        {
        //            returnValue = await _documentTypeService.Queryable().Where(a => a.RequestTypePerAge.Id == (int)RequestTypePerAgeEnum.Predškola && a.PedagogicalYearId == tempRequest.PedagogicalYearId).ToListAsync();

        //        }
        //        return Ok(FleksbitResponse.CreateResponse(HttpStatusCode.OK, returnValue));
        //    }
        //    return BadRequest(FleksbitResponse.CreateResponse(HttpStatusCode.BadRequest, "Ne postoji zahtjev"));
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="requestId"></param>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("getFlatAdditionalDocumentTypes/{requestId}")]
        //public async Task<IActionResult> GetFlatAdditionalDocumentTypes(long requestId)
        //{
        //    var flatRequest = await _flatEnrollmentRequestService.Queryable().FirstOrDefaultAsync(a => a.Id == requestId);
        //    if (flatRequest != null)
        //    {

        //        RequestTypePerAgeEnum? RequestTypePerAge = null;

        //        if (flatRequest.KindergardenAProgrammerPerAgeId == (int)ProgrammePerAgeEnum.Jaslice || flatRequest.KindergardenAProgrammerPerAgeId == (int)ProgrammePerAgeEnum.Vrtić)
        //        {
        //            RequestTypePerAge = RequestTypePerAgeEnum.Jaslice_Vrtić;
        //        }
        //        else if (flatRequest.KindergardenAProgrammerPerAgeId == (int)ProgrammePerAgeEnum.Predškola)
        //        {
        //            RequestTypePerAge = RequestTypePerAgeEnum.Predškola;
        //        }


        //        var returnValue = new List<DocumentType>();
        //        if (RequestTypePerAge == RequestTypePerAgeEnum.Jaslice_Vrtić)
        //        {
        //            returnValue = _documentTypeService.Queryable().Where(a => a.RequestTypePerAge.Id == (int)RequestTypePerAgeEnum.Jaslice_Vrtić && a.PedagogicalYearId == flatRequest.PedagogicalYearId).ToList();
        //        }
        //        else if (RequestTypePerAge == RequestTypePerAgeEnum.Predškola)
        //        {
        //            returnValue = _documentTypeService.Queryable().Where(a => a.RequestTypePerAge.Id == (int)RequestTypePerAgeEnum.Predškola && a.PedagogicalYearId == flatRequest.PedagogicalYearId).ToList();

        //        }
        //        return Ok(FleksbitResponse.CreateResponse(HttpStatusCode.OK, returnValue));
        //    }
        //    return BadRequest(FleksbitResponse.CreateResponse(HttpStatusCode.BadRequest, "Ne postoji zahtjev"));
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="requestId"></param>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("getBasicDocumentTypes/{requestId}")]
        //public async Task<IActionResult> GetBasicDocumentTypes(long requestId)
        //{
        //    var payloadStep8 = await _enrollmentRequestStepPayloadService
        //        .Queryable()
        //        .AsNoTracking()
        //        .Include(a => a.TempEnrollmentRequest)
        //        .FirstOrDefaultAsync(a => a.TempEnrollmentRequest.IsLast
        //        && a.TempEnrollmentRequest.GroupTempEnrollmentRequest.Id == requestId
        //        && a.EnrollmentRequestStep.StepNumber == 8
        //        );

        //    List<long> acceptedUserAgreements = new List<long>();
        //    if (payloadStep8 != null)
        //    {
        //        var step8Obj = JsonConvert.DeserializeObject<List<RequestStep8>>(payloadStep8.JSON);
        //        acceptedUserAgreements = step8Obj.Where(a => a.isApproved).Select(a => a.id).ToList();
        //    }

        //    var returnValue = await _documentTypeService
        //        .Queryable()
        //        .AsNoTracking()
        //        .Where(a => a.DocumentCategory.Id == (int)DocumentCategoryEnum.Osnovna_dokumentacija && a.PedagogicalYearId == payloadStep8.TempEnrollmentRequest.PedagogicalYearId
        //        )
        //        .ToListAsync();

        //    foreach (var docType in returnValue)
        //    {
        //        docType.isRequired = true;

        //        if (docType.ConsentId != null && acceptedUserAgreements.Contains(docType.ConsentId.Value))
        //        {
        //            docType.isRequired = false;
        //        }
        //    }
        //    return Ok(FleksbitResponse.CreateResponse(returnValue));
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="requestId"></param>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("getFlatBasicDocumentTypes/{requestId}")]
        //public async Task<IActionResult> GetFlatBasicDocumentTypes(long requestId)
        //{
        //    var flatRequest = await _flatEnrollmentRequestService
        //        .Queryable()
        //        .AsNoTracking()
        //        .FirstOrDefaultAsync(a => a.Id == requestId
        //        );

        //    if (flatRequest != null)
        //    {
        //        var returnValue = await _documentTypeService
        //            .Queryable()
        //            .AsNoTracking()
        //            .Where(a => a.DocumentCategory.Id == (int)DocumentCategoryEnum.Osnovna_dokumentacija && a.PedagogicalYearId == flatRequest.PedagogicalYearId)
        //            .ToListAsync();


        //        return Ok(FleksbitResponse.CreateResponse(HttpStatusCode.OK, returnValue));
        //    }
        //    return BadRequest(FleksbitResponse.CreateResponse(HttpStatusCode.BadRequest, "Ne postoji zahtjev"));
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="personId"></param>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("getAdditionalProfileDocumentsForChild/{personId}")]
        //public async Task<IActionResult> GetAdditionalProfileDocumentsForChild(long personId)
        //{
        //    if (_jwtApplicationType == ApplicationTypeEnum.EvidencijaDjece)
        //    {
        //        var person = await _personService.Queryable().Include(a => a.AdditionalProfileDocuments).FirstOrDefaultAsync(a => a.Id == personId);
        //        if (person != null)
        //        {
        //            foreach (var c in person.AdditionalProfileDocuments)
        //            {
        //                c.Child = null;
        //            }
        //            return Ok(FleksbitResponse.CreateResponse(HttpStatusCode.OK, person.AdditionalProfileDocuments.OrderByDescending(a => a.Id).ToList()));
        //        }
        //        return BadRequest(FleksbitResponse.CreateResponse(HttpStatusCode.BadRequest));
        //    }
        //    return Unauthorized(FleksbitResponse.CreateResponse(HttpStatusCode.Unauthorized));
        //}


        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="request"></param>
        ///// <returns></returns>
        //[HttpPost]
        //[Route("importAdditionalProfileDocument")]
        //public async Task<IActionResult> ImportAdditionalProfileDocument([FromForm]ImportAdditionalProfileDocumentsRequest request)
        //{
        //    if (_jwtApplicationType == ApplicationTypeEnum.EvidencijaDjece && _jwtUserRight == ApplicationRightEnum.ReadWrite)
        //    {
        //        await _additionalProfileDocumentService.AddAdditionalProfileDocuments(request);
        //        return Ok(FleksbitResponse.CreateResponse(HttpStatusCode.OK));
        //    }

        //    return Unauthorized(FleksbitResponse.CreateResponse(HttpStatusCode.Unauthorized));

        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="documentId"></param>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("getAdditionalProfileDocument/{documentId}")]
        //public async Task<IActionResult> GetAdditionalProfileDocumentsAsync(long documentId)
        //{
        //    var childAdditionalProfileDocument = _additionalProfileDocumentService.Queryable().FirstOrDefault(a => a.Id == documentId);
        //    if (childAdditionalProfileDocument != null)
        //    {
        //        var base64 = await _fileService.GetFileInBase64(childAdditionalProfileDocument.FilePath);
        //        var returnFileInfo = new AdditionalProfileDocumentViewModel
        //        {
        //            Base64 = base64,
        //            FileName = childAdditionalProfileDocument.Filename,
        //            ContentType = childAdditionalProfileDocument.ContentType,
        //            Extension = childAdditionalProfileDocument.Extension
        //        };

        //        return Ok(FleksbitResponse.CreateResponse(returnFileInfo));
        //    }

        //    return BadRequest(FleksbitResponse.CreateResponse(HttpStatusCode.BadRequest));

        //}
    }
}