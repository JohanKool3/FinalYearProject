using FinalYearProject.Server.Interfaces;
using FinalYearProject.Server.Models;
using FinalYearProject.Shared.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FinalYearProject.Server.Controllers
{
    [ApiController]
    [Route("api/analysis/[controller]")]
    public class AudioAnalysisController(
        IAudioDataValidator audioDatavalidator,
        FileSettings fileSettings) : ControllerBase
    {
        public IAudioDataValidator Validator { get; } = audioDatavalidator;
        public FileSettings FileSettings { get; } = fileSettings;

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
            // TODO: Validate User Authentication & Authorization

            if (!Validator.ValidAudioData(audioData))
            {
                return BadRequest("Invalid audio data.");
            }

            // TODO: Validate Piece ID

            //TODO: Process Audio File
            // 1. Create a Temporary Folder for this request
            // 2. Save Audio File to Temporary Folder
            // 3. Run Audio Analysis on the audio file
            // 4. Save results to Database
            // 5. Delete Temporary Folder and its contents
            // 6. Return Analysis Results


            // Placeholder for audio analysis logic
            var response = new AccuracyResultsDto
            {
                NoteAccuracy = 1f // Placeholder value
            };

            return Ok(response);
        }
    }
}
