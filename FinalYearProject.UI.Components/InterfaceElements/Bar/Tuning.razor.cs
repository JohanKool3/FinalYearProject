using FinalYearProject.UI.Components.Services;

namespace FinalYearProject.UI.Components.InterfaceElements.Bar
{
    public partial class Tuning
    {

        public Tuning(TabRepresentationSettingsService settingsService)
        {
            SettingsService = settingsService;
        }

        public TabRepresentationSettingsService SettingsService { get; }

        private int _height => SettingsService.GetBarHeight();

        //TODO: Get this from the settings service
        private int _width => 10;
    }
}