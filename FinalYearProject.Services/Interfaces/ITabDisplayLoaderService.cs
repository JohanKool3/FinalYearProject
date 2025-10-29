using FinalYearProject.Shared.Models.UI;

namespace FinalYearProject.Services.Interfaces
{
    /// <summary>
    /// Outlines a service for Loading Tab Display information
    /// </summary>
    public interface ITabDisplayLoaderService
    {
        /// <summary>
        /// Get the Currently loaded Tab Display Information
        /// </summary>
        /// <returns></returns>
        public TabInformation? GetCurrentTab();

        /// <summary>
        /// Loads Tab Display Information
        /// </summary>
        public void LoadTabDisplayInformation(TabInformation information);

        /// <summary>
        /// Returns whether a tab is currently loaded
        /// </summary>
        /// <returns></returns>
        public bool IsTabLoaded();
    }
}
