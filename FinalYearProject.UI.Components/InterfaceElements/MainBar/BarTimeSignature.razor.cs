using FinalYearProject.Shared.Models.TabRepresentation;
using FinalYearProject.UI.Components.Services;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements.MainBar
{
    public partial class BarTimeSignature(TabRepresentationService representationService)
    {
        #region Parameters
        /// <summary>
        /// Logical Representation of the Time Signature to display
        /// </summary>
        [Parameter, EditorRequired]
        public required TimeSignature TimeSignature { get; set; }

        /// <summary>
        /// Middle X Position of the Time Signature
        /// </summary>
        public int _xPosition 
            => _width / 2;

        /// <summary>
        /// Middle Y Position of the Time Signature
        /// </summary>
        public int _yPosition
            => _height / 2;

        /// <summary>
        /// How Large the Time Signature should be rendered
        /// </summary>
        [Parameter]
        public int FontSize { get; set; } = 24;

        #endregion
       
        public TabRepresentationService RepresentationService { get; } = representationService;

        private int _width
            => RepresentationService
                .Settings
                .PreBar
                .TimeSignatureWidth;

        private int _height
            => RepresentationService.GetBarHeight();

        #region Notes Display Settings

        // The purpose of these settings is to give the 
        // user the feeling that the time signature is still
        // part of the bar area, even though it is rendered
        // separately.
        private int _topPadding
            => RepresentationService
                .Settings
                .Notes
                .TopPadding;

        private int _stringSpacing
            => RepresentationService
                .Settings
                .Notes
                .StringSpacing;

        private int _stringAmount
            => RepresentationService
                .Settings
                .StringCount;

        #endregion

        /// <summary>
        /// Adjusts the X Position so that the Time Signature is centered
        /// </summary>
        /// <returns></returns>
        private int GetAdjustedXPosition()
            => _xPosition - FontSize / 3;

        /// <summary>
        /// Adjusts the Y Position so that the Time Signature is centered
        /// </summary>
        /// <returns></returns>
        private int GetAdjustedYPosition()
            => _yPosition - FontSize / 3;
    }
}