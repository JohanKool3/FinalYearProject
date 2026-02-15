using FinalYearProject.Services.Settings;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.Pages
{
    public partial class Home(NavigationManager navigationManager,
        AudioRecordingServiceSettings recordingSettings)
    {
        public NavigationManager NavigationManager { get; } = navigationManager;

        public AudioRecordingServiceSettings RecordingSettings { get; } = recordingSettings;

        protected override void OnInitialized()
        {
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
