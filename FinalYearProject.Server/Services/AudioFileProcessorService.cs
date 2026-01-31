using FinalYearProject.Server.Interfaces;
using FinalYearProject.Server.Models;
using FinalYearProject.Shared.Models.Dtos;

namespace FinalYearProject.Server.Services
{
    public class AudioFileProcessorService(FileSettings settings) : IAudioFileProcessorService
    {
        public FileSettings Settings { get; } = settings;

        public async Task<AccuracyResultsDto> ProcessAudioFileAsync(AnalysisRequestDto requestDto)
        {
            // 1. Create a Temporary Folder within base directory

            // 2. Save the uploaded audio file to the Temporary Folder

            // 3. Run the Audio Analysis Pipeline on this file

            // 4. Save results to the database (TO BE IMPLEMENTED LATER)

            // 5. Delete Temporary Folder

            // 6. Return Data

            return new AccuracyResultsDto
            {
                NoteAccuracy = 0.95f // Placeholder value
            };
        }
    }
}
