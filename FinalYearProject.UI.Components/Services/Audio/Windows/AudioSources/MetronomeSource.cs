using FinalYearProject.Services.Interfaces;
using FinalYearProject.Services.SampleProviders;
using FinalYearProject.Shared.Services;
using FinalYearProject.UI.Components.Services.Audio.Windows.AudioBuses;
using NAudio.Wave;

namespace FinalYearProject.UI.Components.Services.Audio.Windows.AudioSources
{
    public class MetronomeSource(
        DisplayService displayService,
        UserBus userBus) : IAudioSource
    {
        public bool IsEnabled => true;

        public string Name => "metronome-source";

        public ISampleProvider? SampleProvider
            => new MetronomeSampleProvider(
                DisplayService.Bpm, 
                UserBus?.Source?.SampleProvider?.WaveFormat);

        public DisplayService DisplayService { get; } = displayService;

        public UserBus UserBus { get; } = userBus;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public ISampleProvider? GetOutput()
            => SampleProvider;

        public void Start()
        {
            return;
        }

        public void Stop()
        {
            return;
        }
    }
}
