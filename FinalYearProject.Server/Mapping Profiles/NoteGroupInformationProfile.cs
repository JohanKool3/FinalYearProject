using AutoMapper;
using FinalYearProject.EfCore.Models;
using FinalYearProject.Shared.Models.Dtos;

namespace FinalYearProject.Server.Mapping_Profiles
{
    public class NoteGroupInformationProfile : Profile
    {
        public NoteGroupInformationProfile()
        {
            _ = CreateMap<NoteGroupInformationModel, NoteGroupInformationDto>();
        }
    }
}
