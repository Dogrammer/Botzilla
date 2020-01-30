using AutoMapper;
using Botzilla.Core.CreateRequestModels;
using Botzilla.Core.UpdateRequestModels;
using Botzilla.Core.ViewModels;
using Botzilla.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Botzilla.Core.AutoMapperProfiles.CountryProfile
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<Country, CountryViewModel>();
            CreateMap<CreateCountryRequest, Country>();
            CreateMap<UpdateCountryRequest, Country>();

        }
    }
}
