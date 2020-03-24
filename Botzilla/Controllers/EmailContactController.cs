using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Botzilla.Core.CreateRequestModels;
using Botzilla.Core.Services;
using Botzilla.Core.Services.ServiceContract;
using Botzilla.Core.ViewModels;
using Botzilla.Domain.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Botzilla.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailContactController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEmailContactService _emailContactService;
        private readonly IEmailSubjectService _emailSubjectService;

        public EmailContactController(
           IMapper mapper,
           IEmailContactService emailContactService,
           IEmailSubjectService emailSubjectService
        )
        {
            _mapper = mapper;
            _emailContactService = emailContactService;
            _emailSubjectService = emailSubjectService;
        }


        [HttpPost]
        [Route("contactSendEmail")]
        public async Task<ActionResult> SendContactForm(CreateEmailContactRequest request)
        {
            var subject = await _emailSubjectService
                .Queryable()
                .Where(x => x.Id == request.EmailSubjectId && !x.IsDeleted)
                .AsNoTracking()
                .SingleOrDefaultAsync();

            var domain = _mapper.Map<EmailContact>(request);
            domain.EmailSubjectId = request.EmailSubjectId;
            _emailContactService.Insert(domain);

            await _emailContactService.Save();

            //MailMessage mail = new MailMessage();
            //mail.To.Add(request.EmailAddress);
            //mail.Subject = subject.Name;
            //mail.Body = request.Body;
            //mail.From = new MailAddress("marjanovicnevio@gmail.com");
            //mail.IsBodyHtml = false;
            //SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            //smtp.Port = 587;
            //smtp.UseDefaultCredentials = true;
            //smtp.EnableSsl = true;
            //smtp.Credentials = new System.Net.NetworkCredential("marjanovicnevio@gmail.com", "dravengibsonusa123456789");
            //smtp.Send(mail);

            return Ok(domain);
        }

        [HttpPost]
        [Route("replyEmailContact")]
        public async Task<ActionResult> ReplyEmailContact(ReplyEmailContactRequest request)
        {
            var emailToReply = await _emailContactService
                .Queryable()
                .Include(a => a.EmailSubject)
                .Where(x => x.Id == request.EmailContactId && !x.IsDeleted)
                .SingleOrDefaultAsync();

            MailMessage mail = new MailMessage();
            mail.To.Add(emailToReply.EmailAddress);
            mail.Subject = emailToReply.EmailSubject.Name;
            mail.Body = request.Body;
            mail.From = new MailAddress("marjanovicnevio@gmail.com");
            mail.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.UseDefaultCredentials = true;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("marjanovicnevio@gmail.com", "dravengibsonusa123456789");
            smtp.Send(mail);

            emailToReply.IsReplied = true;
            
            await _emailContactService.Save();

            return Ok(emailToReply);
        }

        //[HttpPost]
        //[Route("contactSendEmail")]
        //public async Task<ActionResult> SendContactForm(CreateEmailContactRequest request)
        //{
        //    var subject = await _emailSubjectService
        //        .Queryable()
        //        .Where(x => x.Id == request.EmailSubjectId && !x.IsDeleted)
        //        .AsNoTracking()
        //        .SingleOrDefaultAsync();

        //    var domain = _mapper.Map<EmailContact>(request);
        //    domain.EmailSubjectId = request.EmailSubjectId;
        //    _emailContactService.Insert(domain);

        //    await _emailContactService.Save();

        //    MailMessage mail = new MailMessage();
        //    mail.To.Add(request.To);
        //    mail.Subject = subject.Name;
        //    mail.Body = request.Body;
        //    mail.From = new MailAddress("marjanovicnevio@gmail.com");
        //    mail.IsBodyHtml = false;
        //    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
        //    smtp.Port = 587;
        //    smtp.UseDefaultCredentials = true;
        //    smtp.EnableSsl = true;
        //    smtp.Credentials = new System.Net.NetworkCredential("marjanovicnevio@gmail.com", "dravengibsonusa123456789");
        //    smtp.Send(mail);

        //    return Ok(domain);
        //}

        [HttpGet]
        [Route("getEmails")]
        public async Task<IActionResult> GetEmailsAsync()
        {
            var emails = await _emailContactService
                .Queryable()
                .AsNoTracking()
                .Where(c => !c.IsDeleted)
                .ProjectTo<EmailContactViewModel>(configuration: _mapper.ConfigurationProvider)
                .ToListAsync();

            return Ok(emails.OrderByDescending(a => a.Id));
        }

        [HttpGet]
        [Route("getEmailSubjects")]
        public async Task<IActionResult> GetEmailSubjectsAsync()
        {
            var emailSubjects = await _emailSubjectService
                .Queryable()
                .AsNoTracking()
                .Where(c => !c.IsDeleted)
                .ProjectTo<EmailSubjectViewModel>(configuration: _mapper.ConfigurationProvider)
                .ToListAsync();

            return Ok(emailSubjects);
        }

        [HttpDelete("{id}", Name = nameof(DeleteEmailAsync))]
        [Produces(typeof(EmailContactViewModel))]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteEmailAsync(long id)
        {
            if (id <= 0)
            {
                // notify the caller that he has made a bad request
                return BadRequest("Provided Id is not valid");
            }

            // see if we can find that entity in the data store
            var existing = await _emailContactService
                .Queryable()
                .AsNoTracking()
                .Where(py => !py.IsDeleted && py.Id == id)
                .SingleOrDefaultAsync();

            if (existing != null)
            {
                try
                {
                    _emailContactService.Delete(existing);

                    await _emailContactService.Save();

                }
                catch (Exception ex)
                {
                    // an exception has hapenned, notify caller
                    return BadRequest("Exception: " + ex.Message);
                }
            }
            else
            {
                // existing item was not found, notify caller
                return NotFound("Existing item not found");
            }

            //return Ok("Item: " + existing.Name + " is deleted");
            return NoContent();
        }
    }
}