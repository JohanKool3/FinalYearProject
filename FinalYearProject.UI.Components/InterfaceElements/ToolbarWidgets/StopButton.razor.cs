using FinalYearProject.UI.Components.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace FinalYearProject.UI.Components.InterfaceElements.ToolbarWidgets
{
    public partial class StopButton(PlaybackService playbackService) : ComponentBase
    {
        /// <summary>
        /// Action that is invoked when the pause button is clicked
        /// </summary>
        [Parameter]
        public Func<Task>? OnPauseAsync { get; set; } = null;

        /// <summary>
        /// Notify the parent component that a change has occurred.
        /// </summary>
        [Parameter, EditorRequired]
        public Func<Task> NotifyParentOfChange { get; set; } = null!;

        public PlaybackService PlaybackService { get; set; } = playbackService;

        private async Task StopPlayAsync(MouseEventArgs args)
        {
            // Inform the service that the pause button was clicked
            await PlaybackService.ResetPlaybackAsync();
            await InvokeAsync(NotifyParentOfChange);

            if (OnPauseAsync is null)
            {
                return;
            }

            await OnPauseAsync.Invoke();
        }

        /// <summary>
        /// If it is playing, then the pause button should be enabled.
        /// </summary>
        /// <returns></returns>
        private bool GetStatus() 
            => !PlaybackService.IsPlaying;
    }
}