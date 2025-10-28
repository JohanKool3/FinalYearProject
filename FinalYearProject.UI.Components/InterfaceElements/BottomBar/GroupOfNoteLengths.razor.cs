using FinalYearProject.UI.Components.Helpers;
using FinalYearProject.UI.Components.Models.InterfaceElements.Bar;
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


        private int GetNoteXPosition(NoteInformation note)
            => PositionedElementHelper.GetElementXPosition(
                note,
                _leftPadding,
                NoteGroupHelper.GetNoteGroupWidth(Settings,
                    NoteGroupInformation));


        public RepresentationSettings Settings { get; } = representationService.Settings;

        #region Settings

        private int _leftPadding
            => Settings
                .Notes
                .LeftPadding;

        #endregion
    }
}