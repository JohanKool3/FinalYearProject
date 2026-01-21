
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
    }
}
