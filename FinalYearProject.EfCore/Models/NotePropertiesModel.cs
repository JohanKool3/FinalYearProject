using FinalYearProject.Shared.Enums;

namespace FinalYearProject.EfCore.Models
{
    public class NotePropertiesModel
    {
        /// <summary>
        /// How Long the Note is held for (in beats)
        /// </summary>
        public double Length { get; set; }

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