using FinalYearProject.UI.Components.Services;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements.TopBar
{
    public partial class BarNumber(TabRepresentationSettingsService settingsService)
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

        public TabRepresentationSettingsService SettingsService { get; set; } = settingsService;

        #region Settings

        private int _leftPadding =>
            SettingsService
            .TopBarDisplaySettings
            .LeftPadding;

        private int _topPadding =>
            SettingsService
            .TopBarDisplaySettings
            .TopPadding;


        private int _barNumberFontSize =>
            SettingsService
            .TopBarDisplaySettings
            .BarNumberFontSize;

        #endregion


        private int GetAdjustedXPosition()
        {
            return XPosition + _leftPadding;
        }

        private int GetAdjustedYPosition()
        {
            return YPosition + _topPadding;
        }
    }
}