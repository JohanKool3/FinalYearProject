using FinalYearProject.Shared.Models.Dtos;

namespace FinalYearProject.Server.Interfaces
{
    public interface IAudioFileProcessorService
    {
        /// <summary>
        /// Takes an audio file stream and processes it for analysis.
        /// </summary>
        /// <returns></returns>
        Task<AccuracyResultsDto> ProcessAudioFileAsync(AnalysisRequestDto requestDto);
    }
}
