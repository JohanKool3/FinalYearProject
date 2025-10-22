using FinalYearProject.UI.Components.Services;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements.BottomBar.NoteDuration
{
    public partial class GraceNoteDuration(TabRepresentationSettingsService settingsService)
    {
        #region Parameters

        /// <summary>
        /// Where this note duration should be drawn on the X Axis
        /// </summary>
        [Parameter]
        public int XPosition { get; set; }
        #endregion

        public TabRepresentationSettingsService SettingsService { get; }
            = settingsService;

        #region Settings
        private int _height
            => SettingsService.BottomBarDisplaySettings.Height;

        private int _noteSpacing
            => SettingsService.NoteDisplaySettings.NoteSpacing;

        #endregion

        private int _noteHeight
            =>  _height / 3;

        private int GetWidth()
            => XPosition + _noteSpacing / 9;
    }
}