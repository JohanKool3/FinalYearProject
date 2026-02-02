using AutoMapper;
using FinalYearProject.EfCore.Models;
using FinalYearProject.Shared.Models.Dtos;

namespace FinalYearProject.Server.Mapping_Profiles
{
    public class NotePropertiesProfile : Profile
    {
        public NotePropertiesProfile()
        {
            _ = CreateMap<NotePropertiesModel, NotePropertiesDto>();
        }
    }
}
