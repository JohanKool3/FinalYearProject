using FinalYearProject.Shared.Services;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.Pages
{
    public partial class TabView(DisplayService displayService)
    {
        /// <summary>
        /// The Id of this Piece
        /// </summary>
        [Parameter]
        public Guid PieceId { get; set; }

        public DisplayService DisplayService { get; } = displayService;

        protected override async Task OnInitializedAsync()
        {
            // Fetch Data
            await DisplayService.LoadPieceAsync(PieceId, CancellationToken.None);
            await DisplayService.SetCurrentPieceIdAsync(PieceId);
            await base.OnInitializedAsync();
        }


        private bool TabIsLoaded()
            => DisplayService.CurrentTab != null;
    }
}