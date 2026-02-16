using FinalYearProject.Shared.Services;

namespace FinalYearProject.UI.Components.InterfaceElements.Tab
{
    /// <summary>
    /// Header and Title information for the Tab being displayed
    /// </summary>
    /// <param name="playbackService"></param>
    public partial class TabHeader(DisplayService playbackService)
    {
        public DisplayService PlaybackService { get; set; } = playbackService;

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

        private string _tabDescription
                        => PlaybackService.Description;
    }
}