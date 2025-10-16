using FinalYearProject.UI.Components.Models;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.TabView.TabElements
{
    public partial class Notes
    {
        #region Parameters

        /// <summary>
        /// The Total Height of the Notes Section
        /// </summary>
        [Parameter]
        public int Height { get; set; } = 0;

        /// <summary>
        /// The Total Width of the Notes Section
        /// </summary>
        [Parameter]
        public int Width { get; set; } = 0;

        /// <summary>
        /// How much Padding to place at the Top of the Notes Section
        /// </summary>
        [Parameter]
        public int TopPadding { get; set; } = 0;

        /// <summary>
        /// How much Padding to place at the Left of the Notes Section
        /// </summary>
        [Parameter]
        public int LeftPadding { get; set; } = 10;

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
    
        private int GetNotePosition(NoteDisplayInformation note)
        {
            // Calculate the position based on the BarPercentage and Width
            return (int)((note.BarPercentage / 100.0) * Width) + LeftPadding;
        }
    }
}