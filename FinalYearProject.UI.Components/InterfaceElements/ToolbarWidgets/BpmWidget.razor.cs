using FinalYearProject.UI.Components.Services;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements.ToolbarWidgets
{
    public partial class BpmWidget(DisplayService playbackService) : ComponentBase
    {

        /// <summary>
        /// Value that is used to initialize the BPM display.
        /// </summary>
        [Parameter]
        public int InitialBpm { get; set; } = 120;

        /// <summary>
        /// Notify the parent component that a change has occurred.
        /// </summary>
        [Parameter, EditorRequired]
        public Func<Task> NotifyParentOfChange { get; set; } = null!;

        public DisplayService PlaybackService { get; set; } = playbackService;

        /// <summary>
        /// Display value for the current BPM.
        /// </summary>
        private string _currentBpmReadout = string.Empty;

        protected override void OnInitialized()
        {
            InitialBpm = PlaybackService.Bpm;
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
                PlaybackService.SetBpm(newBpm);

                InvokeAsync(NotifyParentOfChange);
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

                // Set the new BPM
                PlaybackService.SetBpm(newBpm);
            }
        }
    }
}