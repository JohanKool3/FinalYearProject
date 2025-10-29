using FinalYearProject.UI.Components.Enums;
using FinalYearProject.UI.Components.Interfaces;

namespace FinalYearProject.UI.Components.Models.InterfaceElements.Bar
{
    public class NoteInformation : IPositionedElement
    {

        /// <summary>
        /// Where this Note Starts Relative to the Note Group (0-100%)
        /// </summary>
        public int StartPercentage { get; set; }

        /// <summary>
        /// When this Note Ends Relative to the Note Group (0-100%)
        /// </summary>
        public int EndPercentage { get; set; }

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
            = NoteType.Separated;

        /// <summary>
        /// How the note is articulated
        /// </summary>
        public ArticulationType ArticulationType { get; set; } 
            = ArticulationType.None;

    }
}
