using FinalYearProject.Audio.Services;
using Microsoft.AspNetCore.Components;
using System.Text;

namespace FinalYearProject.Audio.UI
{
    public partial class WaveformBuilder(FileAudioService audioService)
    {
        private string _points = "";

        /// <summary>
        /// Holds all the samples in the Waveform
        /// </summary>
        private List<float> _allSamples = [];

        /// <summary>
        /// Holds the Samples in the Downsampled Waveform
        /// </summary>
        private List<float> _reduced = [];

        #region Parameters
        [Parameter]
        public float Height { get; set; } = 100;

        [Parameter]
        public float Width { get; set; } = 100;

        [Parameter]
        public int Resolution { get; set; } = 2000;

        [Parameter]
        public int LineWidth { get; set; } = 1;

        [Parameter]
        public string LineColor { get; set; } = "black";

        #endregion

        public FileAudioService AudioService { get; } = audioService;

        protected override void OnInitialized()
        {
            AudioService.OnTickEvent += (s, e) => OnTick();   // subscribe
        }

        private void OnTick()
        {
            _ = InvokeAsync(() =>
            {

                if (AudioService.Buffer == null || AudioService.Buffer.Length == 0)
                    return;

                _allSamples.AddRange(AudioService.Buffer);

                DownsampleToResolution();

                Build();
                StateHasChanged();
            });
        }

        private void Build()
        {
            var buffer = _reduced;

            if (buffer.Count <= 0)
            {
                _points = "";
                return;
            }
            double mid = Height / 2;

            double xScale = Width / buffer.Count;
            double yScale = mid;

            var sb = new StringBuilder(buffer.Count * 8);

            for (int i = 0; i < buffer.Count; i++)
            {
                double x = i * xScale;
                double y = mid - buffer[i] * yScale;

                sb.Append($"{x},{y} ");
            }

            _points = sb.ToString();
        }

        private void DownsampleToResolution()
        {
            // Clamp All Samples to 10 x Resolution

            if (_allSamples.Count > 10 * Resolution)
            {
                _allSamples = _allSamples.Slice(_allSamples.Count - (Resolution * 10), (Resolution * 10));
            }
            if (_allSamples.Count <= Resolution)
                return;

            int step = _allSamples.Count / Resolution;

            // Replace with evenly-spaced samples
            var reduced = new List<float>(Resolution);

            for (int i = 0; i < _allSamples.Count; i += step)
                reduced.Add(_allSamples[i]);

            _reduced = reduced;
        }
    }
}