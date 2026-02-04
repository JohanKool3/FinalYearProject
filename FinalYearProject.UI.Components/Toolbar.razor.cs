using FinalYearProject.UI.Components.Services;

namespace FinalYearProject.UI.Components
{
    public partial class Toolbar(DisplayService displayService)
    {
        public DisplayService DisplayService { get; } = displayService;

        private Task PlaybackStateChanged()
            => InvokeAsync(StateHasChanged);
    }
}