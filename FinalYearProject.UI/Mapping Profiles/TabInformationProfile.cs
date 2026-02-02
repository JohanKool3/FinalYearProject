using AutoMapper;
using FinalYearProject.Shared.Models.Dtos;
using FinalYearProject.Shared.Models.UI;

namespace FinalYearProject.UI.Mapping_Profiles
{
    public class TabInformationProfile : Profile
    {
        public TabInformationProfile()
        {
            _ = CreateMap<TabInformationDto, TabInformation>();
        }
    }
}
