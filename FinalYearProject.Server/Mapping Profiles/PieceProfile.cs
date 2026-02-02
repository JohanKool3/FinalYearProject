using AutoMapper;
using FinalYearProject.EfCore.Models;
using FinalYearProject.Shared.Models.Dtos;

namespace FinalYearProject.Server.MappingProfiles;

public class PieceProfile : Profile
{
    public PieceProfile()
    {
        _ = CreateMap<PieceModel, PieceInformationDto>()
            .ForMember(dest => dest.PieceName, 
            opt => opt.MapFrom(src => src.TabInformationModel.Title));


        _ = CreateMap<PieceModel, PieceDto>()
            .ForMember(dest => dest.TabInformation,
            opt => opt.MapFrom(src => src.TabInformationModel));
    }
}
