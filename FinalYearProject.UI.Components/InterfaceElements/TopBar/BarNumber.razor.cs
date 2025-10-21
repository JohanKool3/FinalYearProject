using FinalYearProject.UI.Components.Services;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements.TopBar
{
    public partial class BarNumber(TabRepresentationSettingsService settingsService)
    {
        #region Parameters
        
        [Parameter]
        public int BarNumberValue { get; set; }

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
    }
}