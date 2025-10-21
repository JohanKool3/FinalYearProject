
using FinalYearProject.Shared.Models.TabRepresentation;

namespace FinalYearProject.UI.Components.Models
{
    /// <summary>
    /// Holds information about a single bar in the tab
    /// </summary>
    public class BarDisplayInformation
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
        /// The Notes in this bar
        /// </summary>
        public List<NoteDisplayInformation> Notes { get; set; } = [];

        /// <summary>
        /// The Chords for this bar
        /// </summary>
        public List<ChordDisplayInformation> Chords { get; set; } = [];
    }
}
