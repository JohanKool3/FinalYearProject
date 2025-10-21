using FinalYearProject.UI.Components.Models;
using FinalYearProject.UI.Components.Services;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements
{
    public partial class TabTopBar(TabRepresentationSettingsService settingsService)
    {
        public TabRepresentationSettingsService SettingsService { get; }
            = settingsService;

        #region Parameters

        /// <summary>
        /// The Number of the bar to display.
        /// </summary>
        [Parameter]
        public int BarNumber { get; set; } = 0;

        /// <summary>
        /// Information about the bar
        /// </summary>
        [Parameter, EditorRequired]
        public required BarDisplayInformation BarInformation { get; set; }

        /// <summary>
        /// Whether to show the time Bpm Marking
        /// </summary>
        [Parameter]
        public bool ShowBpmMarking { get; set; } = false;

        #endregion

        /// <summary>
        /// Top padding is half that of the notes area to indicate,
        /// seperation
        /// </summary>
        private int _topPadding =>
            SettingsService
            .TopBarDisplaySettings
            .TopPadding;

        /// <summary>
        /// Left padding is a quarter that of the notes area to indicate,
        /// seperation
        /// </summary>
        private int _leftPadding =>
            SettingsService
            .TopBarDisplaySettings
            .LeftPadding;

        /// <summary>
        /// The font size of the Bar Number
        /// </summary>
        private int _barNumberFontSize =>
            SettingsService
            .TopBarDisplaySettings
            .BarNumberFontSize;

        /// <summary>
        /// The font size of the BPM readout
        /// </summary>
        private int _bpmReadoutFontSize =>
            SettingsService
            .TopBarDisplaySettings
            .BpmReadoutFontSize;

        private int _width => SettingsService
            .GetBarWidth(BarInformation.Notes);
    }
}