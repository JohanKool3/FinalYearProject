using FinalYearProject.Services.Audio.Windows.AudioEffects;
using FinalYearProject.Services.Audio.Windows.AudioSources;
using FinalYearProject.Services.Interfaces;
using FinalYearProject.Shared.Models;
using NAudio.Wave;

namespace FinalYearProject.Services.Audio.Windows.AudioBuses
{
    public class MetronomeBus(UserSettings channelSettings)
        : SubAudioBusBase<MetronomeSource>(channelSettings),
        ISubAudioBus<MetronomeSource>
    {
        public override string Name => "metronome-bus";

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
