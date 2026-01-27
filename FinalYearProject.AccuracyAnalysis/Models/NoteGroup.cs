namespace FinalYearProject.Accuracy.Analysis.Models
{
    public class NoteGroup
    {
        /// <summary>
        /// When this group of notes starts (in seconds)
        /// </summary>
        public double StartTime { get; set; }

        /// <summary>
        /// When this group of notes ends (in seconds)
        /// </summary>
        public double EndTime { get; set; }

        /// <summary>
        /// The Notes that are part of this group
        /// </summary>
        public List<ExpectedNote> Notes { get; set; } = [];
    }
}