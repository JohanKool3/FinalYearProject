namespace FinalYearProject.Audio.Exceptions
{
    /// <summary>
    /// Exception that is thrown when an error occurs in the audio analysis pipeline
    /// </summary>
    public class AudioAnalysisPipelineException : Exception
    {
        /// <summary>
        /// The Stage at which an error occurred
        /// <list type="number">
        /// <item>Reading audio data from File</item>
        /// <item>Converting audio data from Stream into Windows</item>
        /// <item>Converting Windowed Data to Frequency Domain (DSP Layer)</item>
        /// <item>Frequency Timeline Construction</item>
        /// <item>Note Timeline Construction</item>
        /// </list>
        /// </summary>
        public int ErrorStage { get; set; }

        public AudioAnalysisPipelineException(int errorStage)
        {
            ErrorStage = errorStage;
        }

        public AudioAnalysisPipelineException(int errorStage, string? message) : base(message)
        {
            ErrorStage = errorStage;
        }
    }
}
