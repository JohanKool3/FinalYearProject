using FinalYearProject.Services.Interfaces;
using FinalYearProject.Shared.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace FinalYearProject.UI.Components.InterfaceElements.ToolbarWidgets
{
    public partial class PauseButton(PlaybackService playbackService,
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

        private async Task PausePlayAsync(MouseEventArgs args)
        {
            // Prevents stopping a stopped playback state
            if (!PlaybackService.IsPlaying)
            {
                return;
            }

            // Inform the service and listeners that the pause button was clicked
            await PlaybackService.StopPlaybackAsync();


            await InvokeAsync(NotifyParentOfChange);
            AudioService.RestartPlayback();

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
            => PlaybackService.IsPlaying switch
            {
                true => "enabled",
                false => "disabled",
            };
    }
}