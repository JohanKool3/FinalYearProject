namespace FinalYearProject.Audio.Models
{
    /// <summary>
    /// Holds information about a tuning scheme e.g
    /// A = 440Hz
    /// </summary>
    public class TuningScheme
    {
        /// <summary>
        /// The frequency that A4 is tuned to.
        /// </summary>
        public double A4 { get; set; } = 440.0;
    }
}