using FinalYearProject.Services.Interfaces;
using FinalYearProject.Shared.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace FinalYearProject.UI.Components.InterfaceElements.ToolbarWidgets
{
    public partial class StopButton(PlaybackService playbackService,
        IAudioService audioService) : ComponentBase
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
        
        public IAudioService AudioService { get; } = audioService;

        private async Task StopPlayAsync(MouseEventArgs args)
        {
            // Prevents stopping a stopped playback state
            if (!PlaybackService.IsPlaying)
            {
                return;
            }

            // Inform the service that the pause button was clicked
            await PlaybackService.ResetPlaybackAsync();
            AudioService.RestartPlayback();
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
        private string GetEnabled()
            => PlaybackService.IsPlaying
             switch
            {
                true => "enabled",
                false => "disabled",
            };
    }
}