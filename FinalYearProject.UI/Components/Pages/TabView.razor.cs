using FinalYearProject.Services.Interfaces;
using FinalYearProject.Shared.Services;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.Pages
{
    public partial class TabView(DisplayService displayService,
        IAudioService audioService)
    {
        /// <summary>
        /// The Id of this Piece
        /// </summary>
        [Parameter]
        public Guid PieceId { get; set; }

        public DisplayService DisplayService { get; } = displayService;
        public IAudioService AudioService { get; } = audioService;

        protected override async Task OnInitializedAsync()
        {
            // Fetch Data
            await DisplayService.LoadPieceAsync(PieceId, CancellationToken.None);
            await DisplayService.SetCurrentPieceIdAsync(PieceId);
            await base.OnInitializedAsync();
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