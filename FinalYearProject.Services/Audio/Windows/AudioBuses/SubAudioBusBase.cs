using FinalYearProject.Services.Interfaces;
using FinalYearProject.Shared.Models;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace FinalYearProject.Services.Audio.Windows.AudioBuses
{
    /// <summary>
    /// Defines a Base class for a Sub Audio Bus (one that will feed into
    /// the main bus)
    /// </summary>
    /// <typeparam name="TAudioSource"> The type of audio source</typeparam>
    /// <param name="settings"></param>
    public class SubAudioBusBase<TAudioSource>(UserSettings settings)
        : ISubAudioBus<TAudioSource> where TAudioSource : IAudioSource
      
    {
        #region Dependencies

        /// <summary>
        /// Holds Details about the Audio Busses.
        /// </summary>
        public UserSettings Settings { get; } = settings;

        #endregion

        /// <summary>
        /// Whether this Audio Bus should provide output or not
        /// </summary>
        public bool IsEnabled { get; private set; } = true;


        #region Input and Effects

        // Inputs
        public virtual TAudioSource? Source { get; internal set; }

        // Effects
        public List<IAudioEffect> Effects { get; internal set; } = [];

        #endregion

        /// <summary>
        /// The Mixer for this Sub Audio Bus
        /// </summary>
        public MixingSampleProvider? Mixer { get; internal set; }

        public virtual string Name => "default";

        public ISampleProvider SampleProvider => throw new NotImplementedException();

        #region Add + Remove

        public void AddEffect(IAudioEffect effect)
        {
            Effects.Add(effect);
        }

        public void AddSource(TAudioSource source)
            => Source = source;

        public void RemoveEffect(IAudioEffect effect)
        {
            Effects.Remove(effect);
        }

        public void RemoveSource(TAudioSource source)
            => Source = default;

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
            if (IsEnabled)
            {
                Stop();
                IsEnabled = false;
            }
            else
            {
                Stop();
                // Edit the current setup, then start playback again
                IsEnabled = true;
            }
        }

        public virtual ISampleProvider? GetOutput()
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

            if (Source is null)
            {
                return null;
            }

            // Add Source
            var inputSampleProvider = Source.SampleProvider;

            // Check if the Input mixer has been set
            if (inputSampleProvider is not null)
            {
                Mixer.AddMixerInput(inputSampleProvider);
            }

            // Run Source Through FX
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

            Source?.Start();
        }

        public void Stop()
        {
            if (!IsEnabled)
            {
                return;
            }

            Source?.Stop();
        }
    }
}
