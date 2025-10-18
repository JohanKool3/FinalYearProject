using FinalYearProject.UI.Components.Models;
using FinalYearProject.UI.Components.Services;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements
{
    public partial class TabBar(TabRepresentationSettingsService settingsService)
    {
        /// <summary>
        /// The number of the bar in the sequence.
        /// </summary>
        [Parameter]
        public int BarNumber { get; set; }

        /// <summary>
        /// Notes for this Bar
        /// </summary>
        [Parameter]
        public List<NoteDisplayInformation> Notes { get; set; } = [];
        
        
        public TabRepresentationSettingsService SettingsService { get; } = settingsService;

        private int _width => SettingsService.GetBarWidth(Notes);

        private int _height => SettingsService.GetBarHeight();
    }
}