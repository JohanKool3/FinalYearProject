using FinalYearProject.Services.Audio.Windows.AudioBuses;

namespace FinalYearProject.UI.Components.InterfaceElements.ToolbarWidgets
{
    public partial class AdjustUserInputVolume(UserBus userBus)
    {
        public UserBus UserBus { get; } = userBus;

    }
}