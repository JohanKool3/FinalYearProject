namespace FinalYearProject.Shared.Models.Dtos
{
    public class NoteGroupInformationDto
    {
        /// <summary>
        /// The Notes that belong to this Group
        /// </summary>
        public required List<NoteDto> Notes { get; set; }

        /// <summary>
        /// Where this Group Starts Relative to the Bar (0-100%)
        /// </summary>
        public required int BarStartPercentage { get; set; }

        /// <summary>
        /// Where this Groups Ends Relative to the Bar (0-100%)
        /// </summary>
        public required int BarEndPercentage { get; set; }

        /// <summary>
        /// How Long the Group is in Beats 
        /// (e.g., 1.0 = Quarter Note, 0.5 = Eighth Note)
        /// </summary>
        public required double TotalGroupBeatLength { get; set; }
    }
}
