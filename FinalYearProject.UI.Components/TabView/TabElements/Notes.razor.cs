using FinalYearProject.UI.Components.Models;
using FinalYearProject.UI.Components.Services;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.TabView.TabElements
{
    public partial class Notes(TabRepresentationSettingsService representationSettingsService)
    {

        public TabRepresentationSettingsService RepresentationSettingsService { get; } 
            = representationSettingsService;

        #region Parameters

        /// <summary>
        /// How much of the string should be cutout when there is a
        /// note over it. This is a radius for a circle.
        /// </summary>
        [Parameter]
        public int NoteCutoutRadius { get; set; } = 7;

        /// <summary>
        /// Holds the list of notes to display.
        /// </summary>
        [Parameter, EditorRequired]
        public List<NoteDisplayInformation> NotesToDisplay { get; set; }

        #endregion

        /// <summary>
        /// Space to leave at the left of the notes area
        /// </summary>
        private int _leftPadding 
            => RepresentationSettingsService.NoteDisplaySettings.LeftPadding;

        /// <summary>
        /// Space to leave at the top of the notes area
        /// </summary>
        private int _topPadding 
            => RepresentationSettingsService.NoteDisplaySettings.TopPadding;

        private int _width
            => RepresentationSettingsService.GetBarWidth(NotesToDisplay);

        private int _height
            => RepresentationSettingsService.GetBarHeight();

        private int GetNotePosition(NoteDisplayInformation note)
        {
            // Calculate the position based on the BarPercentage and Width
            return (int)((note.BarPercentage / 100.0) * _width);
        }
    }
}