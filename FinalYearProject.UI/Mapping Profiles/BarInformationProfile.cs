using AutoMapper;
using FinalYearProject.Shared.Models.Dtos;
using FinalYearProject.Shared.Models.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalYearProject.UI.Mapping_Profiles
{
    public class BarInformationProfile : Profile
    {
        public BarInformationProfile()
        {
            _ = CreateMap<BarInformationDto, BarInformation>();
        }
    }
}
