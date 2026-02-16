using FinalYearProject.Shared.Enums;
using FinalYearProject.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements
{
    public partial class ToolbarSlider(UserSettings userSettings)
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

        /// <summary>
        /// The Slider that this Widget Represents
        /// </summary>
        [Parameter, EditorRequired]
        public required Slider Slider { get; set; }

        public UserSettings UserSettings { get; } = userSettings;

        #endregion

        /// <summary>
        /// Whether to show the slider
        /// </summary>
        private bool IsOpen;

        private void Toggle()
        {
            if (IsOpen)
            {
                // Release the lock for other sliders to be interacted with
                UserSettings.ActiveSlider = null;
                IsOpen = false;
            }
            else
            {
                // Check if another Slider is active
                if (UserSettings.ActiveSlider is not null)
                {
                    return;
                }

                IsOpen = true;
                UserSettings.ActiveSlider = Slider;
            }
        }

        private string IsEnabled()
            => IsOpen switch
            {
                true => "enabled",
                false => "disabled"
            };
        private Task OnInputAsync(ChangeEventArgs args)
        {
            var newValue = int.Parse(args.Value!.ToString()!);

            Value = newValue;

            return ValueChanged.InvokeAsync(newValue);
        }
    }
}