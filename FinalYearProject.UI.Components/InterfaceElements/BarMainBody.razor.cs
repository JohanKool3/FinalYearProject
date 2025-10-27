using FinalYearProject.UI.Components.InterfaceElements.MainBar;
using FinalYearProject.UI.Components.Models.InterfaceElements;
using FinalYearProject.UI.Components.Models.InterfaceElements.Bar;
using FinalYearProject.UI.Components.Services;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements
{
    public partial class BarMainBody(TabRepresentationService representationService)
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

        public TabRepresentationService RepresentationService { get; } = representationService;

        #region Settings

        private List<NoteGroupInformation> _noteGroups
            => BarInformation.NoteGroups;

        private int _barWidth
            => RepresentationService.GetBarWidth(_noteGroups);

        private int _barHeight 
            => RepresentationService.GetBarHeight();

        #endregion
    }
}