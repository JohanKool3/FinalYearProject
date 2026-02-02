using AutoMapper;
using FinalYearProject.Shared.Models.Dtos;
using FinalYearProject.Shared.Models.UI.Bar;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalYearProject.UI.Mapping_Profiles
{
    public class NoteGroupInformationProfile : Profile
    {
        public NoteGroupInformationProfile()
        {
            _ = CreateMap<NoteGroupInformationDto, NoteGroupInformation>();
        }
    }
}
