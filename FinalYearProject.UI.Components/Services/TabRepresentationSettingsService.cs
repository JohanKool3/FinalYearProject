using FinalYearProject.UI.Components.Models;

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
        /// Settings related to the Strings and Notes display
        /// </summary>
        public NoteDisplaySettings NoteDisplaySettings { get; private set; }
            = new()
            {
                TopPadding = 20,
                LeftPadding = 20,
                NoteSpacing = 40,
                StringSpacing = 15
            };


        /// <summary>
        /// The Settings that relate to the display of the PreBar section
        /// </summary>
        public PreBarDisplaySettings PreBarDisplaySettings { get; private set; }
            = new()
            {
                TimeSignatureWidth = 20,
                TuningFontSize = 14,
                TuningWidth = 5
            };

        /// <summary>
        /// Returns the dynamic width of a bar based on the notes it contains
        /// </summary>
        /// <param name="notes"></param>
        /// <returns></returns>
        public int GetBarWidth(List<NoteDisplayInformation> notes)
        {
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

        public void LoadNewTuningScheme(TuningScheme newScheme)
        {
            // TODO: Add Validation to ensure the scheme is good
            TuningScheme = newScheme;
        }
    }
}
