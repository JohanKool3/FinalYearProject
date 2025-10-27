using FinalYearProject.UI.Components.Helpers;
using FinalYearProject.UI.Components.Models;
using FinalYearProject.UI.Components.Services;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements.BottomBar
{
    public partial class NoteLengths(TabRepresentationSettingsService settingsService)
    {
        #region Parameters
        
        /// <summary>
        /// The Information to be shown
        /// </summary>
        [Parameter]
        public required BarDisplayInformation BarInformation { get; set; }

        /// <summary>
        /// Width of the Note Lengths Area
        /// </summary>
        [Parameter]
        public required int Width { get; set; }

        #endregion
        
    }
}