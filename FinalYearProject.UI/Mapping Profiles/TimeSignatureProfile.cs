using AutoMapper;
using FinalYearProject.Shared.Models.Dtos;
using FinalYearProject.Shared.Models.TabRepresentation;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalYearProject.UI.Mapping_Profiles
{
    public class TimeSignatureProfile : Profile
    {
        public TimeSignatureProfile()
        {
            _ = CreateMap<TimeSignatureDto, TimeSignature>();
        }
    }
}
