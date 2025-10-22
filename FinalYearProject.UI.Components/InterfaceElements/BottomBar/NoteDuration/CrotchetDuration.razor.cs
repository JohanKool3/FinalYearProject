using FinalYearProject.UI.Components.Services;

namespace FinalYearProject.UI.Components.InterfaceElements.BottomBar.NoteDuration
{
    public partial class CrotchetDuration(TabRepresentationSettingsService settingsService)
    {
        public TabRepresentationSettingsService SettingsService { get; }
            = settingsService;

        #region Settings
        private int _height 
            => SettingsService.BottomBarDisplaySettings.Height;

        private int _noteSpacing 
            => SettingsService.NoteDisplaySettings.NoteSpacing;

        #endregion

        private int _noteHeight
            => 2 * _height / 3;
    }
}