using NAudio.Wave;

namespace FinalYearProject.Services.Interfaces
{
    /// <summary>
    /// Represents a component that is responsible for accepting input,
    /// applying effects to it and then outputting it
    /// </summary>
    public interface IAudioBus
    {
        /// <summary>
        /// Add an audio Source to this Mixer Bus
        /// </summary>
        /// <param name="source"></param>
        void AddSource(IAudioSource source);

        /// <summary>
        /// Remove a specific Audio Source from this Mixer Bus
        /// </summary>
        /// <param name="source"></param>
        void RemoveSource(IAudioSource source);


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

        /// <summary>
        /// Returns an output of the input ran through the effects
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Returns Null if a Mixer has not been set
        /// </remarks>
        ISampleProvider? GetOutput();
    }
}
