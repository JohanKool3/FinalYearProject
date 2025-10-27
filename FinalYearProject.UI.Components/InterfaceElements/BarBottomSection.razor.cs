using FinalYearProject.UI.Components.Models.InterfaceElements;
using FinalYearProject.UI.Components.Services;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements
{
    public partial class BarBottomSection(TabRepresentationService representationService)
    {
        public TabRepresentationService RepresentationService { get; } 
            = representationService;

        #region Parameters

        /// <summary>
        /// The Width of the Bottom Section
        /// </summary>
        [Parameter, EditorRequired]
        public int Width { get; set; }

        /// <summary>
        /// Information to be shown in the Bar Bottom Section
        /// </summary>
        [Parameter, EditorRequired]
        public BarInformation BarInformation { get; set; }

        #endregion

        #region Settings

        private int _height 
            => RepresentationService
                    .Settings
                    .BottomBarDisplaySettings
                    .Height;

      private bool _debugMode 
            => RepresentationService
                    .Settings
                    .DebugMode;
        #endregion


    }
}