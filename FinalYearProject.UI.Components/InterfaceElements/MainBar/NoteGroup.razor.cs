using FinalYearProject.UI.Components.Helpers;
using FinalYearProject.UI.Components.Models.InterfaceElements.Bar;
using FinalYearProject.UI.Components.Services;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements.MainBar
{
    public partial class NoteGroup(TabRepresentationService representationService)
    {

        public TabRepresentationService RepresentationService { get; }
            = representationService;

        #region Parameters

        /// <summary>
        /// Holds the list of notes to display.
        /// </summary>
        [Parameter, EditorRequired]
        public NoteGroupInformation NoteGroupInformation { get; set; }

        /// <summary>
        /// The Width of the Notes Area
        /// </summary>
        [Parameter, EditorRequired]
        public int Width { get; set; }

        #endregion


        #region Settings

        /// <summary>
        /// Space to leave at the left of the notes area
        /// </summary>
        private int _leftPadding
            => RepresentationService
                .Settings
                .Notes
                .LeftPadding;

        /// <summary>
        /// Space to leave at the top of the notes area
        /// </summary>
        private int _topPadding
            => RepresentationService.Settings
                .Notes
                .TopPadding;

        private int _stringSpacing
            => RepresentationService
                .Settings
                .Notes
                .StringSpacing;

        #endregion

        /// <summary>
        /// Get the X Coordinate for the Note
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        private int GetNoteXPosition(NoteInformation note)
            => PositionedElementHelper
                .GetElementXPosition(note, _leftPadding, Width);

        /// <summary>
        /// Get the Y Coordinate for the Note
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        private int GetNoteYPosition(NoteInformation note)
        {

            // Convert to zero based index
            var stringIndex = note.StringNumber - 1;

            // Put Note on string, add spacing for each string
            return _topPadding + _stringSpacing * stringIndex;
        }
    }
}