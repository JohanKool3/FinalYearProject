using FinalYearProject.Shared.Enums;

namespace FinalYearProject.Shared.Models.Dtos
{
    public class NotePropertiesDto
    {
        /// <summary>
        /// How Long the Note is held for (in beats)
        /// </summary>
        public required double Length { get; set; }

        /// <summary>
        /// The Type of note being displayed
        /// </summary>
        public required NoteType Type { get; set; }

        /// <summary>
        /// Whether to display the note as grouped with others
        /// </summary>
        public required bool IsGrouped { get; set; }

        /// <summary>
        /// How the note is articulated
        /// </summary>
        public required ArticulationType Articulation { get; set; }
    }
}
