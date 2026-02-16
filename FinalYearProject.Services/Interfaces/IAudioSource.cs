using NAudio.Wave;

namespace FinalYearProject.Services.Interfaces
{
    /// <summary>
    /// Defines a Source that produces an Audio Stream
    /// </summary>
    public interface IAudioSource
    {
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
    }
}
