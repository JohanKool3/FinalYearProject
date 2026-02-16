using FinalYearProject.Services.Audio.Windows.AudioBuses;

namespace FinalYearProject.UI.Components.InterfaceElements.ToolbarWidgets
{
    public partial class AdjustMetronomeVolume(MetronomeBus metronomeBus)
    {
        public MetronomeBus MetronomeBus { get; } = metronomeBus;
    }
}