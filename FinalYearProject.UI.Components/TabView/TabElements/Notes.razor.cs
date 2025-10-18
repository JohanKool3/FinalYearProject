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

        private int _stringSpacing
            => RepresentationSettingsService
                .NoteDisplaySettings
                .StringSpacing;

        private int GetNoteXPosition(NoteDisplayInformation note)
        {
            // Calculate the position based on the BarPercentage and Width
            return _leftPadding + (int)((note.BarPercentage / 100.0) * _width);
        }

        private int GetNoteYPosition(NoteDisplayInformation note)
        {

            // Convert to zero based index
            var stringIndex = note.StringNumber - 1;

            // Put Note on string, add spacing for each string
            return _topPadding  + (_stringSpacing * stringIndex);
        }
    }
}