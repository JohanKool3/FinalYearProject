
namespace FinalYearProject.Audio.Models
{
    public class FftOutput
    {
        /// <summary>
        /// Frequencies from the Window
        /// </summary>
        public required float[] Frequencies { get; set; }

        /// <summary>
        /// Magnitudes of the frequences (maps from Frequencies[i] -> Magnitudes[i])
        /// </summary>
        public required float[] Magnitudes { get; set; }

        /// <summary>
        /// How long the window these Frequencies were gathered from (in seconds)
        /// </summary>
        public required double AudioLength { get; set; }

        /// <summary>
        /// When the Window started (in seconds)
        /// </summary>
        public required double StartTime { get; set; }

        /// <summary>
        /// When the Window ended (in seconds)
        /// </summary>
        public required double EndTime { get; set; }
    }
}
