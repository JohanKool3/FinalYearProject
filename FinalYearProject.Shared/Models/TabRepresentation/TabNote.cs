namespace FinalYearProject.Shared.Models.TabRepresentation
{
    /// <summary>
    /// A single note in a tablature representation
    /// </summary>
    public class TabNote
    {
        /// <summary>
        /// 1 = high E, 6 = low E, If null then it is a rest
        /// </summary>
        public required int? StringNumber { get; set; }

        /// <summary>
        /// The fret for this note
        /// </summary>
        public required int FretNumber { get; set; }

        /// <summary>
        /// When the note started in Beats
        /// </summary>
        public required double StartTime { get; set; }

        /// <summary>
        /// How long the note will last in Beats
        /// </summary>
        public required double Duration { get; set; }
    }
}
