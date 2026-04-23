using FinalYearProject.UI.Components.Models;
using Microsoft.AspNetCore.Components;


namespace FinalYearProject.UI.Components
{
    public partial class Toolbar(ToolbarSettings settings,
        NavigationManager navigationManager)
    {
        private readonly NavigationManager _navigationManager = navigationManager;

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
        private void NavigateToResults(Guid pieceId)
        {
            _navigationManager.NavigateTo($"/results/{pieceId}");
        }
    }
}