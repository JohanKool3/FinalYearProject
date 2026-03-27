using FinalYearProject.Services.Interfaces;
using FinalYearProject.UI.Components.Services.Audio.Windows.AudioBuses;
using Microsoft.AspNetCore.Components.Web;

namespace FinalYearProject.UI.Components.InterfaceElements.ToolbarWidgets
{
    public partial class ToggleMonitoring(MainBus mainBus,
        IAudioService audioService)
    {
        public MainBus MainBus { get; } = mainBus;
        public IAudioService AudioService { get; } = audioService;

        private void ToggleMonitor(MouseEventArgs args)
        {
            AudioService.StopPlayback();
            MainBus.ToggleActive();
            AudioService.StartPlayback();
        }

        private string GetCurrentImage()
            => MainBus.IsEnabled switch
            {
                true => "monitor-on.svg",
                false => "monitor-off.svg",
            };

        private string GetEnabled()
            => MainBus.IsEnabled switch
            {
                true => "enabled",
                false => "disabled",
            };
    }
}