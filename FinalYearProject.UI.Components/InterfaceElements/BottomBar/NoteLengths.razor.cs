using FinalYearProject.Shared.Models.UI;
using FinalYearProject.UI.Components.Helpers;
using FinalYearProject.UI.Components.Models.Settings;
using FinalYearProject.UI.Components.Services;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements.BottomBar
{
    public partial class NoteLengths(TabRepresentationService representationService)
    {
        public RepresentationSettings Settings { get; } = representationService.Settings;

        #region Parameters

        /// <summary>
        /// The Information to be shown
        /// </summary>
        [Parameter]
        public required BarInformation BarInformation { get; set; }

        /// <summary>
        /// Width of the Note Lengths Area
        /// </summary>
        [Parameter]
        public required int Width { get; set; }

        #endregion

    }
}