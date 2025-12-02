using FinalYearProject.Audio.Services;
using Microsoft.AspNetCore.Components;
using System.Globalization;
using System.Text;

namespace FinalYearProject.Audio.UI
{
    public partial class FrequencyView(FileAudioService audioService)
    {

        // Holds the frequency labels, e.g. "100Hz", "1kHz"
        private List<(double X, string Text)> _labels = [];


        #region Parameters
        
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
       
        public FileAudioService AudioService { get; } = audioService;

        #endregion

        protected override void OnInitialized()
        {
            BuildLabels();

            // Register the Tick method in the Audio Service Event Handler
            AudioService.OnTickEvent += Tick;
        }

        private void Tick(object? sender, EventArgs e)
        {
            BuildPoints();
            InvokeAsync(StateHasChanged);
        }

        private string _points = "";

        private void BuildPoints()
        {
            var results = AudioService.ReadBufferToFrequencyDomain(Resolution);


            if (results is null || results.Magnitudes.Length == 0)
            {
                _points = "";
                return;
            }

            int count = results.Magnitudes.Length;

            // Normalize magnitudes 0 to 1
            double max = results.Magnitudes.Max();
            if (max == 0) max = 1;

            var sb = new StringBuilder();

            // Adjust Height and Width for padding
            var adjustedHeight = Height - Padding * 2;
            var adjustedWidth = Width - Padding * 2;

            for (int i = 0; i < count; i++)
            {
                double frequency = results.Frequencies[i];
                double t = LogMap(frequency, 20, 20000);   // 0–1 in log space
                double x = t * adjustedWidth;


                double y = adjustedHeight - (results.Magnitudes[i] / max * adjustedHeight);

                sb.Append($"{x.ToString(CultureInfo.InvariantCulture)},{y.ToString(CultureInfo.InvariantCulture)} ");
            }

            _points = sb.ToString();
        }

        private void BuildLabels()
        {
            _labels.Clear();

            // Cannot Refresh the Labels if the 
            if(_labels.Count > 0)
            {
                return;
            }

            int labelCount = 20;

            double minF = 20.0;
            double maxF = 20000.0;

            var adjustedWidth = Width - (Padding * 2);

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
        private static double LogMap(double frequency,
            double lowerBound,
            double upperBound) 
            => Math.Clamp((Math.Log(frequency) - Math.Log(lowerBound)) /
           (Math.Log(upperBound) - Math.Log(lowerBound)),0, 1);
    }
}