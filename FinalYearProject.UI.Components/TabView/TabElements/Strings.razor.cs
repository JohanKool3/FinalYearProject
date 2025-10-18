using FinalYearProject.Shared.Models.TabRepresentation;
using FinalYearProject.UI.Components.Models;
using FinalYearProject.UI.Components.Services;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.TabView.TabElements
{
    public partial class Strings(TabRepresentationSettingsService settingsService) : ComponentBase
    {

        #region Parameters
        
        /// <summary>
        /// The notes to display on the tab
        /// </summary>
        [Parameter, EditorRequired]
        public List<NoteDisplayInformation> Notes { get; set; } = [];

        /// <summary>
        /// The Height of the Bar
        /// </summary>
        [Parameter, EditorRequired]
        public int Height { get; set; } = 0;

        #endregion

        private readonly int StringAmount = settingsService.StringCount;

        /// <summary>
        /// Calculates the spacing between each string
        /// </summary>
        private int StringSpacing
            => (Height - _topPadding) / StringAmount ;

        /// <summary>
        /// How much space to leave to the top of the strings
        /// </summary>
        private int _topPadding 
            => SettingsService.NoteDisplaySettings.TopPadding;

        /// <summary>
        /// How Wide the Bar will be
        /// </summary>
        private int _width =>
            settingsService.GetBarWidth(Notes);

        public TabRepresentationSettingsService SettingsService { get; } = settingsService;
    }
}