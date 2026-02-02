using AutoMapper;
using FinalYearProject.EfCore.Models;
using FinalYearProject.Shared.Models.Dtos;

namespace FinalYearProject.Server.Mapping_Profiles
{
    public class NoteProfile : Profile
    {
        public NoteProfile()
        {
            _ = CreateMap<NoteModel, NoteDto>();
        }
    }
}
