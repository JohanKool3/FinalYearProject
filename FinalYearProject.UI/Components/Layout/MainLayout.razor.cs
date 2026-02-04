using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.Layout
{
    public partial class MainLayout(NavigationManager navigation)
    {
        public NavigationManager Navigation { get; } = navigation;

        bool ShowToolbar =>
            Navigation.ToBaseRelativePath(Navigation.Uri)
                .StartsWith("tabview", StringComparison.OrdinalIgnoreCase);
    }
}