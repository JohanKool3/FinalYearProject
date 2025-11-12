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
            PlaybackService.StartPlayback();
            await InvokeAsync(NotifyParentOfChange);

            if (OnPlayAsync is null)
            {
                return;
            }

            await OnPlayAsync.Invoke();
        }

        /// <summary>
        /// Can only play if it is not currently playing.
        /// </summary>
        /// <returns></returns>
        private bool GetStatus() 
            => PlaybackService.IsPlaying;
    }
}