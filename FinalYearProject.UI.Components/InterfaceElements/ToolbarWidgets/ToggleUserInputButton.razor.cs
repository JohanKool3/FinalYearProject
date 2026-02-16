using FinalYearProject.Services.Audio.Windows.AudioBuses;
using FinalYearProject.Services.Interfaces;
using Microsoft.AspNetCore.Components.Web;

namespace FinalYearProject.UI.Components.InterfaceElements.ToolbarWidgets
{
    public partial class ToggleUserInputButton(UserBus userBus,
        IAudioService audioService)
    {
        public UserBus UserBus { get; } = userBus;

        public IAudioService AudioService { get; } = audioService;

        private string GetEnabled()
            => UserBus.IsEnabled switch
            {
                true => "enabled",
                false => "disabled",
            };
        private void ToggleUserTrack(MouseEventArgs args)
        {
            AudioService.StopPlayback();
            UserBus.ToggleActive();
            AudioService.StartPlayback();
        }
    }
}