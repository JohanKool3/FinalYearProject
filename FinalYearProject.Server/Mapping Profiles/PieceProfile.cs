using AutoMapper;
using FinalYearProject.EfCore.Models;
using FinalYearProject.Shared.Models.Dtos;

namespace FinalYearProject.Server.MappingProfiles;

public class PieceProfile : Profile
{
    public PieceProfile()
    {
        _ = CreateMap<PieceModel, PieceInformationDto>();
        _ = CreateMap<PieceModel, PieceDto>();
    }
}
