using FinalYearProject.Audio.Services;
using FinalYearProject.Server.Exceptions;
using FinalYearProject.Server.Interfaces;
using FinalYearProject.Server.Models;
using FinalYearProject.Shared.Models.Dtos;

namespace FinalYearProject.Server.Services
{
    public class AudioFileProcessorService(FileSettings settings,
        AudioAnalysisPipelineService analysisService) : IAudioFileProcessorService
    {
        public FileSettings Settings { get; } = settings;

        public AudioAnalysisPipelineService AnalysisService { get; } = analysisService;

        public async Task<AccuracyResultsDto> ProcessAudioFileAsync(AnalysisRequestDto requestDto)
        {
            // 1. Create a Temporary Folder within base directory
            var tempFolderPath = CreateTemporaryFolder();

            var filePath = string.Empty;

            // 2. Save the uploaded audio file to the Temporary Folder
            try
            {
                filePath = await SaveFileToFolderAsync(tempFolderPath, requestDto);
            }

            // Failed to save as file is null, delete temporary folder and rethrow
            catch (ArgumentNullException)
            {
                CleanupTemporaryFolder(tempFolderPath);
                throw new AudioFileProcessingException("Payload File was null, cannot processes");
            }

            if (filePath == string.Empty)
            {
                CleanupTemporaryFolder(tempFolderPath);
                throw new AudioFileProcessingException("Failed to save uploaded audio file.");
            }

            // 3. Run the Audio Analysis Pipeline on this file
            var results = AnalysisService.AnalyzeAudioFile(filePath);

            // 5. Delete Temporary Folder
            CleanupTemporaryFolder(tempFolderPath);

            // 6. Return Data

            return new AccuracyResultsDto
            {
                NoteAccuracy = 0.95f // Placeholder value
            };
        }

        /// <summary>
        /// Deletes the Temporary Folder and its contents
        /// </summary>
        /// <param name="tempFolderPath"></param>
        private void CleanupTemporaryFolder(string tempFolderPath)
        {
            // Clean up temporary folder if file saving fails
            Directory.Delete(tempFolderPath, true);
        }

        /// <summary>
        /// Saves the uploaded audio file to the specified temporary folder.
        /// </summary>
        /// <param name="tempFolderPath"></param>
        /// <param name="requestDto"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        private static async Task<string> SaveFileToFolderAsync(string tempFolderPath, AnalysisRequestDto requestDto)
        {
            var file = requestDto.AudioFile
                ?? throw new ArgumentNullException(nameof(requestDto.AudioFile), "Uploaded audio file cannot be null.");

            var filePath = Path.Combine(tempFolderPath, file.FileName);

            using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);

            stream.Close();

            return filePath;


        }

        /// <summary>
        /// Creates the Temporary Folder where audio files will be stored during processing.
        /// </summary>
        /// <returns></returns>
        private string CreateTemporaryFolder()
        {
            var baseDirectory = Settings.BaseFolder;

            if (!Directory.Exists(baseDirectory))
            {
                // Ensure base directory exists
                Directory.CreateDirectory(baseDirectory);
            }

            // Generate a unique temporary folder name
            var tempFolderName = $"temp_{Guid.NewGuid()}";
            var tempFolderPath = Path.Combine(baseDirectory, tempFolderName);

            Directory.CreateDirectory(tempFolderPath);

            return tempFolderPath;
        }
    }
}
