using FinalYearProject.UI.Components.Models;
using FinalYearProject.UI.Components.Services;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements.TopBar
{
    public partial class BpmMarking(TabRepresentationSettingsService settingsService)
    {
        public TabRepresentationSettingsService SettingsService { get; } = settingsService;

        #region Parameters

        [Parameter, EditorRequired]
        public required BarDisplayInformation BarInformation { get; set; }

        /// <summary>
        /// The X Position of the BPM Marking
        /// </summary>
        [Parameter]
        public int XPosition { get; set; }

        /// <summary>
        /// The Y Position of the BPM Marking
        /// </summary>
        [Parameter]
        public int YPosition { get; set; }

        #endregion

        #region Settings
        private int _topPadding
            => SettingsService
            .TopBarDisplaySettings
            .TopPadding;

        private int _leftPadding
            => SettingsService
            .TopBarDisplaySettings
            .LeftPadding;

        private int _barNumberFontSize
            => SettingsService
            .TopBarDisplaySettings
            .BpmReadoutFontSize;

        #endregion

        /// <summary>
        /// Returns the X Position adjusted for Left Padding
        /// </summary>
        /// <returns></returns>
        private int GetAdjustedXPosition()
        {
            return XPosition + _leftPadding;
        }

        /// <summary>
        /// Returns the Y Position adjusted for Top Padding
        /// </summary>
        /// <returns></returns>
        private int GetAdjustedYPosition()
        {
            return YPosition + _topPadding;
        }
    }
}