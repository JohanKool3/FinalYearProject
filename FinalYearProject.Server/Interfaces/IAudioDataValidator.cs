using FinalYearProject.Shared.Models.Dtos;

namespace FinalYearProject.Server.Interfaces
{
    public interface IAudioDataValidator
    {
        /// <summary>
        /// Check the audio data and whether it is valid or not.
        /// </summary>
        /// <param name="audioData"></param>
        /// <returns></returns>
        bool ValidAudioData(AnalysisRequestDto audioData);
    }
}
