using FinalYearProject.Shared.Models;

namespace FinalYearProject.Services.Audio.Windows.AudioBuses
{
    public class BackingTrackBus(UserSettings channelSettings) 
        : SubAudioBusBase(channelSettings)
    {
    }
}
