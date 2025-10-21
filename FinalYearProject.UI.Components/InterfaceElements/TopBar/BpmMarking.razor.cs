using FinalYearProject.UI.Components.Models;
using FinalYearProject.UI.Components.Services;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements.TopBar
{
    public partial class BpmMarking(TabRepresentationSettingsService settingsService)
    {
        public TabRepresentationSettingsService SettingsService { get; } = settingsService;

        [Parameter, EditorRequired]
        public required BarDisplayInformation BarInformation { get; set; }

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
    }
}