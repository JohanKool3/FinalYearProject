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

        [Parameter]
        public bool ShowTuning { get; set; } = false;

        [Parameter]
        public bool ShowBpmMarking { get; set; } = false;

        #endregion

        /// <summary>
        /// Notes for this Bar
        /// </summary>
        private List<NoteDisplayInformation> _notes
            => BarInformation.Notes;

        #region Settings
        
        public TabRepresentationSettingsService SettingsService { get; } = settingsService;

        private int _barWidth
            => SettingsService.GetBarWidth(_notes);

        private int _barHeight => SettingsService.GetBarHeight();

        private int _totalComponentHeight
            => SettingsService.GetTotalBarHeight();

        /// <summary>
        /// How tall the Top Bar is
        /// </summary>
        private int _topBarHeight
            => SettingsService
            .TopBarDisplaySettings
            .Height;

        /// <summary>
        /// How wide the Time Signature section is
        /// </summary>
        private int _preBarWidth
            => SettingsService
            .PreBarDisplaySettings
            .TimeSignatureWidth;

        /// <summary>
        /// Gets the space available for the main body of the bar, once 
        /// the PreBar section is accounted for
        /// </summary>
        private int _mainContentWidth
                => _barWidth - GetMainBodyOffset();

        #endregion

        /// <summary>
        /// Offset for the main body if Tuning is shown
        /// </summary>
        /// <returns></returns>
        private int GetMainBodyOffset()
            => ShowTuning ? _preBarWidth : 0;

        /// <summary>
        /// Gets how wide the Top Bar should be
        /// </summary>
        /// <returns></returns>
        private int GetTopBarWidth()
            => _barWidth + GetMainBodyOffset();
    }
}