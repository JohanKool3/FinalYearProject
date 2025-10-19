using FinalYearProject.UI.Components.Models;
using FinalYearProject.UI.Components.Services;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements
{
    public partial class TabBar(TabRepresentationSettingsService settingsService)
    {
        #region Parameters

        /// <summary>
        /// The number of the bar in the sequence.
        /// </summary>
        [Parameter]
        public int BarNumber { get; set; }

        /// <summary>
        /// Holds the information needed to display this Bar
        /// </summary>
        [Parameter]
        public BarDisplayInformation BarInformation { get; set; } = new();

        /// <summary>
        /// Determines whether the Time Signature should be displayed for this Bar
        /// </summary>
        [Parameter]
        public bool ShowTimeSignature { get; set; } = false;

        #endregion

        /// <summary>
        /// Notes for this Bar
        /// </summary>
        private List<NoteDisplayInformation> _notes
            => BarInformation.Notes;

        #region Rendering Settings
        public TabRepresentationSettingsService SettingsService { get; } = settingsService;

        private int _width => SettingsService.GetBarWidth(_notes);

        private int _height => SettingsService.GetBarHeight();

        private int _timeSignatureWidth
            => SettingsService.TimeSignatureDisplaySettings.Width;

        #endregion
    }
}