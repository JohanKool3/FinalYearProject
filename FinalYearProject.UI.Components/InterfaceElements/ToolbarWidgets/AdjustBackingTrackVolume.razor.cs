using FinalYearProject.Services.Audio.Windows.AudioBuses;
using FinalYearProject.Shared.Models;

namespace FinalYearProject.UI.Components.InterfaceElements.ToolbarWidgets
{
    public partial class AdjustBackingTrackVolume(UserSettings settings)
    {
        public UserSettings Settings { get; } = settings;
    }
}