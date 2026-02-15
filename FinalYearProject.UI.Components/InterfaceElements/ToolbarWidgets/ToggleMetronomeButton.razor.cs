using FinalYearProject.Services.Audio.Windows.AudioBuses;
using Microsoft.AspNetCore.Components.Web;

namespace FinalYearProject.UI.Components.InterfaceElements.ToolbarWidgets
{
    public partial class ToggleMetronomeButton(MetronomeBus metronomeBus)
    {
        public MetronomeBus MetronomeBus { get; } = metronomeBus;

        private string GetEnabled()
            => MetronomeBus.IsEnabled switch
            {
                true => "enabled",
                false => "disabled",
            };
        private void ToggleMetronomeTrack(MouseEventArgs args)
            => MetronomeBus.ToggleActive();
    }
}