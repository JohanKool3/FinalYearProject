using FinalYearProject.Shared.Models.UI;
using FinalYearProject.Shared.Models.UI.Bar;
using FinalYearProject.UI.Components.Helpers;
using FinalYearProject.UI.Components.InterfaceElements.MainBar;
using FinalYearProject.UI.Components.Models.Settings;
using FinalYearProject.UI.Components.Services;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements
{
    public partial class BarMainBody(TabRepresentationService representationService) : ComponentBase
    {

        #region Parameters

        /// <summary>
        /// Whether the Time Signature is being shown for this bar.
        /// </summary>
        [Parameter, EditorRequired]
        public bool ShowTimeSignature { get; set; } = false;

        /// <summary>
        /// The information being shown for this bar.
        /// </summary>
        [Parameter, EditorRequired]
        public required BarInformation BarInformation { get; set; }

        #endregion

        public RepresentationSettings Settings { get; } = representationService.Settings;

        #region Settings

        private List<NoteGroupInformation> _noteGroups
            => BarInformation.NoteGroups;

        private int _barWidth
            => BarDimensionsHelper.GetBarWidth(_noteGroups, Settings);

        private int _barHeight
            => BarDimensionsHelper.GetBarHeight(Settings);

        #endregion
    }
}