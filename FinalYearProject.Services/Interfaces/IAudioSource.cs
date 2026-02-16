using NAudio.Wave;

namespace FinalYearProject.Services.Interfaces
{
    /// <summary>
    /// Defines a Source that produces an Audio Stream
    /// </summary>
    public interface IAudioSource
    {
        public string Name { get; }


        /// <summary>
        /// Whether this Audio Source is Enabled
        /// </summary>
        bool IsEnabled { get; }

        /// <summary>
        /// Returns an Audio Sample Source
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Returns Null if a mixer has not been set
        /// </remarks>
        ISampleProvider? GetOutput();

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
