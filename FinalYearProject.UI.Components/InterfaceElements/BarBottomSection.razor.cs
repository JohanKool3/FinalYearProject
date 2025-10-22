using FinalYearProject.UI.Components.Services;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements
{
    public partial class BarBottomSection(TabRepresentationSettingsService settingsService)
    {
        public TabRepresentationSettingsService SettingsService { get; } 
            = settingsService;

        #region Parameters

        /// <summary>
        /// The Width of the Bottom Section
        /// </summary>
        [Parameter, EditorRequired]
        public int Width { get; set; }
        #endregion 

        #region Settings
        
        private int _height => SettingsService.BottomBarDisplaySettings.Height;

        private bool _debugMode => SettingsService.DebugMode;
        #endregion


    }
}