using FinalYearProject.Server.Exceptions;
using FinalYearProject.Server.Interfaces;
using FinalYearProject.Server.Models;
using FinalYearProject.Shared.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FinalYearProject.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AudioAnalysisController(
    IDataValidator<AnalysisRequest> audioDataValidator,
    IDataValidator<AnalysisRequestMetadata> requestMetadataValidator,

    IAudioFileProcessorService processorService) : ControllerBase
    {
        #region Dependencies

        public IDataValidator<AnalysisRequest> AudioValidator { get; } = audioDataValidator;

        public IDataValidator<AnalysisRequestMetadata> RequestMetadataValidator { get; } = requestMetadataValidator;

        public IAudioFileProcessorService ProcessorService { get; } = processorService;

        #endregion


        /// <summary>
        /// Returns analysis results for the provided audio data.
        /// </summary>
        /// <param name="analysisRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult<AccuracyResultsDto>> AnalyzeAudioAsync
            ([FromForm] AnalysisRequest analysisRequest)
        {
            // TODO: 1. Validate User Authentication & Authorization

            // 2. Validate Audio Data
            if (!(await AudioValidator.ValidDataAsync(analysisRequest)))
            {
                return BadRequest("Invalid audio data.");
            }

            var metadata = GetMetadata(analysisRequest);

            // TODO: 3. Validate Request Metadata
            if (!(await RequestMetadataValidator.ValidDataAsync(metadata)))
            {
                return BadRequest("Invalid request metadata.");

            }

            // 4. Process the audio file
            AccuracyResultsDto? response;
            try
            {
                response = await ProcessorService.ProcessAudioFileAsync(analysisRequest);
            }
            catch (AudioFileProcessingException)
            {
                return StatusCode(500, "Error processing audio file.");
            }

            // Check Accuracy Against Expected


            // 5. Save Data to Database (TO BE IMPLEMENTED LATER)

            // 6. Return the analysis results
            return Ok(response);
        }

        /// <summary>
        /// Returns the metadata for the analysis request.
        /// </summary>
        /// <param name="analysisRequest"></param>
        /// <returns></returns>
        private AnalysisRequestMetadata GetMetadata(AnalysisRequest analysisRequest)
            => new()
            {
                PieceId = analysisRequest.PieceId
            };

    }
}
