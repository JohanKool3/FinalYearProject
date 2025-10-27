using FinalYearProject.UI.Components.Helpers;
using FinalYearProject.UI.Components.Models.InterfaceElements.Bar;
using FinalYearProject.UI.Components.Services;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements.BottomBar
{
    public partial class GroupOfNoteLengths(TabRepresentationSettingsService settingsService)
    {
        /// <summary>
        /// The Note Group that this Element is displaying
        /// </summary>
        [Parameter, EditorRequired]
        public NoteGroupInformation NoteGroupInformation { get; set; }

        /// <summary>
        /// Width of the Total Notes Area
        /// </summary>
        [Parameter, EditorRequired]
        public int Width { get; set; }

        private int GetNoteXPosition(NoteInformation note)
            => PositionedElementHelper.GetElementXPosition(
                note,
                _leftPadding,
                Width);


        public TabRepresentationSettingsService SettingsService { get; } = settingsService;

        #region Settings

        private int _leftPadding
            => SettingsService.NoteDisplaySettings.LeftPadding;

        #endregion
    }
}