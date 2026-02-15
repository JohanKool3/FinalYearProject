using FinalYearProject.Services.Recording;
using FinalYearProject.UI.Models;

namespace FinalYearProject.UI.Components.Pages
{
    public partial class AppSettings(
        AudioRecordingServiceSettings settings)
    {
        public AudioRecordingServiceSettings Settings { get; } = settings;

        private SettingsExpansion ExpansionSettings = new();

        #region Recording Settings Section

        public int _inputVolumePercentage
        {
            get => Settings.InputVolumePercent;
            set => Settings.InputVolumePercent = Math.Clamp(value, 0, 100);
        }

        public int _outputVolumePercentage
        {
            get => Settings.OutputVolumePercent;
            set => Settings.OutputVolumePercent = Math.Clamp(value, 0, 100);
        }

        public int _inputLatencyMs
        {
            get => Settings.InputLatency;
            set => Settings.InputLatency = Math.Clamp(value, 0, Settings.MaxLatency);
        }

        public int _outputLatencyMs
        {
            get => Settings.OutputLatency;
            set => Settings.OutputLatency = Math.Clamp(value, 0, Settings.MaxLatency);
        }

        #endregion

        #region Expansion Management
        private void ToggleRecording()
            => ExpansionSettings.Recording = !ExpansionSettings.Recording;


        private static string GetSize(bool isSectionExpanded)
            => isSectionExpanded switch
            {
                false => "section-body collapsed",
                true => "section-body expanded"
            };
        #endregion

    }
}