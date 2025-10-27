using FinalYearProject.UI.Components.Models;
using FinalYearProject.UI.Components.Services;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements
{
    public partial class FullBar(TabRepresentationSettingsService settingsService)
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
        public bool ShowBpmMarking { get; set; } = false;

        #endregion

        /// <summary>
        /// Notes for this Bar
        /// </summary>
        private List<NoteGroupDisplayInformation> _noteGroups
            => BarInformation.NoteGroups;

        #region Settings

        public TabRepresentationSettingsService SettingsService { get; } = settingsService;

        private int _barWidth
            => SettingsService.GetBarWidth(_noteGroups);

        private int _barHeight
            => SettingsService.GetBarHeight();

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
        /// How wide the Tuning section is
        /// </summary>
        private int _preBarWidth
            => SettingsService
            .PreBarDisplaySettings
            .TimeSignatureWidth;

        private int _bottomBarYPadding
          => SettingsService
            .BottomBarDisplaySettings
            .TopPadding;

        #endregion

        /// <summary>
        /// How much to offset the Prebar section
        /// </summary>
        /// <returns></returns>
        private int GetPrebarOffset()
            => ShowTimeSignature ? _preBarWidth : 0;

        private int GetBottomBarYOffset()
            => _topBarHeight + _barHeight + _bottomBarYPadding;
    }
}