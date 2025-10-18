
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

        public void SetStringCount(int count)
        {
            if (count < 0 || count > 18)
                throw new ArgumentOutOfRangeException(nameof(count), "String count must be between 0 and 18.");
            StringCount = count;
        }
    }
}
