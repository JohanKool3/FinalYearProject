using FinalYearProject.Shared.Models.TabRepresentation;
using FinalYearProject.Shared.Models.UI.Bar;
using FinalYearProject.Shared.Models.UI.TopBar;

namespace FinalYearProject.Shared.Models.UI
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
        /// Holds information about where a bar is
        /// in the tab as a whole.
        /// </summary>
        public BarPositionInTab PositionInTab { get; set; } =
            BarPositionInTab.Default;

        /// <summary>
        /// The BPM of this bar
        /// </summary>
        public int Bpm { get; set; } = 120;

        /// <summary>
        /// The Note Groups for this Bar
        /// </summary>
        public List<NoteGroupInformation> NoteGroups { get; set; } = [];

        /// <summary>
        /// The Chords for this bar
        /// </summary>
        public List<ChordInformation> Chords { get; set; } = [];
    }
}
