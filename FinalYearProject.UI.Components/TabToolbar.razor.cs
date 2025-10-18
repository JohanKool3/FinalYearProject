using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components
{
    public partial class TabToolbar
    {
        [Parameter]
        public required RenderFragment? ChildContent { get; set; } = null;
    }
}