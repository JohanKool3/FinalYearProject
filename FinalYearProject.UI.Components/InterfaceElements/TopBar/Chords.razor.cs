using FinalYearProject.UI.Components.Models;
using FinalYearProject.UI.Components.Services;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements.TopBar
{
    public partial class Chords(TabRepresentationSettingsService settingsService)
    {
        #region Parameters

        /// <summary>
        /// The Information about the Bar to display
        /// </summary>
        [Parameter, EditorRequired]
        public required BarDisplayInformation BarInformation { get; set; }

        /// <summary>
        /// Where to start the Chord display on the X Axis
        /// </summary>
        [Parameter]
        public int XPosition { get; set; }

        /// <summary>
        /// Where to start the Chord display on the Y Axis
        /// </summary>
        [Parameter]
        public int YPosition { get; set; }

        /// <summary>
        /// Width of the Top Bar
        /// </summary>
        [Parameter]
        public int Width { get; set; }

        /// <summary>
        /// How much to offset on the X Axis (for time signature and tuning)
        /// </summary>
        [Parameter, EditorRequired]
        public int XOffset { get; set; } = 0;

        /// <summary>
        /// The Row Number the chords are being displayed on
        /// </summary>
        [Parameter, EditorRequired]
        public int RowNumber { get; set; } = 0;

        #endregion

        public TabRepresentationSettingsService SettingsService { get; }
            = settingsService;

        private int GetHeight()
        {
            var height = SettingsService
            .TopBarDisplaySettings
            .Height;

            var rowAmount = SettingsService.TopBarDisplaySettings.Rows;

            return (height / rowAmount);
        }

        private int GetWidth()
            => Width - XOffset;
        
    }
}