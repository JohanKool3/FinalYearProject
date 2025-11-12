using FinalYearProject.UI.Components.Helpers;
using FinalYearProject.UI.Components.Models.Settings;
using FinalYearProject.UI.Components.Services;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements.MainBar
{
    public partial class Strings(SettingsService representationService) : ComponentBase
    {

        public RepresentationSettings Settings { get; } = representationService.Settings;

        #region Parameters

        /// <summary>
        /// How Wide the Bar will be
        /// </summary>
        [Parameter, EditorRequired]
        public int Width { get; set; } = 0;

        #endregion

        #region Settings

        private int _stringAmount
            => Settings
                .StringCount;

        private int _height =>
            BarDimensionsHelper.GetBarHeight(Settings);

        /// <summary>
        /// Calculates the spacing between each string
        /// </summary>
        private int _stringSpacing
            => (_height - _topPadding) / _stringAmount;

        /// <summary>
        /// How much space to leave to the top of the strings
        /// </summary>
        private int _topPadding
            => Settings
                .Notes.TopPadding;

        #endregion
    }
}