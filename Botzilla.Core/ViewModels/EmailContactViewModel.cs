using Botzilla.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Botzilla.Core.ViewModels
{
    public class EmailContactViewModel
    {
        public string EmailAddress { get; set; }
        public EmailSubjectViewModel EmailSubject { get; set; }
        public string Body { get; set; }

    }
}
