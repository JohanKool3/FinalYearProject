using FinalYearProject.Services.Interfaces;
using FinalYearProject.Shared.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace FinalYearProject.UI.Components.InterfaceElements.ToolbarWidgets
{
    public partial class PlayButton(
        PlaybackService playbackService,
        IAudioService audioService) : ComponentBase
    {
        [Parameter]
        public Func<Task>? OnPlayAsync { get; set; } = null;

        /// <summary>
        /// Notify the parent component that a change has occurred.
        /// </summary>
        [Parameter, EditorRequired]
        public Func<Task> NotifyParentOfChange { get; set; } = null!;

        public PlaybackService PlaybackService { get; } = playbackService;
        public IAudioService AudioService { get; } = audioService;

        private async Task StartPlayAsync(MouseEventArgs args)
        {
            // Prevents playback being started while playback is active.
            if (PlaybackService.IsPlaying)
            {
                return;
            }

            await PlaybackService.StartPlaybackAsync();
            AudioService.RestartPlayback();
            await InvokeAsync(NotifyParentOfChange);
            
            if (OnPlayAsync is null)
            {
                return;
            }

            await OnPlayAsync.Invoke();
        }

        /// <summary>
        /// If it is playing, then the pause button should be enabled.
        /// </summary>
        /// <returns></returns>
        private string GetEnabled()
            => PlaybackService.IsPlaying switch
            {
                false => "enabled",
                true => "disabled",
            };
    }
}