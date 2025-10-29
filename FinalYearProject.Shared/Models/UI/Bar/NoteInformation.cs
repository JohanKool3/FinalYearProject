
using FinalYearProject.Shared.Interfaces;

namespace FinalYearProject.Shared.Models.UI.Bar
{
    public class NoteInformation : IPositionedElement
    {

        /// <summary>
        /// Where this Note Starts Relative to the Note Group (0-100%)
        /// </summary>
        public double StartPercentage { get; set; }

        /// <summary>
        /// When this Note Ends Relative to the Note Group (0-100%)
        /// </summary>
        public double EndPercentage { get; set; }

        /// <summary>
        /// Which Fret the note is on
        /// </summary>
        public int FretNumber { get; set; }

        /// <summary>
        /// Which String the note is on (1-6)
        /// </summary>
        public int StringNumber { get; set; } = 6;

        /// <summary>
        /// Properties for the Note
        /// </summary>
        public NoteProperties Properties { get; set; } = new();
    }
}
