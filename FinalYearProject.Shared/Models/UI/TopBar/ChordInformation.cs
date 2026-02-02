using FinalYearProject.Shared.Interfaces;

namespace FinalYearProject.Shared.Models.UI.TopBar
{
    public class ChordInformation : IPositionedElement
    { 
        /// <summary>
        /// How far across the bar the chord starts (0-100) in %
        /// </summary>
        public double StartPercentage { get; set; }

        /// <summary>
        /// The Chord Name to display
        /// </summary>
        public string ChordName { get; set; } = string.Empty;

        //TODO: Extend this to include more chord information
    }
}
