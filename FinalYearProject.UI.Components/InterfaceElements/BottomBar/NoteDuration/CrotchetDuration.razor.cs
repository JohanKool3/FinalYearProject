using FinalYearProject.UI.Components.Services;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements.BottomBar.NoteDuration
{
    public partial class CrotchetDuration(TabRepresentationService representationService)
    {
        #region Parameters

        /// <summary>
        /// Where this note duration should be drawn on the X Axis
        /// </summary>
        [Parameter]
        public int XPosition { get; set; }
        #endregion

        public TabRepresentationService RepresentationService { get; }
            = representationService;

        #region Settings
        private int _height 
            => RepresentationService
                .Settings
                .BottomBar
                .Height;

        private int _noteSpacing 
            => RepresentationService
                .Settings
                .Notes
                .NoteSpacing;

        #endregion

        private int _noteHeight
            => 2 * _height / 3;
    }
}