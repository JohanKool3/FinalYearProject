using FinalYearProject.Services.Audio.Windows.AudioBuses;
using Microsoft.AspNetCore.Components.Web;

namespace FinalYearProject.UI.Components.InterfaceElements.ToolbarWidgets
{
    public partial class ToggleUserInputButton(UserBus userBus)
    {
        public UserBus UserBus { get; } = userBus;


        private string GetEnabled()
            => UserBus.IsEnabled switch
            {
                true => "enabled",
                false => "disabled",
            };
        private void ToggleUserTrack(MouseEventArgs args)
            => UserBus.ToggleActive();
    }
}