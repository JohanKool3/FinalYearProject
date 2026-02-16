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

        /// <summary>
        /// Whether this Audio Bus should provide output or not
        /// </summary>
        public bool IsEnabled { get; private set; } = true;


        #region Input and Effects

        // Inputs
        public List<IAudioSource> Sources { get; private set; } = [];

        // Effects
        public List<IAudioEffect> Effects { get; private set; } = [];

        #endregion

        /// <summary>
        /// Volume between 0 and 100 representing 0% and 100%
        /// </summary>
        public int Volume
        {
            get;
            set => Math.Clamp(value, 0, 100);
        } = 100;

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

        public void AdjustVolume(int volume)
        {
            Volume = Math.Clamp(volume, 0, 100);
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


        public void ToggleActive()
        {
            // Stop All Sources, then toggle
            Stop();
            IsEnabled = !IsEnabled;

        }

        public ISampleProvider? GetOutput()
        {
            if (!IsEnabled)
            {
                return null;
            }

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
            if (!IsEnabled)
            {
                return;
            }

            foreach (var source in Sources)
            {
                source.Start();
            }
        }

        public void Stop()
        {
            if (!IsEnabled)
            {
                return;
            }

            foreach (var source in Sources)
            {
                source.Stop();
            }
        }
    }
}
