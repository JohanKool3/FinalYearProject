using FinalYearProject.Audio.Pipeline.AudioSources;
using FinalYearProject.Audio.Services;
using FinalYearProject.Shared.Helpers;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.Audio.UI
{
    public partial class TimeDomainView(FileAudioService audioService)
    {
        private float[] _samples => AudioService.Buffer;
        private System.Timers.Timer _timer = null!;

        #region Parameters
        /// <summary>
        /// The Full Name of the File e.g. "test.wav"
        /// </summary>
        [Parameter]
        public string FileName { get; set; } = string.Empty;

        /// <summary>
        /// Where the Folder is located e.g. "TestData"
        /// </summary>
        [Parameter]
        public string FolderName { get; set; } = string.Empty;

        /// <summary>
        /// The Color of the line representing the audio waveform
        /// </summary>
        [Parameter]
        public string LineColor { get; set; } = "black";

        /// <summary>
        /// How thick the line representing the audio waveform should be
        /// </summary>
        [Parameter]
        public float LineWidth { get; set; } = 1;

        [Parameter]
        public float Width { get; set; } = 600;

        [Parameter]
        public float Height { get; set; } = 100;
        public FileAudioService AudioService { get; } = audioService;

        #endregion

        protected override void OnInitialized()
        {
            AudioService.OnTickEvent += (s, e) => Tick();
        }

        private void Tick()
        {
            InvokeAsync(StateHasChanged);
        }

        private string BuildPoints()
        {
            if (_samples == null)
            {
                return "";
            }

            var step = Width / _samples.Length;

            var points = new List<string>();

            for (int i = 0; i < _samples.Length; i++)
            {
                var x = i * step;
                var y = Height - (_samples[i] * Height);
                points.Add($"{x},{y}");
            }

            return string.Join(" ", points);
        }
    }
}