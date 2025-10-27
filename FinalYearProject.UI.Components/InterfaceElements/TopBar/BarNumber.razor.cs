using FinalYearProject.UI.Components.Services;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements.TopBar
{
    public partial class BarNumber(TabRepresentationService representationService)
    {
        #region Parameters

        /// <summary>
        /// Value to be displayed as the Bar Number
        /// </summary>
        [Parameter]
        public int BarNumberValue { get; set; }

        /// <summary>
        /// The X Position of the Bar Number
        /// </summary>
        [Parameter]
        public int XPosition { get; set; }

        /// <summary>
        /// The Y Position of the Bar Number
        /// </summary>
        [Parameter]
        public int YPosition { get; set; }

        #endregion

        public TabRepresentationService RepresentationService { get; set; } = representationService;

        #region Settings

        private int _leftPadding =>
            RepresentationService
                .Settings
                .TopBar
                .LeftPadding;
        private int _barNumberFontSize =>
            RepresentationService
                .Settings
                .TopBar
                .BarNumberFontSize;

        #endregion


        private int GetAdjustedXPosition()
        {
            return XPosition + _leftPadding;
        }
    }
}