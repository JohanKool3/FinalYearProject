using FinalYearProject.Api.Models;
using FinalYearProject.Shared.Models.Dtos;
using FinalYearProject.Shared.Services;
using FinalYearProject.UI.Components.Services;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.Pages
{
    public partial class PerformanceResults(
        PerformanceService performanceService,
        DisplayService displayService)
    {
        //TODO: Adjust this so that it works off of
        // request ID

        // <summary>
        /// The Id of this Piece
        /// </summary>
        [Parameter]
        public Guid PieceId { get; set; }
        
        public PerformanceService PerformanceService { get; } = performanceService;
        public DisplayService DisplayService { get; } = displayService;

        private AccuracyResultsDto Results
            => PerformanceService?.LastFetchedResults
            ?? new();

        private int _accuracy => (int)(Results.NoteAccuracy * 100);

        private bool DataLoaded()
            => PerformanceService.LastFetchedResults is not null;
    
    }
}