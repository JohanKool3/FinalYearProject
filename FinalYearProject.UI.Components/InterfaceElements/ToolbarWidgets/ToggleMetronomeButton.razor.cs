using FinalYearProject.Services.Audio.Windows.AudioBuses;
using FinalYearProject.Services.Interfaces;
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
            AudioService.StopPlayback();
            MetronomeBus.ToggleActive();
            AudioService.StartPlayback();
        }
    }
}