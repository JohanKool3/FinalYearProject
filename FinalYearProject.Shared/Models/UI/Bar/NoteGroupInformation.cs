namespace FinalYearProject.Shared.Models.UI.Bar
{
    /// <summary>
    /// Represents a Grouping of Notes
    /// </summary>
    public class NoteGroupInformation
    {
        /// <summary>
        /// The Notes that are assigned to this group
        /// </summary>
        //TODO: Extend this to allow Chords at each note position
        public List<NoteInformation> Notes { get; set; } = [];

        /// <summary>
        /// Where this Group Starts Relative to the Bar (0-100%)
        /// </summary>
        public int BarStartPercentage { get; set; }

        /// <summary>
        /// Where this Groups Ends Relative to the Bar (0-100%)
        /// </summary>
        public int BarEndPercentage { get; set; }

        /// <summary>
        /// How Long the Group is in Beats 
        /// (e.g., 1.0 = Quarter Note, 0.5 = Eighth Note)
        /// </summary>
        public double TotalGroupBeatLength { get; set; }
    }
}
