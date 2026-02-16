using FinalYearProject.Services.Audio.Windows.AudioSources;
using FinalYearProject.Services.Interfaces;
using FinalYearProject.Shared.Models;

namespace FinalYearProject.Services.Audio.Windows.AudioBuses
{
    public class BackingTrackBus(UserSettings channelSettings) 
        : SubAudioBusBase<BackingTrackSource>(channelSettings)
    {
        public override string Name => "backing-track-bus";
    }
}
