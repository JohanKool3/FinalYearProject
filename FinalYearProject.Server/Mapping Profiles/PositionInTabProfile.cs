using AutoMapper;
using FinalYearProject.EfCore.Models;
using FinalYearProject.Shared.Models.Dtos;

namespace FinalYearProject.Server.Mapping_Profiles
{
    public class PositionInTabProfile: Profile
    {
        public PositionInTabProfile()
        {
            _ = CreateMap<PositionInTabModel, PositionInTabDto>();
        }
    }
}
