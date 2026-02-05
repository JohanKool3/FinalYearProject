using FinalYearProject.UI.Components.Helpers;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements.Recording.SubElements
{
    public partial class WaveformView
    {

        private float[] WaveForm { get; set; } = [];

        [Parameter]
        public double Progress { get; set; } // 0 -> 1

        [Parameter, EditorRequired]

        public int Width { get; set; } = 200;

        [Parameter, EditorRequired]

        public int Height { get; set; } = 100;


        /// <summary>
        /// The File path for this waveform
        /// </summary>
        [Parameter, EditorRequired]
        public required string FilePath { get; set; }

        /// <summary>
        /// How many sample points to use for waveform view
        /// </summary>
        [Parameter, EditorRequired]
        public required int Resolution { get; set; }

        protected override Task OnInitializedAsync()
        {
            // TODO: Check the waveform is valid before setting it
             WaveForm = WaveFileHelper.ReadWavFile(FilePath, Resolution);

            return base.OnInitializedAsync();
        }

        private float GetSampleWidth()
            => WaveForm.Length / (Resolution);
    }
}