using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements
{
    public partial class TooltippedWidget
    {

        /// <summary>
        /// Content to place inside of the Tooltipped Widget
        /// </summary>
        [Parameter, EditorRequired]
        public required RenderFragment ChildContent { get; set; }

        /// <summary>
        /// The Tooltip Message for this Widget
        /// </summary>
        [Parameter]
        public string? ToolTipMessage { get; set; }

        /// <summary>
        /// How long to delay until showing the Tooltip, in Milliseconds
        /// </summary>
        [Parameter]
        public int DelayTime { get; set; } = 400;

        private string GetEnabled()
                // If should show Tooltip, Change Css to allow for animations
                => (ShowTooltip && !string.IsNullOrWhiteSpace(ToolTipMessage)) switch
                {
                    true => "enabled",
                    false => "disabled",
                };


        private bool ShowTooltip;
        private CancellationTokenSource? _cts;

        private async Task HandleMouseEnter()
        {
            _cts = new CancellationTokenSource();

            try
            {
                await Task.Delay(400, _cts.Token); // delay time
                ShowTooltip = true;
                StateHasChanged();
            }
            catch (TaskCanceledException) { }
        }

        private void HandleMouseLeave()
        {
            _cts?.Cancel();
            ShowTooltip = false;
        }

        private void HandleClick()
        {
            _cts?.Cancel();   // cancel pending tooltip
            ShowTooltip = false;
        }


    }
}