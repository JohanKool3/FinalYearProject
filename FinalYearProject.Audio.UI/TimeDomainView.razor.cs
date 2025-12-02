using FinalYearProject.Audio.Pipeline.AudioSources;
using FinalYearProject.Shared.Helpers;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.Audio.UI
{
    public partial class TimeDomainView
    {
        private FileAudioSource _source = null!;
        private float[] _buffer = new float[2048];
        private float[] _samples = new float[2048];
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

        #endregion

        protected override void OnInitialized()
        {
            var path = FileHelper.GetFilePath(FileName, FolderName);
            _source = new FileAudioSource(path);

            _timer = new System.Timers.Timer(30); // ~33fps
            _timer.Elapsed += (s, e) => Tick();
        }

        /// <summary>
        /// Starts the Audio Visualizer
        /// </summary>
        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }

        public void Reset()
        {
            _timer.Stop();
            _samples = new float[2048];
            StateHasChanged();
            _source.Seek(0);
        }

        private void Tick()
        {
            int read = _source.Read(_buffer);

            if (read > 0)
            {
                _samples = [.. _buffer.Take(read)];
            }

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