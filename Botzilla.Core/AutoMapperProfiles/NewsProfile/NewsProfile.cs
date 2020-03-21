using AutoMapper;
using Botzilla.Core.CreateRequestModels;
using Botzilla.Core.UpdateRequestModels;
using Botzilla.Core.ViewModels;
using Botzilla.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Botzilla.Core.AutoMapperProfiles.NewsProfile
{
    public class NewsProfile : Profile
    {
        public NewsProfile()
        {
            CreateMap<CreateNewsRequest, News>();
            CreateMap<News, NewsViewModel>();
            CreateMap<UpdateNewsRequest, News>();

        }
    }
}
