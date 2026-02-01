using FinalYearProject.EfCore.Models;
using FinalYearProject.Shared.Interfaces;
using FinalYearProject.Shared.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FinalYearProject.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PieceInformationController(IRepository<Piece, Guid> repository)
        : ControllerBase
    {
        public IRepository<Piece, Guid> Repository { get; } = repository;

        /// <summary>
        /// Get all Pieces
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PieceInformationDto>>> GetAllPiecesAsync()
        {
            var pieces = await Repository.GetAllAsync();

            var pieceDtos = new List<PieceInformationDto>();

            // TODO: Use AutoMapper
            foreach (var piece in pieces)
            {
                pieceDtos.Add(new PieceInformationDto
                {
                    PieceId = piece.Id,
                    PieceName = piece.PieceName
                });
            }

            return Ok(pieceDtos);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<PieceInformationDto>> GetPieceByIdAsync(Guid id)
        {
            var piece = await Repository.GetAsync(id);
            
            if (piece == null)
            {
                return NotFound();
            }

            var pieceDto = new PieceInformationDto
            {
                PieceId = piece.Id,
                PieceName = piece.PieceName
            };

            return Ok(pieceDto);
        }
    }
}
