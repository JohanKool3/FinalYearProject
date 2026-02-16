using FinalYearProject.Shared.Models;

namespace FinalYearProject.Services.Audio.Windows.AudioBuses
{
    public class BackingTrackBus(UserSettings channelSettings) 
        : SubAudioBusBase(channelSettings)
    {
        public override string Name => "backing-track-bus";
    }
}
