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

        #endregion

        private readonly int StringAmount = settingsService.StringCount;

        private int _height =>
            settingsService.GetBarHeight();

        /// <summary>
        /// Calculates the spacing between each string
        /// </summary>
        private int StringSpacing
            => (_height - _topPadding) / StringAmount ;

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