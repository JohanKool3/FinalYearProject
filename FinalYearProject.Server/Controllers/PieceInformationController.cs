using AutoMapper;
using FinalYearProject.EfCore.Models;
using FinalYearProject.Shared.Interfaces;
using FinalYearProject.Shared.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FinalYearProject.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PieceInformationController(
        IRepository<PieceModel, Guid> repository,
        IMapper mapper)
        : ControllerBase
    {
        public IRepository<PieceModel, Guid> Repository { get; } = repository;
        public IMapper Mapper { get; } = mapper;

        /// <summary>
        /// Get all Pieces
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PieceInformationDto>>> GetAllPiecesAsync()
        {
            var pieces = await Repository.GetAllAsync();

            var pieceDtos = Mapper.Map<IEnumerable<PieceInformationDto>>(pieces);

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

            var pieceDto = Mapper.Map<PieceInformationDto>(piece);

            return Ok(pieceDto);
        }
    }
}
