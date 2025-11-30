using FinalYearProject.Audio.Pipeline.AudioSources;
using FinalYearProject.Shared.Helpers;
using Microsoft.AspNetCore.Components;
using System.Timers;

namespace FinalYearProject.Audio.UI
{
    public partial class WaveformView
    {
        private FileAudioSource _source;
        private float[] _buffer = new float[2048];
        private float[] _samples;
        private System.Timers.Timer _timer;

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

        protected override void OnInitialized()
        {
            var path = FileHelper.GetTestFilePath(FileName, FolderName);
            _source = new FileAudioSource(path);

            _timer = new System.Timers.Timer(30); // ~33fps
            _timer.Elapsed += (s, e) => Tick();
            _timer.Start();
        }

        private void Tick()
        {
            int read = _source.Read(_buffer);

            if (read > 0)
            {
                _samples = _buffer.Take(read).ToArray();
            }

            InvokeAsync(StateHasChanged);
        }

        private string BuildPoints()
        {
            if (_samples == null) return "";

            var width = 600.0;
            var height = 100.0;

            var step = width / _samples.Length;

            var points = new List<string>();

            for (int i = 0; i < _samples.Length; i++)
            {
                var x = i * step;
                var y = height - (_samples[i] * height);
                points.Add($"{x},{y}");
            }

            return string.Join(" ", points);
        }
    }
}