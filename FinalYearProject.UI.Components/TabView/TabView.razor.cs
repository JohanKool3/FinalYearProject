using FinalYearProject.Shared.Models.TabRepresentation;
using FinalYearProject.UI.Components.Services;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.TabView
{
    public partial class TabView(TabPlaybackService playbackService) 
        : ComponentBase
    {
        public TabPlaybackService PlaybackService { get; set; } 
            = playbackService;

        /// <summary>
        /// Returns the current loaded tab from the playback service
        /// </summary>
        /// <returns></returns>
        private FullTab? GetCurrentTab()
            => PlaybackService.CurrentTab;


        /// <summary>
        /// Returns whether a tab is currently loaded in the playback service
        /// </summary>
        /// <returns></returns>
        private bool IsTabLoaded()
            => GetCurrentTab() is not null;
    }
}