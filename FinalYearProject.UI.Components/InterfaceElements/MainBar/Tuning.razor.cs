using FinalYearProject.Shared.Models.UI;
using FinalYearProject.UI.Components.Helpers;
using FinalYearProject.UI.Components.Models.Settings;
using FinalYearProject.UI.Components.Services;

namespace FinalYearProject.UI.Components.InterfaceElements.MainBar
{

    public partial class Tuning(SettingsService representationService)
    {
        public RepresentationSettings Settings { get; } = representationService.Settings;

        #region Fields Loaded from Settings

        /// <summary>
        /// The Height of the Tuning Section
        /// </summary>
        private int _height 
            => BarDimensionsHelper.GetBarHeight(Settings);

        /// <summary>
        /// How many strings need to have tuning displayed
        /// </summary>
        private int _stringAmount
            => Settings
                .StringCount;

        /// <summary>
        /// Space to leave at the top of the strings
        /// </summary>
        private int _topPadding
            => Settings
                .Notes
                .TopPadding;

        /// <summary>
        /// Space between each string
        /// </summary>
        private int _stringSpacing
            => (_height - _topPadding) / _stringAmount;

        /// <summary>
        /// Total space before the time signature
        /// </summary>
        private int _width
            => Settings
                .PreBar
                .TimeSignatureWidth;

        /// <summary>
        /// How large each character is
        /// </summary>
        private int _fontSize
            => Settings
                .PreBar
                .TuningFontSize;

        /// <summary>
        /// Gets the Tuning used for the current Tab Representation
        /// </summary>
        private TuningScheme _tuningScheme
            => Settings
                .TuningScheme;

        /// <summary>
        /// How tall the Top Bar is
        /// </summary>
        private int _topBarHeight
            => Settings
                .TopBar
                .Height;

        private int _totalBarHeight
            => BarDimensionsHelper.GetTotalBarHeight(Settings);

        #endregion

        /// <summary>
        /// Converts string number to 0 indexed string index
        /// </summary>
        /// <param name="stringNumber"></param>
        /// <returns></returns>
        private int GetAdjustedYPosition(int stringNumber)
        {
            var stringIndex = stringNumber - 1;

            return _topPadding + stringIndex * _stringSpacing;
        }

        /// <summary>
        /// Attempts to get the string tuning for the given string number
        /// </summary>
        /// <param name="stringNumber"></param>
        /// <returns></returns>
        /// <remarks>
        /// If it succeeds, returns a string representing the tuning. If it fails, returns "-"
        /// </remarks>
        private string GetStringTuning(int stringNumber)
        {
            // Check if the string number is valid
            if (!_tuningScheme.StringTunings.TryGetValue(stringNumber, out string? value))
            {
                // Indicated Unknown Tuning
                return "-";
            }

            return value;
        }
    }
}