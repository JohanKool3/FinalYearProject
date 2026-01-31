using FinalYearProject.Audio.Models;
using FinalYearProject.Server.Interfaces;

namespace FinalYearProject.Server.Models
{
    /// <summary>
    /// Wrapper for DetectionSettings specific to the server application.
    /// </summary>
    public class ServerDetectionSettings: DetectionSettings, ISetting
    {
    }
}