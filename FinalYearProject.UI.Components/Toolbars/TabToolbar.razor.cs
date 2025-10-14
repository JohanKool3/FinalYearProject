using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.Toolbars
{
    public partial class TabToolbar
    {
        [Parameter]
        public required RenderFragment? ChildContent { get; set; } = null;
    }
}