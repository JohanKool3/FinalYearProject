using FinalYearProject.UI.Components.Enums;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.Toolbars.Widgets
{
    public partial class ToolbarWidgetBase
    {
        [Parameter, EditorRequired]
        public required RenderFragment ChildContent { get; set; }

        [Parameter]
        public WidgetWidth WidgetWidth { get; set; } = WidgetWidth.Single;

        private string GetClass()
            =>
              WidgetWidth switch{
                  WidgetWidth.Single => "toolbar-widget-normal",
                  WidgetWidth.Double => "toolbar -widget-double",
                  WidgetWidth.Triple => "toolbar-widget-triple",
                  _ => "toolbar-widget-normal"
              };
            
        
    }
}