using FinalYearProject.UI.Components.Models.Settings;
using FinalYearProject.UI.Components.Services;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements.BottomBar.NoteDuration
{
    public partial class GroupedDuration(TabRepresentationService representationService)
    {
        public RepresentationSettings Settings { get; }
           = representationService.Settings;

        #region Parameters

        /// <summary>
        /// Where this note duration should be drawn on the X Axis
        /// </summary>
        [Parameter, EditorRequired]
        public int XPosition { get; set; }

        /// <summary>
        /// Where this note duration should be drawn on the Y Axis (within
        /// the bottom bar section)
        /// </summary>
        [Parameter]
        public int YPosition { get; set; }

        /// <summary>
        /// Where the next note duration should be drawn on the X Axis
        /// </summary>
        [Parameter, EditorRequired]
        public int NextNoteXPosition { get; set; }

        [Parameter, EditorRequired]
        public int Divisions { get; set; }

        #endregion

        #region Settings
        private int _height
            => Settings
                .BottomBar
                .Height;

        private int _noteSpacing
            => Settings
                .Notes
                .NoteSpacing;

        #endregion

        private int _noteHeight
            => 2 * _height / 3;
    }
}