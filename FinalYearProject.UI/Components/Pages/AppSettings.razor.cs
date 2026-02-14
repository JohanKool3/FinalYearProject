using FinalYearProject.Services.Interfaces;
using FinalYearProject.Services.Models;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.Pages
{
    public partial class AppSettings(
        AudioRecordingServiceSettings settings,
        IAudioRecordingService recordingService)
    {
        public AudioRecordingServiceSettings Settings { get; } = settings;
        public IAudioRecordingService RecordingService { get; } = recordingService;

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


    }
}