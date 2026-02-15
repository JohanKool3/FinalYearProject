using FinalYearProject.UI.Components.InterfaceElements.Recording;
using FinalYearProject.UI.Components.Services;

namespace FinalYearProject.UI.Components
{
    public partial class Toolbar
    {
        /// <summary>
        /// Whether the toolbar is expanded or not
        /// </summary>
        private bool IsExpanded = true;

        private Task PlaybackStateChanged()
            => InvokeAsync(StateHasChanged);


        private void ToggleExpand()
            => IsExpanded = !IsExpanded;

        private string GetExpanded()
            => IsExpanded switch
            {
                true => "expanded",
                false => "collapsed"
            };


        private string GetIcon()
            => IsExpanded switch
            {
                true => "collapse.svg",
                false => "expand.svg"
            };
    }
}