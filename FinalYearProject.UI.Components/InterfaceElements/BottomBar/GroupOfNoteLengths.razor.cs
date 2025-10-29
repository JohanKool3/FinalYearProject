using FinalYearProject.Shared.Helpers;
using FinalYearProject.Shared.Models.UI.Bar;
using FinalYearProject.UI.Components.Models.Settings;
using FinalYearProject.UI.Components.Services;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements.BottomBar
{
    public partial class GroupOfNoteLengths(TabRepresentationService representationService)
    {
        /// <summary>
        /// The Note Group that this Element is displaying
        /// </summary>
        [Parameter, EditorRequired]
        public NoteGroupInformation NoteGroupInformation { get; set; }

        /// <summary>
        /// The X Position of this Note Group within the Bar
        /// </summary>
        [Parameter, EditorRequired]
        public int XPosition { get; set; }

        /// <summary>
        /// Width of the Bar
        /// </summary>
        [Parameter, EditorRequired]
        public int Width { get; set; }


        private int GetNoteXPosition(NoteInformation note)
        {
            // Get Position Within the Group
            var groupPosition = PositionedElementHelper.GetElementXPosition(
                note,
                _leftPadding,
                Width);

            return XPosition + groupPosition;
        }

        public RepresentationSettings Settings { get; } = representationService.Settings;

        #region Settings

        private int _leftPadding
            => Settings
                .Notes
                .LeftPadding;

        #endregion
    }
}