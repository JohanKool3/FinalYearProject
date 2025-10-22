using FinalYearProject.UI.Components.Models;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements.BottomBar
{
    public partial class NoteLengths
    {
        /// <summary>
        /// The Information to be shown
        /// </summary>
        [Parameter]
        public required BarDisplayInformation BarInformation { get; set; }
    }
}