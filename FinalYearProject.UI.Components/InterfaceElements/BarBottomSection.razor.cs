using FinalYearProject.UI.Components.Models;
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

        /// <summary>
        /// Information to be shown in the Bar Bottom Section
        /// </summary>
        [Parameter, EditorRequired]
        public BarDisplayInformation BarInformation { get; set; }

        #endregion

        #region Settings

        private int _height => SettingsService.BottomBarDisplaySettings.Height;

        private bool _debugMode => SettingsService.DebugMode;
        #endregion


    }
}