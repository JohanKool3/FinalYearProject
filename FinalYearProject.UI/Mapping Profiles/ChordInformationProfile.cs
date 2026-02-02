using AutoMapper;
using FinalYearProject.Shared.Models.Dtos;
using FinalYearProject.Shared.Models.UI.TopBar;

namespace FinalYearProject.UI.Mapping_Profiles
{
    public class ChordInformationProfile : Profile
    {
        public ChordInformationProfile()
        {
            _ = CreateMap<ChordInformationDto, ChordInformation>();
        }
    }
}
