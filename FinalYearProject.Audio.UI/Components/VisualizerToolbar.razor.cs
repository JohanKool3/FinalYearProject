using Microsoft.AspNetCore.Components;

namespace FinalYearProject.Audio.UI.Components
{
    public partial class VisualizerToolbar
    {

        [Parameter]
        public EventCallback OnStart { get; set; }

        [Parameter]
        public EventCallback OnStop { get; set; }

        [Parameter]
        public EventCallback OnReset { get; set; }
    }
}