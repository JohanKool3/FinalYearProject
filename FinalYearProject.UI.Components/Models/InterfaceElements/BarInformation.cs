using FinalYearProject.Shared.Models.TabRepresentation;
using FinalYearProject.UI.Components.Models.InterfaceElements.Bar;
using FinalYearProject.UI.Components.Models.InterfaceElements.TopBar;

namespace FinalYearProject.UI.Components.Models.InterfaceElements
{
    /// <summary>
    /// Holds information about a single bar in the tab
    /// </summary>
    public class BarInformation
    {
        /// <summary>
        /// The time signature of this bar
        /// </summary>
        public TimeSignature TimeSignature { get; set; } 
            = TimeSignature.Default;

        /// <summary>
        /// The BPM of this bar
        /// </summary>
        public int Bpm { get; set; } = 120;

        /// <summary>
        /// The Note Groups for this Bar
        /// </summary>
        public List<NoteGroupDisplayInformation> NoteGroups { get; set; } = [];

        /// <summary>
        /// The Chords for this bar
        /// </summary>
        public List<ChordInformation> Chords { get; set; } = [];
    }
}
