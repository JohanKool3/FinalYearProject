
using FinalYearProject.UI.Components.Models;

namespace FinalYearProject.UI.Components.Services
{
    /// <summary>
    /// Holds settings related to the display
    /// </summary>
    public class TabRepresentationSettingsService
    {
        /// <summary>
        /// The number of strings to display on the guitar
        /// </summary>
        public int StringCount { get; private set; } = 6;

        public NoteDisplaySettings NoteDisplaySettings { get; private set; }
            = new NoteDisplaySettings
            {
                TopPadding = 20,
                LeftPadding = 20,
                NoteSpacing = 40,
                StringSpacing = 15
            };

        public void SetStringCount(int count)
        {
            if (count < 0 || count > 18)
                throw new ArgumentOutOfRangeException(nameof(count), "String count must be between 0 and 18.");
            StringCount = count;
        }

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

        public int GetBarHeight()
            => NoteDisplaySettings.TopPadding +
               (StringCount * NoteDisplaySettings.StringSpacing);
    }
}
