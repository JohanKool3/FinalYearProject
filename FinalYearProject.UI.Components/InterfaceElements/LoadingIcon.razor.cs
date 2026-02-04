using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements
{
    public partial class LoadingIcon
    {

        [Parameter]
        public int Width { get; set; } = 64;

        [Parameter]
        public int Height { get; set; } = 64;
    }
}