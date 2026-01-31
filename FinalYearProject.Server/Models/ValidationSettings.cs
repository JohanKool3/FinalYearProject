using FinalYearProject.Shared.Interfaces;

namespace FinalYearProject.Server.Models
{
    public class ValidationSettings : ISetting
    {
        /// <summary>
        /// Defines the file extensions that are allowed for audio uploads.
        /// </summary>
        public List<string> AllowedFileExtensions { get; set; } = [];

        /// <summary>
        /// Defines the MIME types that are allowed for audio uploads. These
        /// outline the contents of the files. e.g. "audio/wave"
        /// </summary>
        public List<string> AllowedMimeTypes { get; set; } = [];

        /// <summary>
        /// Defines the maximum allowed size for audio files in bytes.
        /// </summary>
        public int MaxAudioFileSizeBytes { get; set; }
    }
}