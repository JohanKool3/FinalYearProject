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
        /// Whether the Tuning is being shown for this bar.
        /// </summary>
        [Parameter, EditorRequired]
        public bool ShowTuning { get; set; } = false;

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
        /// Gets the space available for the main body of the bar, once 
        /// the PreBar section is accounted for
        /// </summary>
        private int _mainContentWidth
                => _barWidth - GetMainBodyOffset();

        /// <summary>
        /// Offset for the main body if Tuning is shown
        /// </summary>
        /// <returns></returns>
        private int GetMainBodyOffset()
            => ShowTuning ? _preBarWidth : 0;


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