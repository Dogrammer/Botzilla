using System;
using System.Collections.Generic;
using System.Text;

namespace Botzilla.Core.CreateRequestModels
{
    public class CreateEmailContactRequest
    {
        public long Id { get; set; }
        public string EmailAddress { get; set; }
        public string To { get; set; }
        public long EmailSubjectId { get; set; }
        public string Body { get; set; }

    }
}
