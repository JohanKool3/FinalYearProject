using FinalYearProject.Services.Audio.Windows.AudioEffects;
using FinalYearProject.Services.Audio.Windows.AudioSources;
using FinalYearProject.Services.Interfaces;
using FinalYearProject.Shared.Models;
using NAudio.Wave;

namespace FinalYearProject.Services.Audio.Windows.AudioBuses
{
    public class BackingTrackBus(UserSettings channelSettings) 
        : SubAudioBusBase<BackingTrackSource>(channelSettings)
    {
        public override string Name => "backing-track-bus";

        public override ISampleProvider? GetOutput()
        {
            if (!IsEnabled)
            {
                return null;
            }

            Effects.Clear();

            Effects.AddRange(GetBackingTrackEffectsChain());

            return base.GetOutput();
        }

        private IEnumerable<IAudioEffect> GetBackingTrackEffectsChain()
        {
            List<IAudioEffect> output = [];

            var preFXGain = new PreFXGainEffect()
            {
                GainPercentage = Settings.BackingTrackVolume,
            };

            output.Add(preFXGain);

            return output;
        }
    }
}
