
using FinalYearProject.UI.Components.Enums;
using FinalYearProject.UI.Components.Interfaces;

namespace FinalYearProject.UI.Components.Models
{
    public class NoteDisplayInformation : IPositionedElement
    {
        /// <summary>
        /// How far accross the bar the note is (0-100) in %
        /// </summary>
        public int BarPercentage { get; set; }

        /// <summary>
        /// Which Fret the note is on
        /// </summary>
        public int FretNumber { get; set; }

        /// <summary>
        /// Which String the note is on (1-6)
        /// </summary>
        public int StringNumber { get; set; } = 6;

        /// <summary>
        /// The Type of note being displayed
        /// </summary>
        public NoteType NoteType { get; set; } 
            = NoteType.Normal;

        /// <summary>
        /// How the note is articulated
        /// </summary>
        public ArticulationType ArticulationType { get; set; } 
            = ArticulationType.None;

    }
}
