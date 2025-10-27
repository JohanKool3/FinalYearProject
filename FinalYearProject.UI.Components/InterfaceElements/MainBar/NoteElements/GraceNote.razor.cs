using FinalYearProject.UI.Components.Models.InterfaceElements.Bar;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements.MainBar.NoteElements
{
    public partial class GraceNote
    {
        /// <summary>
        /// The Note to display.
        /// </summary>
        [Parameter, EditorRequired]
        public required NoteInformation Note { get; set; }

        /// <summary>
        /// The X Position of the Note
        /// </summary>
        [Parameter]
        public int XPosition { get; set; }

        /// <summary>
        /// The Y Position of the Note
        /// </summary>
        [Parameter]
        public int YPosition { get; set; }

        /// <summary>
        /// How big the Note should be.
        /// </summary>
        [Parameter]
        public int Size { get; set; }

        /// <summary>
        /// Whether to draw the outline of the Note.
        /// </summary>
        [Parameter]
        public bool DrawOutline { get; set; } = true;
    }
}