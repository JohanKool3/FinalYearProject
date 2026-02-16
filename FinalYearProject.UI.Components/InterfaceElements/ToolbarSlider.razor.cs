using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements
{
    public partial class ToolbarSlider
    {
        #region Parameters

        /// <summary>
        /// Title of the Slider
        /// </summary>
        [Parameter]
        public string Title { get; set; } = string.Empty;

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        [Parameter]
        public int Value { get; set; }

        /// <summary>
        /// When the Value is Changed
        /// </summary>
        [Parameter]
        public EventCallback<int> ValueChanged { get; set; }

        /// <summary>
        /// Tooltip for this slider
        /// </summary>
        [Parameter]
        public string Tooltip { get; set; } = string.Empty;

        #endregion

        /// <summary>
        /// Whether to show the slider
        /// </summary>
        private bool IsOpen;

        private void Toggle()
        {
            IsOpen = !IsOpen;
        }

        private string IsEnabled()
            => IsOpen switch
            {
                true => "enabled",
                false => "disabled"
            };
    }
}