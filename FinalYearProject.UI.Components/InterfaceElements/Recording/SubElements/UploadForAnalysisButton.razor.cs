using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements.Recording.SubElements
{
    public partial class UploadForAnalysisButton
    {
        [Parameter, EditorRequired]
        public Func<Task> OnClickAsync { get; set; }
    }
}