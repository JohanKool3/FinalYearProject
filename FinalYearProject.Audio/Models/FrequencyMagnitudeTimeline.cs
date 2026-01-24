
namespace FinalYearProject.Audio.Models
{
    public class FrequencyMagnitudeTimeline
    {

        /// <summary>
        /// Holds the magnitudes for a given frequency over time.
        /// </summary>
        /// <remarks>
        /// Each key is a frequency (float) and the value is a list of magnitudes (float) at each time window.
        /// </remarks>
        public required Dictionary<float, List<float>> FrequencyMagnitude { get; set; }

        /// <summary>
        /// Frequencies represented in the timeline
        /// </summary>
        public required List<float> Frequencies { get; set; }

        /// <summary>
        /// The Magnitudes for each window (maps from RawMagnitudes[i] -> Magnitudes at window i) for each frequency
        /// </summary>
        public required List<float[]> FrequencyMagnitudes { get; set; }

        /// <summary>
        /// The Length of the audio clip in seconds
        /// </summary>
        public float Length { get; set; }

        /// <summary>
        /// How long each data point is in seconds.
        /// </summary>
        public double DataPointLength { get; set; }
    }
}
