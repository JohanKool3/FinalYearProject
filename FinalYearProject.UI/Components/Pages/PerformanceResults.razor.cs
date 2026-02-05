using FinalYearProject.Api.Models;
using FinalYearProject.Shared.Models.Dtos;
using FinalYearProject.UI.Components.Services;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.Pages
{
    public partial class PerformanceResults(
        PerformanceService performanceService)
    {
        //TODO: Adjust this so that it works off of
        // request ID

        // <summary>
        /// The Id of this Piece
        /// </summary>
        [Parameter]
        public Guid PieceId { get; set; }
        
        public PerformanceService PerformanceService { get; } = performanceService;

        private AccuracyResultsDto Results
            => PerformanceService?.LastFetchedResults
            ?? new();

        private bool DataLoaded()
            => PerformanceService.LastFetchedResults is not null;
    
    }
}