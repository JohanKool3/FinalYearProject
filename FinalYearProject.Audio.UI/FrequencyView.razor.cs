using FinalYearProject.Audio.Helpers;
using FinalYearProject.Audio.Pipeline.AudioSources;
using FinalYearProject.Shared.Helpers;
using FinalYearProject.Shared.Models.AudioRepresentation;
using Microsoft.AspNetCore.Components;
using System.Globalization;

namespace FinalYearProject.Audio.UI
{
    public partial class FrequencyView
    {

        private FileAudioSource _source = null!;

        // Where audio samples are stored
        private float[] _buffer = new float[2048];

        private System.Timers.Timer _timer = null!;

        private FftResult? _results;

        // Holds the frequency labels, e.g. "100Hz", "1kHz"
        private List<(double X, string Text)> _labels = new();


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

        [Parameter]
        public float Padding { get; set; } = 10;

        [Parameter]
        public int Resolution { get; set; } = 512;

        #endregion

        protected override void OnInitialized()
        {
            var path = FileHelper.GetFilePath(FileName, FolderName);
            _source = new FileAudioSource(path);

            _timer = new System.Timers.Timer(30); // ~33fps
            _timer.Elapsed += (s, e) => Tick();
        }

        #region Start and Stop Events

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

            // Reset FFT readout
            _points = "";
            _source.Seek(0);
            StateHasChanged();
        }

        #endregion


        private string _points = "";

        protected override void OnParametersSet()
        {
            if (_results is null || _results.Magnitudes.Length == 0)
            {
                _points = "";
                return;
            }

            BuildPoints();
        }

        private void BuildPoints()
        {
            if (_results is null || _results.Magnitudes.Length == 0)
            {
                _points = "";
                return;
            }

            int count = _results.Magnitudes.Length;

            // Normalize magnitudes 0 to 1
            double max = _results.Magnitudes.Max();
            if (max == 0) max = 1;

            var sb = new System.Text.StringBuilder();

            // Adjust Height and Width for padding
            var adjustedHeight = Height - Padding * 2;
            var adjustedWidth = Width - Padding * 2;

            for (int i = 0; i < count; i++)
            {
                double frequency = _results.Frequencies[i];
                double t = LogMap(frequency, 20, 20000);   // 0–1 in log space
                double x = t * adjustedWidth;


                double y = adjustedHeight - (_results.Magnitudes[i] / max * adjustedHeight);

                sb.Append($"{x.ToString(CultureInfo.InvariantCulture)},{y.ToString(CultureInfo.InvariantCulture)} ");
            }

            _points = sb.ToString();
        }

        private void Tick()
        {
            int read = _source.Read(_buffer);

            // If there are no Samples, exit
            if (read <= 0)
            {
                return;
            }

            var result = AnalysisConverter.ConvertToFrequencyDomain(
                _buffer,
                read,
                Resolution,
                _source.SampleRate ?? 0);

            _results = result;

            BuildPoints();
            BuildLabels();

            InvokeAsync(StateHasChanged);
        }

        private void BuildLabels()
        {
            _labels.Clear();

            int labelCount = 20;

            double minF = 20.0;
            double maxF = 20000.0;

            var adjustedWidth = Width - Padding * 2;

            for (int i = 0; i < labelCount; i++)
            {
                // pick frequencies evenly in log space
                double t = (double)i / (labelCount - 1);             // 0–1
                double freq = Math.Exp(Math.Log(minF) + t * (Math.Log(maxF) - Math.Log(minF)));

                // Round Frequency to nearest power of 100
                freq = Math.Round(freq / 10.0) * 10.0;

                // map to log x-position
                double x = LogMap(freq, minF, maxF) * adjustedWidth;

                // format label to kHz if over 1000
                string label = freq < 1000
                    ? $"{freq:0}"
                    : $"{freq / 1000:0.0}k";

                _labels.Add((x, label));
            }

        }


        /// <summary>
        /// Converts a frequency to a logarithmic scale between a
        /// lowerBound and upperBound
        /// </summary>
        /// <param name="frequency"></param>
        /// <param name="lowerBound"></param>
        /// <param name="upperBound"></param>
        /// <returns></returns>
        private double LogMap(double frequency,
            double lowerBound,
            double upperBound) 
            => Math.Clamp((Math.Log(frequency) - Math.Log(lowerBound)) /
           (Math.Log(upperBound) - Math.Log(lowerBound)),0, 1);
    }
}