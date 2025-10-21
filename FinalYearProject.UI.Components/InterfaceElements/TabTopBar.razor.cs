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
        /// The Width of the Top Bar
        /// </summary>
        [Parameter]
        public int Width { get; set; } = 0;

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

        private int _height 
            => SettingsService
            .TopBarDisplaySettings
            .Height;
    }
}