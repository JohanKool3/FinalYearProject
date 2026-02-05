using FinalYearProject.UI.Components.InterfaceElements.Recording;
using FinalYearProject.UI.Components.Services;

namespace FinalYearProject.UI.Components
{
    public partial class Toolbar(DisplayService displayService)
    {
        public AudioFileManager AudioFileManager { get; set; } = null!;

        protected override void OnInitialized()
        {
            DisplayService.OnUpdateCurrentPieceIdAsync = OnUpdateCurrentPieceIdAsync;
        }

        private Task OnUpdateCurrentPieceIdAsync(Guid guid)
        {
            AudioFileManager.SetId(guid);

            return InvokeAsync(StateHasChanged);
        }

        public DisplayService DisplayService { get; } = displayService;

        private Task PlaybackStateChanged()
            => InvokeAsync(StateHasChanged);
    }
}