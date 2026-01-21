namespace FinalYearProject.Audio.Models
{
    public class Window
    {
        /// <summary>
        /// The Samples assigned to this audio window
        /// </summary>
        public List<float> Samples { get; set; } = [];

        /// <summary>
        /// How long this set of samples lasts in seconds
        /// </summary>
        public double AudioLength { get; set; }

        /// <summary>
        /// When the Window started (in seconds)
        /// </summary>
        public double StartTime { get; set; }

        /// <summary>
        /// When the Window ended (in seconds)
        /// </summary>
        public double EndTime { get; set; }
    }
}
