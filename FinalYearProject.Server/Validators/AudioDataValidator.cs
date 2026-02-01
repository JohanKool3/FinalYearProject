using FinalYearProject.Server.Interfaces;
using FinalYearProject.Server.Models;

namespace FinalYearProject.Server.Validators
{
    public class AudioDataValidator(ValidationSettings validationSettings) : IDataValidator<AnalysisRequest>
    {
        #region Dependencies

        public ValidationSettings Settings { get; } = validationSettings;

        #endregion

        public async Task<bool> ValidDataAsync(AnalysisRequest audioData)
        {
            var fileData = audioData.AudioFile;

            // Check if file is null
            if (fileData is null)
            {
                return false;
            }

            // Checks if the payload contains valid MIME type
            if (!IsValidMime(fileData))
            {
                return false;
            }

            if (!IsValidMetadata(fileData))
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

        private bool IsValidMime(IFormFile fileData)
        {
            // Check high-level MIME type
            var contentType = fileData.ContentType.ToLowerInvariant();
            var contentTypeHeaderValues = fileData.Headers["Content-Type"];

            // Content Type is not allowed
            if (!Settings.AllowedMimeTypes.Contains(contentType))
            {
                return false;
            }

            // Content Type header value mismatch (should be the same as ContentType)
            if (contentType != contentTypeHeaderValues)
            {
                return false;
            }

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
            if (fileData.Length > Settings.MaxAudioFileSizeBytes)
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
        private bool IsValidMetadata(IFormFile fileData)
        {
            var fileExtension = Path.GetExtension(fileData.FileName).ToLowerInvariant();

            var allowedExtensions = Settings.AllowedFileExtensions;

            if (!allowedExtensions.Contains(fileExtension))
            {
                return false;
            }

            return true;
        }
    }
}
