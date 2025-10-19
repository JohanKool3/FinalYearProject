using FinalYearProject.UI.Components.Services;

namespace FinalYearProject.UI.Components.InterfaceElements
{
    public partial class TabHeader(TabPlaybackService playbackService)
    {
        public TabPlaybackService PlaybackService { get; set; } = playbackService;

        /// <summary>
        /// Author of the current tab
        /// </summary>
        private string _author 
            => PlaybackService.Author;

        /// <summary>
        /// Title of the current tab
        /// </summary>
        private string _title
            => PlaybackService.Title;
    }
}