using FinalYearProject.Shared.Models.UI;

namespace FinalYearProject.Shared.Services
{
    /// <summary>
    /// Outlines a service for Loading Tab Display information
    /// </summary>
    public interface ITabLoaderService
    {
        /// <summary>
        /// Get the Currently loaded Tab Display Information
        /// </summary>
        /// <returns></returns>
        public Task<TabInformation?> GetTabAsync(Guid pieceId, CancellationToken cancellationToken);

        /// <summary>
        /// Loads Tab Display Information
        /// </summary>
        public void LoadTab(TabInformation information);

        /// <summary>
        /// Returns whether a tab is currently loaded
        /// </summary>
        /// <returns></returns>
        public bool IsTabLoaded();
    }
}
