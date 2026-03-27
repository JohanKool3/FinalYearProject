using FinalYearProject.Services.Interfaces;
using FinalYearProject.UI.Components.Services.Audio.Windows.AudioBuses;
using Microsoft.AspNetCore.Components.Web;

namespace FinalYearProject.UI.Components.InterfaceElements.ToolbarWidgets
{
    public partial class ToggleMetronomeButton(MetronomeBus metronomeBus,
        IAudioService audioService)
    {
        public MetronomeBus MetronomeBus { get; } = metronomeBus;

        public IAudioService AudioService { get; } = audioService;

        private string GetEnabled()
            => MetronomeBus.IsEnabled switch
            {
                true => "enabled",
                false => "disabled",
            };
        private void ToggleMetronomeTrack(MouseEventArgs args)
        {
            MetronomeBus.ToggleActive();
            AudioService.RestartPlayback();
        }
    }
}