using FinalYearProject.UI.Components.Services;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements.Bar
{
    public partial class TopBarInformation(TabRepresentationSettingsService settingsService)
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
        /// Whether to show the time Bpm Marking
        /// </summary>
        [Parameter]
        public bool ShowBpmMarking { get; set; } = false;

        #endregion

        /// <summary>
        /// Top padding is half that of the notes area to indicate,
        /// seperation
        /// </summary>
        private int _topPadding
            => SettingsService.NoteDisplaySettings.TopPadding / 2;

        /// <summary>
        /// Left padding is a quarter that of the notes area to indicate,
        /// seperation
        /// </summary>
        private int _leftPadding
            => SettingsService.NoteDisplaySettings.LeftPadding / 4;

        /// <summary>
        /// Bar number is two thirds the size of the string spacing
        /// </summary>
        private int _barNumberFontSize
            => 2* SettingsService.NoteDisplaySettings.StringSpacing / 3;
    }
}