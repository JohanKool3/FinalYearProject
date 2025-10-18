using FinalYearProject.Shared.Models.TabRepresentation;
using FinalYearProject.UI.Components.Services;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.TabView.TabElements
{
    public partial class Strings(TabRepresentationSettingsService settingsService) : ComponentBase
    {

        #region Parameters


        /// <summary>
        /// Defines a Y Offset for the Start of the Bar
        /// </summary>
        [Parameter]
        public int StartY { get; set; } = 0;

        /// <summary>
        /// The Width of the Bar
        /// </summary>
        [Parameter, EditorRequired]
        public int Width { get; set; } = 0;

        /// <summary>
        /// The Height of the Bar
        /// </summary>
        [Parameter, EditorRequired]
        public int Height { get; set; } = 0;

        /// <summary>
        /// How much space to leave at the top
        /// </summary>
        [Parameter]
        public int TopPadding { get; set; } = 10;

        #endregion

        // TODO: Load this from a settings service
        private int StringAmount = settingsService.StringCount;

        /// <summary>
        /// Calculates the spacing between each string
        /// </summary>
        private int StringSpacing
            => (Height - TopPadding) / StringAmount ;

        public TabRepresentationSettingsService SettingsService { get; } = settingsService;
    }
}