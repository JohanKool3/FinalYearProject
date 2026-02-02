using AutoMapper;
using FinalYearProject.EfCore.Models;
using FinalYearProject.Shared.Models.Dtos;

namespace FinalYearProject.Server.Mapping_Profiles
{
    public class BarInformationProfile : Profile
    {
        public BarInformationProfile()
        {
            _ = CreateMap<BarInformationModel, BarInformationDto>();
        }
    }
}
