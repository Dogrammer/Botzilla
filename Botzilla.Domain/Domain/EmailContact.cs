using Botzilla.Domain.DomainBaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Botzilla.Domain.Domain
{
    public class EmailContact : BaseEntity
    {
        public string To { get; set; }
        public string Body { get; set; }
        public string EmailAddress { get; set; }
        public EmailSubject EmailSubject { get; set; }
        public long EmailSubjectId { get; set; }
    }
}
