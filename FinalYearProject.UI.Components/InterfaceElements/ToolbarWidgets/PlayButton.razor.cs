using FinalYearProject.UI.Components.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace FinalYearProject.UI.Components.InterfaceElements.ToolbarWidgets
{
    public partial class PlayButton(PlaybackService playbackService) : ComponentBase
    {
        [Parameter]
        public Func<Task>? OnPlayAsync { get; set; } = null;

        /// <summary>
        /// Notify the parent component that a change has occurred.
        /// </summary>
        [Parameter, EditorRequired]
        public Func<Task> NotifyParentOfChange { get; set; } = null!;

        public PlaybackService PlaybackService { get; } = playbackService;

        private async Task StartPlayAsync(MouseEventArgs args)
        {
            await PlaybackService.StartPlaybackAsync();
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