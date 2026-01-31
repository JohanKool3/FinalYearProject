using FinalYearProject.EfCore.Models;
using FinalYearProject.Server.Exceptions;
using FinalYearProject.Server.Interfaces;
using FinalYearProject.Shared.Interfaces;
using FinalYearProject.Shared.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FinalYearProject.Server.Controllers
{
    [ApiController]
    [Route("api/analysis/[controller]")]
    public class AudioAnalysisController(
    IAudioDataValidator audioDatavalidator,
    IAudioFileProcessorService processorService,
    IRepository<Piece, Guid> pieceRepository) : ControllerBase
    {
        #region Dependencies

        public IAudioDataValidator Validator { get; } = audioDatavalidator;

        public IAudioFileProcessorService ProcessorService { get; } = processorService;
        public IRepository<Piece, Guid> PieceRepository { get; } = pieceRepository;

        #endregion


        /// <summary>
        /// Returns analysis results for the provided audio data.
        /// </summary>
        /// <param name="audioData"></param>
        /// <returns></returns>
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult<AccuracyResultsDto>> AnalyzeAudioAsync
            ([FromForm] AnalysisRequestDto audioData)
        {
            // TODO: 1. Validate User Authentication & Authorization

            // 2. Validate Audio Data
            if (!Validator.ValidAudioData(audioData))
            {
                return BadRequest("Invalid audio data.");
            }

            // TODO: 3. Validate Piece ID

            // 4. Process the audio file
            AccuracyResultsDto? response = null;

            try
            {
                 response = await ProcessorService.ProcessAudioFileAsync(audioData);
            }
            catch (AudioFileProcessingException)
            {
                return StatusCode(500, "Error processing audio file.");
            }

            // 5. Save Data to Database (TO BE IMPLEMENTED LATER)

            // 6. Return the analysis results
            return Ok(response);
        }
    }
}
