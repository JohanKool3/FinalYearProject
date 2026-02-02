using AutoMapper;
using FinalYearProject.Shared.Models.Dtos;
using FinalYearProject.Shared.Models.TabRepresentation;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalYearProject.UI.Mapping_Profiles
{
    public class BarPositionInTabProfile : Profile
    {
        public BarPositionInTabProfile()
        {
            _ = CreateMap<PositionInTabDto, BarPositionInTab>();
        }
    }
}
