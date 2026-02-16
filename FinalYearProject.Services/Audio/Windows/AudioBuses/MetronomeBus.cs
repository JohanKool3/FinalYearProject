using FinalYearProject.Services.Audio.Windows.AudioSources;
using FinalYearProject.Services.Interfaces;
using FinalYearProject.Shared.Models;

namespace FinalYearProject.Services.Audio.Windows.AudioBuses
{
    public class MetronomeBus(UserSettings channelSettings)
        : SubAudioBusBase<MetronomeSource>(channelSettings),
        ISubAudioBus<MetronomeSource>
    {
        public override string Name => "metronome-bus";
    }
}
