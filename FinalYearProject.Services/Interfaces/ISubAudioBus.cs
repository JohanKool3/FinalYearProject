using NAudio.Wave;

namespace FinalYearProject.Services.Interfaces
{
    public interface ISubAudioBus<out TAudioSource>
        where TAudioSource : IAudioSource
    {
        /// <summary>
        /// Returns an output of the input ran through the effects
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Returns Null if a Mixer has not been set
        /// </remarks>
        ISampleProvider? GetOutput();

        public string Name { get; }

        public ISampleProvider? SampleProvider { get; }

        /// <summary>
        /// Whether this Audio Source is Enabled
        /// </summary>
        bool IsEnabled { get; }

        /// <summary>
        /// Starts the Source
        /// </summary>
        void Start();

        /// <summary>
        /// Stops the Source
        /// </summary>
        void Stop();

        /// <summary>
        /// Sets up the Mixer for use. All Sources must have the same
        /// Wave Format to work
        /// </summary>
        /// <param name="waveFormat"></param>
        public void SetMixer(WaveFormat waveFormat);
    }
}
