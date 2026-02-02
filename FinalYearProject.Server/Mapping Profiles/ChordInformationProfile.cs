using AutoMapper;
using FinalYearProject.EfCore.Models;
using FinalYearProject.Shared.Models.Dtos;

namespace FinalYearProject.Server.Mapping_Profiles
{
    public class ChordInformationProfile : Profile
    {
        public ChordInformationProfile()
        {
            _ = CreateMap<ChordInformationModel, ChordInformationDto>();
        }
    }
}
