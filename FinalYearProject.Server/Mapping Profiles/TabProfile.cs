using AutoMapper;
using FinalYearProject.EfCore.Models;
using FinalYearProject.Shared.Models.Dtos;

namespace FinalYearProject.Server.Mapping_Profiles
{
    public class TabProfile : Profile
    {
        public TabProfile()
        {
            _ = CreateMap<TabInformationModel, TabInformationDto>();
        }
    }
}
