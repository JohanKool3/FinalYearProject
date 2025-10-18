using FinalYearProject.UI.Components.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalYearProject.UI.Components.Interfaces
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
        public TabDisplayInformation? GetCurrentTab();

        /// <summary>
        /// Loads Tab Display Information
        /// </summary>
        public void LoadTabDisplayInformation(TabDisplayInformation information);

        /// <summary>
        /// Returns whether a tab is currently loaded
        /// </summary>
        /// <returns></returns>
        public bool IsTabLoaded();
    }
}
