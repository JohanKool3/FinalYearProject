using FinalYearProject.UI.Components.Models.InterfaceElements;
using FinalYearProject.UI.Components.Models.InterfaceElements.Bar;
using FinalYearProject.UI.Components.Services;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements
{
    public partial class FullBar(TabRepresentationService representationService)
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
        public BarInformation BarInformation { get; set; } = new();

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
        private List<NoteGroupInformation> _noteGroups
            => BarInformation.NoteGroups;

        #region Settings

        public TabRepresentationService RepresentationService { get; } = representationService;

        private int _barWidth
            => RepresentationService
            .GetBarWidth(_noteGroups);

        private int _barHeight
            => RepresentationService
            .GetBarHeight();

        private int _totalComponentHeight
            => RepresentationService
            .GetTotalBarHeight();

        /// <summary>
        /// How tall the Top Bar is
        /// </summary>
        private int _topBarHeight
            => RepresentationService
                .Settings
                .TopBar
                .Height;

        /// <summary>
        /// How wide the Tuning section is
        /// </summary>
        private int _preBarWidth
            => RepresentationService
                .Settings
                .PreBar
                .TimeSignatureWidth;

        private int _bottomBarYPadding
          => RepresentationService
                .Settings
                .BottomBar
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