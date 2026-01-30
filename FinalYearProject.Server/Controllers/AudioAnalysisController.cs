using FinalYearProject.Shared.Models.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FinalYearProject.Server.Controllers
{
    [ApiController]
    [Route("api/analysis/[controller]")]
    public class AudioAnalysisController : ControllerBase
    {
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
            // TODO: Validate audioData
            // TODO: Save as Wav File on Server
            // TODO: Process Audio File (Through AudioAnalysisPipelineService)
            // TODO: Generate AccuracyResultsDto based on analysis
            // TODO: Save results to Database
            // TODO: Delete Temporary Audio File


            // Placeholder for audio analysis logic
            var response = new AccuracyResultsDto
            {
                NoteAccuracy = 1f // Placeholder value
            };

            // TODO: Utilize the AudioAnalysisPipelineService to process the audioData
            return Ok(response);
        }
    }
}
