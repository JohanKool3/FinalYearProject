using FinalYearProject.UI.Components.Models;
using FinalYearProject.UI.Components.Services;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements.MainBar
{
    public partial class Strings(TabRepresentationService representationService) : ComponentBase
    {

        #region Parameters

        /// <summary>
        /// How Wide the Bar will be
        /// </summary>
        [Parameter, EditorRequired]
        public int Width { get; set; } = 0;

        #endregion

        #region Settings
        
        private int _stringAmount 
            => RepresentationService
                .Settings
                .StringCount;

        private int _height =>
            RepresentationService.GetBarHeight();

        /// <summary>
        /// Calculates the spacing between each string
        /// </summary>
        private int _stringSpacing
            => (_height - _topPadding) / _stringAmount;

        /// <summary>
        /// How much space to leave to the top of the strings
        /// </summary>
        private int _topPadding
            => RepresentationService
                .Settings
                .NoteDisplaySettings.TopPadding;

        #endregion

        public TabRepresentationService RepresentationService { get; } = representationService;
    }
}