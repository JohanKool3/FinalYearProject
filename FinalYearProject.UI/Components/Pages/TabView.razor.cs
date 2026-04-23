using FinalYearProject.Services.Interfaces;
using FinalYearProject.Shared.Services;
using FinalYearProject.UI.Components.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace FinalYearProject.UI.Components.Pages
{
    public partial class TabView(DisplayService displayService,
        IAudioService audioService,
        IUserDataService userDataService,
        NavigationManager navigationManager)
    {
        private readonly IUserDataService _userDataService = userDataService;

        /// <summary>
        /// The Id of this Piece
        /// </summary>
        [Parameter]
        public Guid PieceId { get; set; }

        public DisplayService DisplayService { get; } = displayService;

        public IAudioService AudioService { get; } = audioService;

        public NavigationManager NavigationManager { get; } = navigationManager;

        protected override async Task OnInitializedAsync()
        {
            NavigationManager.LocationChanged += CancelPlayback;

            // Fetch Data
            await DisplayService.LoadPieceAsync(PieceId, CancellationToken.None);
            await DisplayService.SetCurrentPieceIdAsync(PieceId);

            // Create Recording Folder (Ensures it exists for later recording logic)
            _userDataService.GetPieceDirectory(PieceId);

            await base.OnInitializedAsync();
        }

        private void CancelPlayback(object? sender, LocationChangedEventArgs e)
        {
            AudioService.StopPlayback();
        }

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                AudioService.StartPlayback();
            }

            base.OnAfterRender(firstRender);
        }


        private bool TabIsLoaded()
            => DisplayService.CurrentTab != null;
    }
}