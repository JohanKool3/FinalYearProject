using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace FinalYearProject.UI.Components.Toolbars.Widgets
{
    public partial class BpmWidget : ComponentBase
    {

        /// <summary>
        /// Value that is used to initialize the BPM display.
        /// </summary>
        [Parameter]
        public int InitialBpm { get; set; } = 120;

        /// <summary>
        /// Event Handler that is invoked when the BPM changes.
        /// </summary>
        [Parameter]
        public EventCallback<int> OnBpmChanged { get; set; }

        /// <summary>
        /// Display value for the current BPM.
        /// </summary>
        private string _currentBpmReadout = string.Empty;

        protected override void OnInitialized()
        {
            // TODO: Load BPM from service.
            _currentBpmReadout = InitialBpm.ToString();
            base.OnInitialized();
        }

        private void AdjustBpm(ChangeEventArgs args)
        {
            var value = args.Value?.ToString()
                ?? string.Empty;

            // Attempt to cast to an integer.
            if (int.TryParse(value, out var newBpm))
            {
                // Clamp the value between 20 and 300 BPM.
                newBpm = Math.Clamp(newBpm, 20, 300);
                _currentBpmReadout = newBpm.ToString();

                OnBpmChanged.InvokeAsync(newBpm);
            }
            else
            {
                // If parsing fails, reset to the last valid BPM.
                _currentBpmReadout = InitialBpm.ToString();
                args.Value = _currentBpmReadout;
            }
        }

        /// <summary>
        /// Validates the input in the BPM text box.
        /// </summary>
        private void ValidateInput()
        {
            // No Empty strings
            if(_currentBpmReadout == string.Empty)
            {
                _currentBpmReadout = InitialBpm.ToString();
            }

            // Non-numeric input
            if (!int.TryParse(_currentBpmReadout, out var newBpm))
            {
                _currentBpmReadout = InitialBpm.ToString();
            }
            else
            {
                // Clamp the value between 20 and 300 BPM.
                newBpm = Math.Clamp(newBpm, 20, 300);
                _currentBpmReadout = newBpm.ToString();
                OnBpmChanged.InvokeAsync(newBpm);
            }
        }
    }
}