using FinalYearProject.Services.Interfaces;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace FinalYearProject.Services.Audio.Windows.AudioBuses
{
    /// <summary>
    /// Defines a Base class for a Sub Audio Bus (one that will feed into
    /// the main bus)
    /// </summary>
    public class SubAudioBusBase : IAudioBus, IAudioSource
    {

        #region Input and Effects

        // Inputs
        public List<IAudioSource> Sources { get; private set; } = [];

        // Effects
        public List<IAudioEffect> Effects { get; private set; } = [];

        #endregion

        /// <summary>
        /// Volume between 0 and 1 representing 0% and 100%
        /// </summary>
        public double Volume { get; private set; } = 1;

        /// <summary>
        /// The Mixer for this Sub Audio Bus
        /// </summary>
        public MixingSampleProvider? Mixer { get; private set; }

        #region Add + Remove

        public void AddEffect(IAudioEffect effect)
        {
            Effects.Add(effect);
        }

        public void AddSource(IAudioSource source)
        {
            Sources.Add(source);
        }

        public void AdjustVolume(double volume)
        {
            Volume = Math.Clamp(volume, 0, 1);
        }

        public void RemoveEffect(IAudioEffect effect)
        {
            Effects.Remove(effect);
        }

        public void RemoveSource(IAudioSource source)
        {
            Sources.Remove(source);
        }

        #endregion

        /// <summary>
        /// Sets up the Mixer for use. All Sources must have the same
        /// Wave Format to work
        /// </summary>
        /// <param name="waveFormat"></param>
        public void SetMixer(WaveFormat waveFormat)
            => Mixer = new MixingSampleProvider(waveFormat);

        public ISampleProvider? GetOutput()
        {
            // Ensure the Mixer has been set
            if (Mixer is null)
            {
                return null;
            }

            // Add Sources
            foreach (var input in Sources)
            {
                var inputSampleProvider = input.GetOutput();

                // Check if the Input mixer has been set
                if (inputSampleProvider is not null)
                {
                    Mixer.AddMixerInput(inputSampleProvider);
                }
            }

            // Run Sources Through FX
            ISampleProvider current = Mixer;

            foreach (var effect in Effects)
            {
                var output = effect.Apply(current);

                if (output is not null)
                {
                    current = output;
                }

            }

            // Return sample Provider post effects
            return current;
        }

        public void Start()
        {
            foreach(var source in Sources)
            {
                source.Start();
            }
        }

        public void Stop()
        {
            foreach (var source in Sources)
            {
                source.Stop();
            }
        }
    }
}
