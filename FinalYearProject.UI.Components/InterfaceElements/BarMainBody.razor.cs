using FinalYearProject.UI.Components.InterfaceElements.Bar;
using FinalYearProject.UI.Components.Models;
using FinalYearProject.UI.Components.Services;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements
{
    public partial class BarMainBody(TabRepresentationSettingsService settingsService)
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
        public required BarDisplayInformation BarInformation { get; set; }



        #endregion

        public TabRepresentationSettingsService SettingsService { get; } = settingsService;

        #region Settings

        private List<NoteDisplayInformation> _notes
            => BarInformation.Notes;

        private int _barWidth
            => SettingsService.GetBarWidth(_notes);

        private int _barHeight => SettingsService.GetBarHeight();


        /// <summary>
        /// How wide the Tuning section is
        /// </summary>
        private int _preBarWidth
            => SettingsService
            .PreBarDisplaySettings
            .TimeSignatureWidth;

        #endregion
    }
}