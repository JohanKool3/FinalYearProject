using FinalYearProject.UI.Components.InterfaceElements.Recording;
using FinalYearProject.UI.Components.Services;

namespace FinalYearProject.UI.Components
{
    public partial class Toolbar(DisplayService displayService)
    {
        private Task PlaybackStateChanged()
            => InvokeAsync(StateHasChanged);
    }
}