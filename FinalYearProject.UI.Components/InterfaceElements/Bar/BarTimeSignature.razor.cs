using FinalYearProject.Shared.Models.TabRepresentation;
using FinalYearProject.UI.Components.Services;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements.Bar
{
    public partial class BarTimeSignature(TabRepresentationSettingsService settingsService)
    {

        /// <summary>
        /// Logical Representation of the Time Signature to display
        /// </summary>
        [Parameter, EditorRequired]
        public required TimeSignature TimeSignature { get; set; }

        /// <summary>
        /// Top Left X Position of the Time Signature
        /// </summary>
        [Parameter]
        public int XPosition { get; set; } = 0;

        /// <summary>
        /// Top Left Y Position of the Time Signature
        /// </summary>
        [Parameter]
        public int YPosition { get; set; } = 0;

        /// <summary>
        /// How Large the Time Signature should be rendered
        /// </summary>
        [Parameter]
        public int FontSize { get; set; } = 24;
        public TabRepresentationSettingsService SettingsService { get; } = settingsService;

        private int _width
            => SettingsService.TimeSignatureDisplaySettings.Width;

        #region Notes Display Settings

        // The purpose of these settings is to give the 
        // user the feeling that the time signature is still
        // part of the bar area, even though it is rendered
        // separately.
        private int _topPadding
            => SettingsService.NoteDisplaySettings.TopPadding;

        private int _stringSpacing
            => SettingsService.NoteDisplaySettings.StringSpacing;

        #endregion

        /// <summary>
        /// Adjusts the X Position so that the Time Signature is centered
        /// </summary>
        /// <returns></returns>
        private int GetAdjustedXPosition()
            => XPosition - (FontSize / 3);

        /// <summary>
        /// Adjusts the Y Position so that the Time Signature is centered
        /// </summary>
        /// <returns></returns>
        private int GetAdjustedYPosition()
            => YPosition - (FontSize / 3);
    }
}