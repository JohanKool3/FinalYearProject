using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements.MainBar
{
    public partial class BarLine
    {
        /// <summary>
        /// Where the Bar Line should be drawn on the X Axis
        /// </summary>
        [Parameter, EditorRequired]
        public int XPosition { get; set; }

        /// <summary>
        /// Where the Bar Line should start on the Y Axis
        /// </summary>
        [Parameter, EditorRequired]
        public int StartYPosition { get; set; }

        /// <summary>
        /// Where the Bar Line should end on the Y Axis
        /// </summary>
        [Parameter, EditorRequired]
        public int EndYPosition { get; set; }
    }
}