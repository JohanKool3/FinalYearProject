namespace FinalYearProject.Audio.Interfaces
{
    /// <summary>
    /// An Interface for a Component that will return Audio Data.
    /// </summary>
    public interface IAudioSource : IAsyncDisposable
    {
        /// <summary>
        /// The number of samples per second in Khz.
        /// </summary>
        public int SampleRate { get; set; }

        /// <summary>
        /// Gets or sets the number of audio channels used by the instance.
        /// </summary>
        /// <remarks>A value of 1 typically indicates mono audio, while 2 indicates stereo</remarks>
        public int Channels { get; set; }

        /// <summary>
        /// Fill the buffer with the next block of samples.
        /// Returns the number of samples actually written.        
        /// </summary>
        /// <param name="buffer">Variable that will store the next 'chunk' of 
        /// audio data</param>
        /// <returns></returns>
        public int Read(float[] buffer);
    }
}
