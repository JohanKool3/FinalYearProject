using FinalYearProject.UI.Components.Models;
using FinalYearProject.UI.Components.Models.InterfaceElements.Bar;
using FinalYearProject.UI.Components.Models.Settings;

namespace FinalYearProject.UI.Components.Services
{
    /// <summary>
    /// Holds settings related to the display
    /// </summary>
    public class TabRepresentationSettingsService
    {
        /// <summary>
        /// Holds the Tuning Scheme for this Tab Representation
        /// </summary>
        public TuningScheme TuningScheme { get; private set; }
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
        public bool DebugMode { get; set; } = true;

        /// <summary>
        /// Settings related to the Strings and Notes display
        /// </summary>
        public NoteSettings NoteDisplaySettings { get; private set; }
            = new()
            {
                TopPadding = 20,
                LeftPadding = 40,
                NoteSpacing = 40,
                StringSpacing = 15
            };


        /// <summary>
        /// The Settings that relate to the display of the PreBar section
        /// </summary>
        public PreBarSettings PreBarDisplaySettings { get; private set; }
            = new()
            {
                TimeSignatureWidth = 20,
                TuningFontSize = 14,
                TuningWidth = 5
            };

        public TopBarSettings TopBarDisplaySettings { get; private set; }
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

        public BottomBarSettings BottomBarDisplaySettings { get; private set; }
            = new()
            {
                Height = 60,
                TopPadding = 5
            };

        /// <summary>
        /// Returns the dynamic width of a bar based on the notes it contains
        /// </summary>
        /// <param name="noteGroups"></param>
        /// <returns></returns>
        public int GetBarWidth(List<NoteGroupDisplayInformation> noteGroups)
        {
            // Get all the notes in each note Group
            var notes = noteGroups
                .SelectMany(x => x.Notes);

            // Calculate how many different start positions there are
            var distinctPositions = notes
                .Select(n => n.BarPercentage)
                .Distinct().Count();

            var leftPadding = NoteDisplaySettings.LeftPadding;
            
            // Multiply by 2 for start and  the end padding
            return 2 * leftPadding + (distinctPositions * NoteDisplaySettings.NoteSpacing);
        }

        /// <summary>
        /// Returns how tall the bar should be based on string count and Padding
        /// </summary>
        /// <returns></returns>
        public int GetBarHeight()
            => NoteDisplaySettings.TopPadding +
               (StringCount * NoteDisplaySettings.StringSpacing);

        /// <summary>
        /// Get the height of both the bar and the top bar
        /// </summary>
        /// <returns></returns>
        public int GetTotalBarHeight()
            => GetBarHeight() 
            + TopBarDisplaySettings.Height

            // Account for the Bottom Bar too
            + BottomBarDisplaySettings.Height
            + BottomBarDisplaySettings.TopPadding;

        public void LoadNewTuningScheme(TuningScheme newScheme)
        {
            // TODO: Add Validation to ensure the scheme is good
            TuningScheme = newScheme;
        }
    }
}
