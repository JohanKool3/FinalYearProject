using FinalYearProject.Audio.Helpers;
using FinalYearProject.Shared.Helpers;
using FinalYearProject.Shared.Models.AudioRepresentation;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.Audio.UI
{
    public partial class WaveFormView
    {
        #region Parameters

        [Parameter]
        public string FileName { get; set; } = string.Empty;

        [Parameter]
        public string FolderName { get; set; } = string.Empty;

        [Parameter]
        public float Height { get; set; } = 100;

        [Parameter]
        public float Width { get; set; } = 600;

        [Parameter]
        public int LineWidth { get; set; } = 1;

        [Parameter]
        public string LineColor { get; set; } = "black";

        [Parameter]
        public int Resolution { get; set; } = 500;

        [Parameter]
        public bool Fill { get; set; } = true;

        #endregion

        private List<WaveformPoint> _points = [];

        protected override void OnInitialized()
        {
            var filePath = FileHelper.GetFilePath(FileName, FolderName);

            _points = WaveformLoader.LoadFileWaveform(filePath, Resolution);
        }

        private string BuildPositivePoints()
        {
            double step = Width / _points.Count;

            var list = new List<string>();

            for (int i = 0; i < _points.Count; i++)
            {
                double x = i * step;
                double y = Height - (_points[i].MaxPositive * Height);
                list.Add($"{x},{y}");
            }

            return string.Join(" ", list);
        }

        private string BuildNegativePoints()
        {
            double step = Width / _points.Count;

            var list = new List<string>();

            for (int i = 0; i < _points.Count; i++)
            {
                double x = i * step;
                double y = Height - (_points[i].MaxNegative * Height);
                list.Add($"{x},{y}");
            }

            return string.Join(" ", list);
        }

        public string GetFill()
            => Fill ? LineColor : "none";
    }
}
