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

        /// <summary>
        /// Whether to wrap text or not
        /// </summary>
        [Parameter]
        public bool NoWrap { get; set; } = true;

        private string GetEnabled()
                // If should show Tooltip, Change Css to allow for animations
                => (ShowTooltip && !string.IsNullOrWhiteSpace(ToolTipMessage)) switch
                {
                    true => "enabled",
                    false => "disabled",
                };

        private string GetWrapped()
            => NoWrap switch
            {
                true => "nowrap",
                false => "wrap"
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
                await InvokeAsync(StateHasChanged);
            }
            catch (TaskCanceledException) { }
        }

        private Task HandleMouseLeaveAsync()
        {
            if(_cts is null)
            {
                return Task.CompletedTask;
            }
            ShowTooltip = false;

            return _cts.CancelAsync();
            
        }

        private Task HandleClickAsync()
        {

            if(_cts is null)
            {
                return Task.CompletedTask;
            }

            
            ShowTooltip = false;
            return _cts.CancelAsync();   // cancel pending tooltip
        }
    }


}