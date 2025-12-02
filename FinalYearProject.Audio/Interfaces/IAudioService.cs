using FinalYearProject.Shared.Models.AudioRepresentation;

namespace FinalYearProject.Audio.Interfaces
{
    public interface IAudioService
    {
        /// <summary>
        /// Event Handler for On Tick Events. These are events that should be fired
        /// each tick of the internal timer
        /// </summary>
        event EventHandler OnTickEvent;

        /// <summary>
        /// Reads the Internal Buffer and converts it into an Fft Result model.
        /// </summary>
        /// <param name="resolution"></param>
        /// <returns></returns>
        /// <remarks>This method should not move playback along, it is purely to analyse
        /// the data already present in the buffer</remarks>
        FftResult? ReadBufferToFrequencyDomain(int resolution);

        void Reset();

        void Start();

        void Stop();
    }
}