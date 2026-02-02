using AutoMapper;
using FinalYearProject.EfCore.Models;
using FinalYearProject.Shared.Interfaces;
using FinalYearProject.Shared.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FinalYearProject.Server.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class PieceController(
        IRepository<PieceModel, Guid> repository,
        IMapper mapper)
        : ControllerBase
    {
        public IRepository<PieceModel, Guid> Repository { get; } = repository;
        public IMapper Mapper { get; } = mapper;

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<PieceDto>> GetPieceAsync(Guid id)
        {

            // TODO: Need to rework the way that the Piece DTO works.

            // At the moment, the logic is in the format needed to check
            // accuracy and not in the format needed for UI Rendering.
            // There needs to be a conversion from the Piece model to a Piece DTO
            var piece = await Repository.GetAsync(id);

            if (piece is null)
            {
                return NotFound();
            }

            // TODO: Use AutoMapper
            var response = Mapper.Map<PieceDto>(piece);

            return response;
        }
    }
}
