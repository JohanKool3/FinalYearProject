
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

        public TimeSignatureDisplaySettings TimeSignatureDisplaySettings { get; private set; }
            = new()
            {
                Width = 20
            };

        /// <summary>
        /// Sets the number of strings to display
        /// </summary>
        /// <param name="count"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void SetStringCount(int count)
        {
            if (count < 0 || count > 18)
                throw new ArgumentOutOfRangeException(nameof(count), "String count must be between 0 and 18.");
            StringCount = count;
        }

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
    }
}
