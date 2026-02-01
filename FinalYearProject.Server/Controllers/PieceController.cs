using FinalYearProject.EfCore.Models;
using FinalYearProject.Shared.Interfaces;
using FinalYearProject.Shared.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FinalYearProject.Server.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class PieceController(IRepository<Piece, Guid> repository)
        : ControllerBase
    {
        public IRepository<Piece, Guid> Repository { get; } = repository;

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
            var response = new PieceDto()
            {
                Id = piece.Id,
                PieceName = piece.PieceName,
                ReferenceTab = piece.ReferenceTab
            };

            return response;
        }
    }
}
