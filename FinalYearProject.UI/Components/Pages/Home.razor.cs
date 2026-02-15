using FinalYearProject.Services.Interfaces;
using FinalYearProject.Services.Settings;
using FinalYearProject.UI.Helpers;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.Pages
{
    public partial class Home(NavigationManager navigationManager,
        AudioServiceSettings audioSettings,
        IAudioService audioService)
    {
        public NavigationManager NavigationManager { get; } = navigationManager;

        public AudioServiceSettings AudioSettings { get; } = audioSettings;
        public IAudioService AudioService { get; } = audioService;

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
