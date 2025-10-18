using FinalYearProject.Shared.Models.TabRepresentation;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements.Bar
{
    public partial class BarTimeSignature
    {
        [Parameter, EditorRequired]
        public required TimeSignature TimeSignature { get; set; }

        [Parameter]
        public int XPosition { get; set; } = 0;

        [Parameter]
        public int YPosition { get; set; } = 0;

        [Parameter]
        public int FontSize { get; set; } = 24;
    }
}