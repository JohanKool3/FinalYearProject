using FinalYearProject.UI.Components.Services;

namespace FinalYearProject.UI.Components.InterfaceElements.Bar
{
    public partial class Tuning
    {

        public Tuning(TabRepresentationSettingsService settingsService)
        {
            SettingsService = settingsService;
        }

        public TabRepresentationSettingsService SettingsService { get; }

        private int _height => SettingsService.GetBarHeight();

        private int _stringAmount => SettingsService.StringCount;

        /// <summary>
        /// Space to leave at the top of the strings
        /// </summary>
        private int _topPadding
            => SettingsService.NoteDisplaySettings.TopPadding;

        /// <summary>
        /// Space between each string
        /// </summary>
        private int _stringSpacing
            => (_height - _topPadding) / _stringAmount;

        /// <summary>
        /// Total space before the time signature
        /// </summary>
        private int _width
            => SettingsService.PreBarDisplaySettings.TimeSignatureWidth;

        /// <summary>
        /// How large each character is
        /// </summary>
        private int _fontSize
            => SettingsService.PreBarDisplaySettings.TuningFontSize;
    }
}