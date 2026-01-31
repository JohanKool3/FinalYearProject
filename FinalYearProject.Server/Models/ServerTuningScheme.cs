using FinalYearProject.Audio.Models;
using FinalYearProject.Server.Interfaces;

namespace FinalYearProject.Server.Models
{
    /// <summary>
    /// Wrapper for TuningScheme specific to server settings.
    /// </summary>
    public class ServerTuningScheme : TuningScheme, ISetting
    {
    }
}