using FinalYearProject.Shared.Models.TabRepresentation;
using FinalYearProject.Shared.Models.UI;
using FinalYearProject.UI.Components.Helpers;
using FinalYearProject.UI.Components.Services;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements.Tab
{
    public partial class TabBody(DisplayService playbackService,
        SettingsService representationService)
        : ComponentBase
    {
        public DisplayService PlaybackService { get; set; }
            = playbackService;
        
        public SettingsService RepresentationService { get; }
            = representationService;

        /// <summary>
        /// Returns the current loaded tab from the playback service
        /// </summary>
        /// <returns></returns>
        private TabInformation? GetCurrentTab()
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

        /// <summary>
        /// Determines whether the BPM should be rendered for the current bar
        /// </summary>
        /// <param name="previousIndex"></param>
        /// <param name="currentIndex"></param>
        /// <returns></returns>
        /// <remarks>
        /// This is done when the BPM changes from the previous bar to the current bar, or if it is the first bar
        /// </remarks>
        private bool RenderBpmForBar(int previousIndex, int currentIndex)
        {
            // Must be the First Bar, Render the BPM
            if (previousIndex < 0)
            {
                return true;
            }
            return BarConditionalRenderingHelper.RenderBpm(
                GetCurrentTab()!.Bars[previousIndex],
                GetCurrentTab()!.Bars[currentIndex]);
        }

        private static bool RenderTuningForBar(int index)
            => index == 0;
    }
}