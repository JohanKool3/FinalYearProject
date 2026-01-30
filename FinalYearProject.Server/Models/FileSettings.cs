using FinalYearProject.Server.Interfaces;

namespace FinalYearProject.Server.Models
{
    public class FileSettings : ISetting
    {
        /// <summary>
        /// Holds the name of the Folder that all temporary files
        /// will be saved to
        /// </summary>
        public string BaseFolder { get; set; } = string.Empty;
    }
}