using FinalYearProject.Shared.Services;
using FinalYearProject.UI.Components.Enums;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements.ToolbarWidgets
{
    public partial class ToolbarWidgetBase(PlaybackService playbackService) : IDisposable
    {
        [Parameter, EditorRequired]
        public required RenderFragment ChildContent { get; set; }

        [Parameter]
        public WidgetWidth WidgetWidth { get; set; } = WidgetWidth.Single;


        protected override void OnInitialized()
        {
            PlaybackService.RegisterOnStartPlaybackEvent(UpdateState);
            PlaybackService.RegisterOnStopPlaybackEvent(UpdateState);
        }


        /// <summary>
        /// Tooltip Message for this Widget
        /// </summary>
        [Parameter]
        public string? ToolTipMessage { get; set; }
        
        public PlaybackService PlaybackService { get; } = playbackService;

        private Task UpdateState()
            => InvokeAsync(StateHasChanged);

        private string GetSizeClass()
            =>
              WidgetWidth switch
              {
                  WidgetWidth.Single => "normal",
                  WidgetWidth.Double => "double",
                  WidgetWidth.Triple => "triple",
                  _ => "normal"
              };

        public void Dispose()
        {
            PlaybackService.UnregisterOnStartPlaybackEvent(UpdateState);
            PlaybackService.UnregisterOnStopPlaybackEvent(UpdateState);
        }
    }
}