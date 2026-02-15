using FinalYearProject.Services.Interfaces;
using FinalYearProject.Services.Models;
using FinalYearProject.Services.Settings;
using FinalYearProject.UI.Models;

namespace FinalYearProject.UI.Components.Pages
{
    public partial class AppSettings(
        AudioServiceSettings settings,
        IAudioService audioService,
        AppSettingsExpansionSettings appSettingsExpansionSettings)
    {
        public AudioServiceSettings Settings { get; } = settings;
        public IAudioService AudioService { get; } = audioService;

        private AppSettingsExpansionSettings AppSettingsExpansionSettings = appSettingsExpansionSettings;

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
            => AppSettingsExpansionSettings.Recording = !AppSettingsExpansionSettings.Recording;


        private static string GetSize(bool isSectionExpanded)
            => isSectionExpanded switch
            {
                false => "section-body collapsed",
                true => "section-body expanded"
            };
        #endregion


        #region Documentation

        private string InputDeviceInformation =
            """ Selects the Input Device for Listening. This will be the device sampled for audio analysis""";

        private string OutputDeviceInformation =
            """ Selects the Output Device for Audio Playback""";


        private string InputVolumeInformation =
            """ Sets a percentage multiplier for input volume control. 0% to 100% """;

        private string OutputVolumeInformation =
            """ Sets a percentage multiplier for output volume control. 0% to 100% """;


        private string InputLatencyInformation =
            """
             Sets a delay between input being detected to it being analyzed. Used to
             reduce artifacts and ensure that other parts of the system (e.g. the metronome
             and backing track) line up correctly
            """;

        private string OutputLatencyInformation =
             """
             Sets a delay between audio being processed and it being output. Used to
             reduce artifacts and ensure that other parts of the system (e.g. the metronome
             and backing track) line up correctly
            """;

        #endregion

        private string GetIcon(bool settingsSection)
            => settingsSection switch
            {
                true => "collapse.svg",
                false => "expand.svg"
            };


        private List<AudioDevice> GetInputDevices()
            => AudioService.GetInputDevices();

        private List<AudioDevice> GetOutputDevices()
            => AudioService.GetOutputDevices();
    }
}