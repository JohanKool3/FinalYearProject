using FinalYearProject.UI.Components.Models;


namespace FinalYearProject.UI.Components
{
    public partial class Toolbar(ToolbarSettings settings)
    {
        public ToolbarSettings Settings { get; } = settings;

        private Task PlaybackStateChanged()
            => InvokeAsync(StateHasChanged);


        private void ToggleExpand()
            => Settings.IsExpanded = !Settings.IsExpanded;

        private string GetExpanded()
            => Settings.IsExpanded switch
            {
                true => "expanded",
                false => "collapsed"
            };


        private string GetIcon()
            => Settings.IsExpanded switch
            {
                true => "collapse.svg",
                false => "expand.svg"
            };
    }
}