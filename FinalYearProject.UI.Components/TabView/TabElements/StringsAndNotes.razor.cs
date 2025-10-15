using FinalYearProject.Shared.Models.TabRepresentation;
using FinalYearProject.UI.Components.Helpers;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.TabView.TabElements
{
    public partial class StringsAndNotes : ComponentBase
    {

        /// <summary>
        /// The Musical Information for this Bar
        /// </summary>
        [Parameter, EditorRequired]
        public required MusicalBar Bar { get; set; }

        /// <summary>
        /// Where the Bar starts on the X Axis
        /// </summary>
        [Parameter]
        public int StartX { get; set; } = 0;

        /// <summary>
        /// Where the Bar starts on the Y Axis
        /// </summary>
        [Parameter]
        public int StartY { get; set; } = 0;

        /// <summary>
        /// The Width of the Bar
        /// </summary>
        public int Width { get; private set; } = 0;

        /// <summary>
        /// Holds how many different start positions there are
        /// </summary>
        private int _uniqueStartPositions = 0;

        /// <summary>
        /// How Much Space to leave for the Time Signature, defaults to 0
        /// </summary>
        [Parameter]
        public int TimeSignatureSpacing { get; set; } = 0;

        /// <summary>
        /// How much space between each string
        /// </summary>
        [Parameter]
        public int StringSpacing { get; set; } = 10;

        /// <summary>
        /// How much space to leave at the top
        /// </summary>
        [Parameter]
        public int TopPadding { get; set; } = 10;

        /// <summary>
        /// How Large should each Note be 
        /// </summary>
        [Parameter]
        public int NoteSize { get; set; } = 8;

        /// <summary>
        /// How Much Space to leave between each Note
        /// </summary>
        [Parameter]
        public int NotePadding { get; set; } = 10;


        protected override void OnInitialized()
        {
            _uniqueStartPositions =
                BarInformationHelper
                .CalculateUniqueStartPositions(Bar);

            Width =
                BarInformationHelper.CalculateBarWidth(
                    TimeSignatureSpacing,
                    _uniqueStartPositions,
                    NoteSize,
                    NotePadding);
        }

        /// <summary>
        /// Gets the X Coordinate for a Note.
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        private int GetNoteXCoordinate(MusicalNote note)
            => TimeSignatureSpacing
            + NotePadding
            // Must convert _uniqueStartPositions to (n-1) as the first note is at position 0
            + (int)(note.StartTime * (_uniqueStartPositions-1) * NoteSize);

        private int GetNoteYCoordinate(MusicalNote note)
            => ((note.StringNumber - 1) * StringSpacing) + TopPadding;
    }
}