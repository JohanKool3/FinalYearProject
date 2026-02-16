using FinalYearProject.Services.Audio.Windows.AudioBuses;

namespace FinalYearProject.UI.Components.InterfaceElements.ToolbarWidgets
{
    public partial class AdjustBackingTrackVolume(BackingTrackBus backingTrackBus)
    {
        public BackingTrackBus BackingTrackBus { get; } = backingTrackBus;
    }
}