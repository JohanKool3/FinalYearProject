using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements.Bar
{
    public partial class BarLine
    {

        [Parameter, EditorRequired]
        public int XPosition { get; set; }

        [Parameter, EditorRequired]
        public int StartYPosition { get; set; }

        [Parameter, EditorRequired]
        public int EndYPosition { get; set; }
    }
}