using NAudio.Wave;

namespace FinalYearProject.Services.Interfaces
{
    /// <summary>
    /// Represents a component that is responsible for accepting input,
    /// applying effects to it and then outputting it
    /// </summary>
    /// <typeparam name="TAudioSource">The type of audio source</typeparam>
    public interface IAudioBus<TAudioSource>
    {
        /// <summary>
        /// Sets up the Mixer for use. All Sources must have the same
        /// Wave Format to work
        /// </summary>
        /// <param name="waveFormat"></param>
        public void SetMixer(WaveFormat waveFormat);

        /// <summary>
        /// Add an audio Source to this Mixer Bus
        /// </summary>
        /// <param name="source"></param>
        void AddSource(TAudioSource source);

        /// <summary>
        /// Remove a specific Audio Source from this Mixer Bus
        /// </summary>
        /// <param name="source"></param>
        void RemoveSource(TAudioSource source);


        /// <summary>
        /// Add an Effect to this Mixer Bus
        /// </summary>
        /// <param name="effect"></param>
        void AddEffect(IAudioEffect effect);

        /// <summary>
        /// Remove an Effect from this Mixer Bus
        /// </summary>
        /// <param name="effect"></param>
        void RemoveEffect(IAudioEffect effect);
    }
}
