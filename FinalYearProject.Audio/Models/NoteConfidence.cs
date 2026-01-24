
namespace FinalYearProject.Audio.Models
{
    /// <summary>
    /// Represents the confidence level of a detected note based on 
    /// its fundamental frequency and how close it matches it.
    /// </summary>
    public class NoteConfidence
    {
        /// <summary>
        /// The Name of the Note (e.g., "C4")
        /// </summary>
        public required string Name { get; set; } = string.Empty;

        /// <summary>
        /// Bounds for the Fundamental Frequency of the note in Hz (e.g., for A4, it might be (430.0, 450.0))
        /// </summary>
        public required Tuple<float, float> FundamentalFrequencyBounds { get; set; }

        /// <summary>
        /// How confident the system is that this note is present (0.0 to 1.0)
        /// </summary>
        public float Confidence { get; set; } 
    }
}
