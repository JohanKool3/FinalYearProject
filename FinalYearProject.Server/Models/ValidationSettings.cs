using FinalYearProject.Server.Interfaces;

namespace FinalYearProject.Server.Models
{
    public class ValidationSettings : ISetting
    {
        /// <summary>
        /// Defines the file extensions that are allowed for audio uploads.
        /// </summary>
        public List<string> AllowedFileExtensions { get; set; } = [];

        /// <summary>
        /// Defines the maximum allowed size for audio files in bytes.
        /// </summary>
        public int MaxAudioFileSizeBytes { get; set; }
    }
}