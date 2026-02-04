using FinalYearProject.Shared.Models.UI;
using FinalYearProject.UI.Components.Models.Settings.SubSettings;

namespace FinalYearProject.UI.Components.Models.Settings
{
    /// <summary>
    /// Holds settings related to the representation of the Tab UI
    /// </summary>
    public class RepresentationSettings
    {
        /// <summary>
        /// Holds the Tuning Scheme for this Tab Representation
        /// </summary>
        public TuningScheme TuningScheme { get; set; }
            = TuningScheme.SixStringStandard;

        /// <summary>
        /// The number of strings to display on the guitar
        /// </summary>
        public int StringCount
            => TuningScheme.StringTunings.Count;

        /// <summary>
        /// Whether to show bounding boxes for each component for debugging and
        /// design purposes
        /// </summary>
        public bool DebugMode { get; set; } = false;

        /// <summary>
        /// Settings related to the Strings and Notes display
        /// </summary>
        public NoteSettings Notes { get; private set; }
            = new()
            {
                TopPadding = 20,
                LeftPadding = 40,
                NoteSpacing = 20,
                StringSpacing = 15
            };


        /// <summary>
        /// The Settings that relate to the display of the PreBar section
        /// </summary>
        public PreBarSettings PreBar { get; private set; }
            = new()
            {
                TimeSignatureWidth = 20,
                TuningFontSize = 14,
                TuningWidth = 5
            };

        public TopBarSettings TopBar { get; private set; }
            = new()
            {
                Height = 70,
                Rows = 4,
                TopPadding = 15,
                LeftPadding = 5,
                BarNumberFontSize = 12,
                BpmReadoutFontSize = 10,
                ChordReadoutFontSize = 10
            };

        public BottomBarSettings BottomBar { get; private set; }
            = new()
            {
                Height = 60,
                TopPadding = 5
            };


        public PlaybackIndicatorSettings PlaybackIndicator { get; private set; }
            = new()
            {
                Height = 100,
                Width = 3,
                Color = "#FF0000"
            };
    }
}
