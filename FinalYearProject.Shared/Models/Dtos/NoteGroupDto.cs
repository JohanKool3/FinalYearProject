using FinalYearProject.Shared.Models.UI.Bar;

namespace FinalYearProject.Shared.Models.Dtos
{
    public class NoteGroupDto
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
        public required List<ExpectedNoteDto> Notes { get; set; }

        /// <summary>
        /// The Chords that are a part of this Group
        /// </summary>
        public required List<ChordInformationDto> Chords { get; set; }
    }
}