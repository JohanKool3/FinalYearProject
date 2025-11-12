using FinalYearProject.Shared.Helpers;
using FinalYearProject.Shared.Models.UI.Bar;
using FinalYearProject.UI.Components.Helpers;
using FinalYearProject.UI.Components.Models.Settings;
using FinalYearProject.UI.Components.Services;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements.MainBar
{
    public partial class NoteGroup(SettingsService representationService)
    {

        public RepresentationSettings Settings { get; }
            = representationService.Settings;

        #region Parameters

        /// <summary>
        /// Holds the list of notes to display.
        /// </summary>
        [Parameter, EditorRequired]
        public NoteGroupInformation NoteGroupInformation { get; set; }

        /// <summary>
        /// The Width of this Note Group
        /// </summary>
        [Parameter, EditorRequired]
        public int Width { get; set; }

        [Parameter, EditorRequired]
        public int XPosition { get; set; }

        #endregion

        #region Settings

        /// <summary>
        /// Space to leave at the left of the notes area
        /// </summary>
        private int _leftPadding
            => Settings
                .Notes
                .LeftPadding;

        /// <summary>
        /// Space to leave at the top of the notes area
        /// </summary>
        private int _topPadding
            => Settings
                .Notes
                .TopPadding;

        private int _stringSpacing
            => Settings
                .Notes
                .StringSpacing;

        #endregion


        /// <summary>
        /// Whether Debug Mode is enabled
        /// </summary>
        private bool _debugMode
            => Settings
                .DebugMode;

        //TODO: Calculate this based on the Percentage in the 
        // NoteGroupInformation Model
        private int _startX
            => 0;

        private int _endX
            => Width;

        private int _barHeight
            => BarDimensionsHelper.GetBarHeight(Settings);

        /// <summary>
        /// Get the X Coordinate for the Note
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        private int GetNoteXPosition(NoteInformation note)
        {
            var positionWithinGroup = PositionedElementHelper
                .GetElementXPosition(note, _leftPadding, Width);

            return XPosition + positionWithinGroup;
        }

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