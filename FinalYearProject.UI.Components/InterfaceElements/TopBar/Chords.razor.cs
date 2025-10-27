using FinalYearProject.UI.Components.Helpers;
using FinalYearProject.UI.Components.Models.InterfaceElements;
using FinalYearProject.UI.Components.Models.InterfaceElements.TopBar;
using FinalYearProject.UI.Components.Services;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements.TopBar
{
    public partial class Chords(TabRepresentationService representationService)
    {
        #region Parameters

        /// <summary>
        /// The Information about the Bar to display
        /// </summary>
        [Parameter, EditorRequired]
        public required BarInformation BarInformation { get; set; }

        /// <summary>
        /// Where to start the Chord display on the X Axis
        /// </summary>
        [Parameter]
        public int XPosition { get; set; }

        /// <summary>
        /// Where to start the Chord display on the Y Axis
        /// </summary>
        [Parameter]
        public int YPosition { get; set; }

        /// <summary>
        /// Width of the Top Bar
        /// </summary>
        [Parameter]
        public int Width { get; set; }

        /// <summary>
        /// How much to offset on the X Axis (for time signature and tuning)
        /// </summary>
        [Parameter, EditorRequired]
        public int XOffset { get; set; } = 0;

        /// <summary>
        /// The Row Number the chords are being displayed on
        /// </summary>
        [Parameter, EditorRequired]
        public int RowNumber { get; set; } = 0;

        #endregion

        public TabRepresentationService RepresentationService { get; }
            = representationService;

        private int GetHeight()
        {
            var height = RepresentationService
                            .Settings
                            .TopBarDisplaySettings
                            .Height;

            var rowAmount = RepresentationService
                                .Settings
                                .TopBarDisplaySettings
                                .Rows;

            return (height / rowAmount);
        }

        #region Settings

        /// <summary>
        /// The Font Size for the Chord Readout
        /// </summary>
        private int _fontSize
            => RepresentationService
                    .Settings
                    .TopBarDisplaySettings
                    .ChordReadoutFontSize;

        /// <summary>
        /// How much space to leave on the left of each note
        /// </summary>
        private int _notePadding
            => RepresentationService
                    .Settings
                    .NoteDisplaySettings
                    .LeftPadding;

        /// <summary>
        /// Whether to show the bounding box
        /// </summary>
        private bool _debugMode
            => RepresentationService
                    .Settings
                    .DebugMode;

        #endregion

        private int GetChordPosition(ChordInformation chord)
            => PositionedElementHelper
                .GetElementXPosition(chord, _notePadding, Width);
    }
}