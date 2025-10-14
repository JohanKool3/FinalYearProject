using FinalYearProject.Shared.Models.TabRepresentation;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.TabView
{
    public partial class TabBar
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

        private int _innerWidth => Width - (int)StringStroke;

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
    }
}