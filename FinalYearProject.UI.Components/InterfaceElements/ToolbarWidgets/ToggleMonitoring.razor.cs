using FinalYearProject.Services.Audio.Windows.AudioBuses;
using Microsoft.AspNetCore.Components.Web;

namespace FinalYearProject.UI.Components.InterfaceElements.ToolbarWidgets
{
    public partial class ToggleMonitoring(MainBus mainBus)
    {
        public MainBus MainBus { get; } = mainBus;

        private void ToggleMonitor(MouseEventArgs args)
            => MainBus.ToggleActive();

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