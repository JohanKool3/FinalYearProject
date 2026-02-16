using FinalYearProject.Services.Interfaces;
using FinalYearProject.Services.SampleProviders;
using NAudio.Wave;

namespace FinalYearProject.Services.Audio.Windows.AudioEffects
{
    public class PreFXGainEffect : IAudioEffect
    {
        /// <summary>
        /// The Percentage gain (0 -> 100)
        /// </summary>
        public int GainPercentage { get; set; }

        public ISampleProvider Apply(ISampleProvider input)
        {
            float gain = GainPercentage / 100f;

            return new GainSampleProvider(input)
            {
                Gain = gain
            };
        }
    }
}
