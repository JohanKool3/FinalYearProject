using System;
namespace FinalYearProject.UI.Components.Models.Settings.SubSettings
{
    /// <summary>
    /// Holds settings related to the rendering of the above
    /// bar information in the UI.
    /// </summary>
    public class TopBarSettings
    {
        /// <summary>
        /// The height of the top bar in pixels.
        /// </summary>
        public int Height { get; set; } = 50;

        /// <summary>
        /// How many rows of information to that can be displayed
        /// in the top bar.
        /// </summary>
        public int Rows { get; set; } = 3;

        /// <summary>
        /// How much space to leave above the top bar content.
        /// </summary>
        public int TopPadding { get; internal set; }

        /// <summary>
        /// How much space to leave to the left of the top bar content.
        /// </summary>
        public int LeftPadding { get; internal set; }

        /// <summary>
        /// The Size of the font to use for the Bar Number display.
        /// </summary>
        public int BarNumberFontSize { get; set; } = 14;

        /// <summary>
        /// The Size of the font to use for the BPM Readout display.
        /// </summary>
        public int BpmReadoutFontSize { get; set; } = 14;

        /// <summary>
        /// How large the font should be for the Chord Readout display.
        /// </summary>
        public int ChordReadoutFontSize { get; set; } = 10;
    }
}
