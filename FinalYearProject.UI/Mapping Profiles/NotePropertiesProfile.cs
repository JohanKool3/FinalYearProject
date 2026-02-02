using AutoMapper;
using FinalYearProject.Shared.Models.Dtos;
using FinalYearProject.Shared.Models.UI.Bar;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalYearProject.UI.Mapping_Profiles
{
    public class NotePropertiesProfile : Profile
    {
        public NotePropertiesProfile()
        {
            _ = CreateMap<NotePropertiesDto, NoteProperties>();
        }
    }
}
