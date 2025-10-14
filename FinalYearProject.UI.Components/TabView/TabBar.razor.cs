using FinalYearProject.Shared.Models.TabRepresentation;
using FinalYearProject.UI.Components.Models;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.TabView
{
    public partial class TabBar : ComponentBase
    {

        /// <summary>
        /// Width of the entire SVG bar, in pixels
        /// </summary>
        [Parameter]
        public int Width { get; set; } = 300;

        /// <summary>
        /// Height of the entire SVG bar, in pixels
        /// </summary>
        [Parameter]
        public int Height { get; set; } = 100;

        /// <summary>
        /// Padding inside the bar, in pixels
        /// </summary>
        [Parameter]
        public int Padding { get; set; } = 10;

        /// <summary>
        /// The stroke color of the bar outline
        /// </summary>
        [Parameter]
        public string BarStroke { get; set; } = "#ccc";

        /// <summary>
        /// How many strings in this tab
        /// </summary>
        [Parameter]
        public int StringCount { get; set; } = 6;
        // TODO: Load this from a settings service

        /// <summary>
        /// The Musical Information for this representation
        /// </summary>
        [Parameter, EditorRequired]
        public required MusicalBar Bar { get; set; }

        [Parameter]
        public int FretNumberSize { get; set; } = 14;

        [Parameter, EditorRequired]
        public required bool ShowTimeSignature { get; set; }

        /// <summary>
        /// Space allocated for the time signature display
        /// </summary>
        private double _timeSignatureWidth = 40;

        /// <summary>
        /// Defines the fill color for the fret number circles
        /// </summary>
        private string _noteFill = "#fff";

        /// <summary>
        /// Defines the stroke color for the fret number circles
        /// </summary>
        private string _noteStroke = "#222";

        /// <summary>
        /// Defines the amount of space around a fret number circle
        /// </summary>
        private double _freRadiuspadding = 1.0;

        private double _notePadding => Padding * 2;

        /// <summary>
        /// What color should the strings be
        /// </summary>
        private string StringColor = "#222";

        /// <summary>
        /// How thick should each string be
        /// </summary>
        private double StringStroke = 2.0;

        /// <summary>
        /// The height of the inner area, accounting for padding
        /// </summary>
        private int _innerHeight => Height - (2 * Padding);

        private int _innerWidth => (Width + (int)GetTimeSignatureAllocatedSpace()) - (int)StringStroke * 2;

        /// <summary>
        /// Space available for notes, accounting for padding
        /// </summary>
        private int _innerNoteWidth => (ShowTimeSignature)
                ?   _innerWidth - (2*(int)_notePadding)
                :   _innerWidth;

        private List<NoteMarker> _noteMarkers = [];

        /// <summary>
        /// Gets the Y Coordinate for a given string
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private double YForString(int index)
        {
            if (StringCount <= 1)
            {
                return Padding + _innerHeight / 2.0;
            }

            double spacing = _innerHeight / (StringCount - 1);
            return Padding + index * spacing;
        }

        /// <summary>
        /// Gets the X Coordinate for a given position in the bar
        /// </summary>
        /// <param name="posFraction"></param>
        /// <returns></returns>
        private double NoteXCoordinate(double posFraction)
            => 
            GetTimeSignatureAllocatedSpace() // Account for Time Sig
            + (_notePadding + (Math.Clamp(posFraction, 0.0, 1.0) * _innerNoteWidth));

        protected override void OnInitialized()
        {
            // Convert the notes in into NoteMarkers
            var timeSignature = Bar.TimeSignature;

            //TODO: Fix bug where when top number is smaller than bottom,
            // Leads to weird spacing such as for 6/8
            // Calculate how long each beat is in the bar
            var unitDuration = 1.0 / timeSignature
                .BeatsPerMeasure;

            foreach (var note in Bar.Notes)
            {


                NoteMarker marker = new()
                {
                    StringIndex = note.StringNumber - 1,
                    Position = unitDuration * note.StartTime,
                    Fret = note.FretNumber
                };

                _noteMarkers.Add(marker);
            }
            Console.WriteLine();
        }

        private double GetCircleRadius()
            => Math.Clamp((FretNumberSize / 2) + _freRadiuspadding, 1.0, double.MaxValue);
    
        private string GetTimeSignatureString()
            => $"{Bar.TimeSignature.BeatsPerMeasure}";

        private double GetTimeSignatureAllocatedSpace()
            => (ShowTimeSignature)
            ? Padding + _timeSignatureWidth / 2 
            : 0;
    }
}