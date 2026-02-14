
using FinalYearProject.Services.Interfaces;
using FinalYearProject.Services.Models;
using FinalYearProject.UI.Helpers;
using Microsoft.AspNetCore.Components;
namespace FinalYearProject.UI.Components.Pages
{
    public partial class Home(NavigationManager navigationManager,
        IAudioRecordingService recordingService,
        AudioRecordingServiceSettings recordingSettings)
    {
        public NavigationManager NavigationManager { get; } = navigationManager;

        public IAudioRecordingService RecordingService { get; } = recordingService;
        public AudioRecordingServiceSettings RecordingSettings { get; } = recordingSettings;

        protected override void OnInitialized()
        {
            // Set Default Settings for Recording Service
            DefaultSettingsHelper
                .SetDefaultAudioRecordingServiceSettings(RecordingSettings,
                RecordingService);

            base.OnInitialized();
        }
        private void Navigate(Guid id)
        {
            NavigationManager.NavigateTo($"/tabview/{id}");
        }

        private static int GetHeight()
            => 500;

        private static int GetWidth()
            => 900;

    }
}
