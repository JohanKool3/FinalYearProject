using FinalYearProject.Services.Interfaces;
using FinalYearProject.Shared.Models;
using FinalYearProject.Shared.Services;
using FinalYearProject.UI.Components.Services.Audio.Windows.AudioEffects;
using FinalYearProject.UI.Components.Services.Audio.Windows.AudioSources;
using NAudio.Wave;

namespace FinalYearProject.UI.Components.Services.Audio.Windows.AudioBuses
{
    public class MetronomeBus(UserSettings channelSettings,
        DisplayService displayService,
        UserBus userBus)
        : SubAudioBusBase<MetronomeSource>(channelSettings),
        ISubAudioBus<MetronomeSource>
    {
        public override string Name => "metronome-bus";

        public override MetronomeSource? Source
        {
            get => new(DisplayService, UserBus);
            internal set;
        }
        public DisplayService DisplayService { get; } = displayService;
        
        public UserBus UserBus { get; } = userBus;


        public override ISampleProvider? GetOutput()
        {
            if (!IsEnabled)
            {
                return null;
            }

            Effects.Clear();

            Effects.AddRange(GetMetronomeEffectsChain());

            return base.GetOutput();
        }

        private IEnumerable<IAudioEffect> GetMetronomeEffectsChain()
        {
            List<IAudioEffect> output = [];

            var preFXGain = new PreFXGainEffect()
            {
                GainPercentage = Settings.MetronomeVolume,
            };

            output.Add(preFXGain);

            return output;
        }
    }
}
