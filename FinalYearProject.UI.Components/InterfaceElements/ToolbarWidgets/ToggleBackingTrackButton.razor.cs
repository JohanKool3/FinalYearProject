using FinalYearProject.Services.Audio.Windows.AudioBuses;
using FinalYearProject.UI.Components.Services;
using Microsoft.AspNetCore.Components.Web;

namespace FinalYearProject.UI.Components.InterfaceElements.ToolbarWidgets
{
    public partial class ToggleBackingTrackButton(BackingTrackBus backingTrackBus)
    {
        public BackingTrackBus BackingTrackBus { get; } = backingTrackBus;

        private string GetEnabled()
            => BackingTrackBus.IsEnabled switch
            {
                true => "enabled",
                false => "disabled",
            };
        private void ToggleBackingTrack(MouseEventArgs args)
            => BackingTrackBus.ToggleActive();
    }
}