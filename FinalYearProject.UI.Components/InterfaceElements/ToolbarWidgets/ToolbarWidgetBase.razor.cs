using FinalYearProject.UI.Components.Enums;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements.ToolbarWidgets
{
    public partial class ToolbarWidgetBase
    {
        [Parameter, EditorRequired]
        public required RenderFragment ChildContent { get; set; }

        [Parameter]
        public WidgetWidth WidgetWidth { get; set; } = WidgetWidth.Single;

        private string GetSizeClass()
            =>
              WidgetWidth switch{
                  WidgetWidth.Single => "normal",
                  WidgetWidth.Double => "double",
                  WidgetWidth.Triple => "triple",
                  _ => "normal"
              };
            
        
    }
}