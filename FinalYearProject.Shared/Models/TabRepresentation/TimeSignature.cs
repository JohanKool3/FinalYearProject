namespace FinalYearProject.Shared.Models.TabRepresentation
{
    /// <summary>
    /// Representation of a Time Signature in music, e.g. 4/4, 3/4, 6/8
    /// </summary>
    public class TimeSignature
    {

        /// <summary>
        /// How many beats are in a measure, e.g. 4 in 4/4, 3 in 3/4
        /// </summary>
        public int BeatsPerMeasure { get; set; }

        /// <summary>
        /// How big a beat is, e.g. 4 = quarter note in 4/4, 8 = eighth note in 6/8
        /// </summary>
        public int BeatUnit { get; set; }
    }
}