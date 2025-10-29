using FinalYearProject.Shared.Enums;
using FinalYearProject.Shared.Helpers;

namespace FinalYearProject.Shared.Models.UI.Bar
{
    /// <summary>
    /// Properties of a Note
    /// </summary>
    public class NoteProperties
    {
        /// <summary>
        /// How Long the Note is held for (in beats)
        /// </summary>
        public double Length { get; set; }

        /// <summary>
        /// Calculated Beat Subdivisions based on Length
        /// </summary>
        public DurationMetadata BeatMetadata 
            => NoteHelper.GetDurationMetadata(Length);

        /// <summary>
        /// The Type of note being displayed
        /// </summary>
        public NoteType Type { get; set; }
            = NoteType.Normal;

        /// <summary>
        /// Whether to display the note as grouped with others
        /// </summary>
        public bool IsGrouped { get; set; }

        /// <summary>
        /// How the note is articulated
        /// </summary>
        public ArticulationType Articulation { get; set; }
            = ArticulationType.None;
    }
}
