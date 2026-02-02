using AutoMapper;
using FinalYearProject.EfCore.Models;
using FinalYearProject.Shared.Models.Dtos;

namespace FinalYearProject.Server.Mapping_Profiles
{
    public class TimeSignatureProfile : Profile
    {
        public TimeSignatureProfile()
        {
            _ = CreateMap<TimeSignatureModel, TimeSignatureDto>();
        }
    }
}
