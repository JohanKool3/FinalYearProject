using NAudio.Wave;

namespace FinalYearProject.Services.Interfaces
{
    /// <summary>
    /// Defines a component that augments an Audio Data Stream
    /// </summary>
    public interface IAudioEffect
    {
        /// <summary>
        /// Takes an Input and applies the given processing to it
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        ISampleProvider Apply(ISampleProvider input);
    }
}