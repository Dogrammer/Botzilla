using AutoMapper;
using Botzilla.Core.CreateRequestModels;
using Botzilla.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Botzilla.Core.AutoMapperProfiles.LectionProfile
{
    public class LectionProfile : Profile
    {
        public LectionProfile()
        {
            CreateMap<CreateLectionRequest, Lection>();
        }
    }
}
