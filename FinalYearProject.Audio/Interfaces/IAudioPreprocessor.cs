namespace FinalYearProject.Audio.Interfaces
{
    /// <summary>
    /// Definines a Component that takes audio data from an IAudioSource 
    /// and processes it for use in components further down the audio pipeline.
    /// </summary>
    public interface IAudioPreprocessor
    {
        /// <summary>
        /// Takes an Input Buffer and Processe it, then writes the result to the Output Buffer
        /// </summary>
        /// <param name="input"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        int Process(float[] input, float[] output);
    }
}
