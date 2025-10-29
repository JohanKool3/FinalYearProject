using FinalYearProject.Shared.Models.UI;
using FinalYearProject.UI.Components.Services;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements
{
    public partial class BarTopSection(TabRepresentationService representationService)
    {
        public TabRepresentationService RepresentationService { get; }
            = representationService;

        #region Parameters

        /// <summary>
        /// The Number of the bar to display.
        /// </summary>
        [Parameter]
        public int BarNumber { get; set; } = 0;

        /// <summary>
        /// The Width of the Top Bar
        /// </summary>
        [Parameter]
        public int Width { get; set; } = 0;

        /// <summary>
        /// Information about the bar
        /// </summary>
        [Parameter, EditorRequired]
        public required BarInformation BarInformation { get; set; }

        /// <summary>
        /// Whether to show the time Bpm Marking
        /// </summary>
        [Parameter]
        public bool ShowBpmMarking { get; set; } = false;


        /// <summary>
        /// How much to offset to be in line with the notes on the X Axis
        /// </summary>
        [Parameter]
        public int XOffset { get; set; } = 0;

        #endregion

        #region Settings

        private int _height
            => RepresentationService
                .Settings
                .TopBar
                .Height;

        private int _barNumberFontSize
            => RepresentationService
                .Settings
                .TopBar
                .BarNumberFontSize;

        private bool _debugMode
            => RepresentationService
                .Settings
                .DebugMode;

        #endregion

        /// <summary>
        /// Returns the Y Position for a given row number
        /// </summary>
        /// <param name="rowNumber"></param>
        /// <returns></returns>
        private int GetYPosition(int rowNumber)
        {
            // Divide height by row amount
            var rowAmount = RepresentationService
                .Settings
                .TopBar
                .Rows;

            // Need to ensure row number is valid
            if (rowNumber < 0 || rowNumber > rowAmount - 1)
            {
                throw new ArgumentOutOfRangeException(nameof(rowNumber), "Row number is out of range.");
            }

            // Calculate height of each row
            var rowHeight = _height / rowAmount;

            return rowHeight * rowNumber;
        }
    }
}