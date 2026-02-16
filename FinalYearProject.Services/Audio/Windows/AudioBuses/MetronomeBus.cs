using FinalYearProject.Shared.Models;

namespace FinalYearProject.Services.Audio.Windows.AudioBuses
{
    public class MetronomeBus(UserSettings channelSettings) 
        : SubAudioBusBase(channelSettings)
    {
    }
}
