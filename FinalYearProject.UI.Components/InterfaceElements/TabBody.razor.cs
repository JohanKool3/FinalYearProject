using FinalYearProject.Shared.Models.TabRepresentation;
using FinalYearProject.UI.Components.Helpers;
using FinalYearProject.UI.Components.Models;
using FinalYearProject.UI.Components.Services;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements
{
    public partial class TabBody(TabPlaybackService playbackService,
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
        private TabDisplayInformation? GetCurrentTab()
            => PlaybackService.CurrentTab;


        /// <summary>
        /// Returns whether a tab is currently loaded in the playback service
        /// </summary>
        /// <returns></returns>
        private bool IsTabLoaded()
            => GetCurrentTab() is not null;

        /// <summary>
        /// Determines whether the time signature should be rendered for the current bar
        /// </summary>
        /// <remarks>
        /// This is done when the time signature changes from the previous bar to the current bar, or if it is the first bar
        /// </remarks>
        /// <param name="previousIndex"></param>
        /// <param name="currentIndex"></param>
        /// <returns></returns>
        private bool RenderTimeSignatureForBar(int previousIndex, int currentIndex)
        {
            // Must be the First Bar, Render the time signature
            if(previousIndex < 0)
            {
                return true;
            }

            return BarConditionalRenderingHelper.RenderTimeSignature(
                GetCurrentTab()!.Bars[previousIndex],
                GetCurrentTab()!.Bars[currentIndex]);
        }

        private bool RenderTuningForBar(int index)
            => index == 0;
    }
}