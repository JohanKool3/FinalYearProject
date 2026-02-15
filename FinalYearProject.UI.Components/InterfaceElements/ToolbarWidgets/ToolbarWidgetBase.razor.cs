using FinalYearProject.UI.Components.Enums;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements.ToolbarWidgets
{
    public partial class ToolbarWidgetBase
    {
        [Parameter, EditorRequired]
        public required RenderFragment ChildContent { get; set; }

        [Parameter]
        public WidgetWidth WidgetWidth { get; set; } = WidgetWidth.Single;


        /// <summary>
        /// Tooltip Message for this Widget
        /// </summary>
        [Parameter]
        public string? ToolTipMessage { get; set; }

        private string GetSizeClass()
            =>
              WidgetWidth switch{
                  WidgetWidth.Single => "normal",
                  WidgetWidth.Double => "double",
                  WidgetWidth.Triple => "triple",
                  _ => "normal"
              };


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