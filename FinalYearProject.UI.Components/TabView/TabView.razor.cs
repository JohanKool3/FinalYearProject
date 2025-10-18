using FinalYearProject.Shared.Models.TabRepresentation;
using FinalYearProject.UI.Components.Services;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.TabView
{
    public partial class TabView(TabPlaybackService playbackService,
        TabRepresentationSettingsService respresentationService)
        : ComponentBase
    {
        public TabPlaybackService PlaybackService { get; set; }
            = playbackService;
        
        public TabRepresentationSettingsService RepresentationService { get; }
            = respresentationService;

        /// <summary>
        /// Returns the current loaded tab from the playback service
        /// </summary>
        /// <returns></returns>
        private FullPiece? GetCurrentTab()
            => PlaybackService.CurrentPiece;


        /// <summary>
        /// Returns whether a tab is currently loaded in the playback service
        /// </summary>
        /// <returns></returns>
        private bool IsTabLoaded()
            => GetCurrentTab() is not null;
    }
}