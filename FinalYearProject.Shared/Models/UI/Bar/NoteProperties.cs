using FinalYearProject.Shared.Enums;

namespace FinalYearProject.Shared.Models.UI.Bar
{
    public class NoteProperties
    {
        /// <summary>
        /// How Long the Note is held for (in beats)
        /// </summary>
        public double Length { get; set; }

        /// <summary>
        /// The Type of note being displayed
        /// </summary>
        public NoteType Type { get; set; }
            = NoteType.Separated;

        /// <summary>
        /// How the note is articulated
        /// </summary>
        public ArticulationType Articulation { get; set; }
            = ArticulationType.None;

    }
}
