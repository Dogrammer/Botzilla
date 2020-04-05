using AutoMapper;
using Botzilla.Core.CreateRequestModels;
using Botzilla.Core.ViewModels;
using Botzilla.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Botzilla.Core.AutoMapperProfiles.AuthProfile
{
    public class AuthProfile : Profile
    {
        public AuthProfile()
        {
            CreateMap<CreateUserRegisterRequest, User>();
            CreateMap<CreateUserLoginRequest, User>();
            CreateMap<CreateEducationLevelRequest, EducationLevel>();
            CreateMap<EducationLevel, EducationLevelViewModel>();
        }

    }
}
