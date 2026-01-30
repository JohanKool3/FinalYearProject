using FinalYearProject.Server.Interfaces;
using FinalYearProject.Server.Models;
using FinalYearProject.Shared.Models.Dtos;
using Microsoft.Extensions.FileProviders;

namespace FinalYearProject.Server.Validators
{
    public class AudioDataValidator(ValidationSettings validationSettings) : IAudioDataValidator
    {
        #region Dependencies
        
        public ValidationSettings ValidationSettings { get; } = validationSettings;

        #endregion

        public bool ValidAudioData(AnalysisRequestDto audioData)
        {
            var fileData = audioData.AudioFile;

            if(!IsValidMetadata(fileData))
            {
                return false;
            }

            if (!IsValidContents(fileData))
            {
                return false;
            }

            //TODO: Additional checks can be added here (e.g., audio format validation)
            // as well as header checks to ensure the file is not corrupted or malformed.

            return true;
        }

        /// <summary>
        /// Performs bounds checks on the file contents to ensure validity
        /// </summary>
        /// <param name="fileData"></param>
        /// <returns></returns>
        private bool IsValidContents(IFormFile fileData)
        {
            // Check if file size is greater than 0
            if (fileData.Length <= 0)
            {
                return false;
            }

            // Check if file size exceeds maximum allowed size
            if (fileData.Length > ValidationSettings.MaxAudioFileSizeBytes)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Ensures that the file metadata is valid
        /// </summary>
        /// <param name="fileData"></param>
        /// <returns></returns>
        private static bool IsValidMetadata(IFormFile? fileData)
        {
            // Check if file is null
            if (fileData is null)
            {
                return false;
            }

            // Check File Type (e.g., only allow .wav)
            var allowedExtensions = new[] { ".wav", ".mp3" };

            var fileExtension = Path.GetExtension(fileData.FileName).ToLowerInvariant();

            if (!allowedExtensions.Contains(fileExtension))
            {
                return false;
            }

            return true;
        }
    }
}
