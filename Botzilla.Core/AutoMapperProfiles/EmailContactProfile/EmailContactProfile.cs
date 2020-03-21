using AutoMapper;
using Botzilla.Core.CreateRequestModels;
using Botzilla.Core.ViewModels;
using Botzilla.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Botzilla.Core.AutoMapperProfiles.EmailContactProfile
{
    public class EmailContactProfile : Profile
    {
        public EmailContactProfile()
        {
            CreateMap<EmailContact, EmailContactViewModel>();
            CreateMap<CreateEmailContactRequest, EmailContact>();
            CreateMap<EmailSubject, EmailSubjectViewModel>();
        }
    }
}
