using FinalYearProject.Shared.Services;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements.ToolbarWidgets
{
    public partial class RecordButton(PlaybackService playbackService)
    {
        /// <summary>
        /// Notify the parent component that a change has occurred.
        /// </summary>
        [Parameter, EditorRequired]
        public Func<Task> NotifyParentOfChange { get; set; } = null!;

        public PlaybackService PlaybackService { get; } = playbackService;


        private Task ToggleRecordAsync()
        {
            if (PlaybackService is null)
            {
                return Task.CompletedTask;
            }

            // Update the playback service to indicate recording is enabled
            PlaybackService.ToggleRecording();
            return InvokeAsync(NotifyParentOfChange);
        }


        /// <summary>
        /// If it is playing, then the pause button should be enabled.
        /// </summary>
        /// <returns></returns>
        private string GetEnabled()
            => PlaybackService.RecordingEnabled
             switch
            {
                true => "enabled",
                false => "disabled",
            };
    }
}