using FinalYearProject.Services.Interfaces;
using FinalYearProject.Services.Settings;
using FinalYearProject.Shared.Services;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.Pages
{
    public partial class Home(NavigationManager navigationManager,
        AudioServiceSettings audioSettings,
        PlaybackService playbackService,
        IAudioService audioService)
    {
        public NavigationManager NavigationManager { get; } = navigationManager;

        public AudioServiceSettings AudioSettings { get; } = audioSettings;
        public PlaybackService PlaybackService { get; } = playbackService;
        public IAudioService AudioService { get; } = audioService;

        private void Navigate(Guid id)
        {
            // Set the ID in the playback service
            PlaybackService.ActivePieceId = id;

            // Navigate to Tab View for this Piece
            NavigationManager.NavigateTo($"/tabview/{id}");
        }

        private static int GetHeight()
            => 500;

        private static int GetWidth()
            => 900;

    }
}
