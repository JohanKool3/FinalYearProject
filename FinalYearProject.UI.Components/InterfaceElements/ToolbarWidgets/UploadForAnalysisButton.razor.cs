using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements.ToolbarWidgets
{
    public partial class UploadForAnalysisButton
    {
        /// <summary>
        /// Notify the parent component that a change has occurred.
        /// </summary>
        [Parameter, EditorRequired]
        public Func<Task> NotifyParentOfChange { get; set; } = null!;

        private Task UploadAsync()
        {
            return NotifyParentOfChange();
        }
    }
}