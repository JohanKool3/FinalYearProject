using NAudio.Wave;

namespace FinalYearProject.Services.Interfaces
{
    /// <summary>
    /// Defines a Source that produces an Audio Stream
    /// </summary>
    public interface IAudioSource : IDisposable
    {
        /// <summary>
        /// Returns an Audio Sample Source
        /// </summary>
        /// <returns></returns>
        ISampleProvider GetSampleProvider();

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
