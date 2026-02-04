
using Microsoft.AspNetCore.Components;
namespace FinalYearProject.UI.Components.Pages
{
    public partial class Home(NavigationManager navigationManager)
    {
        public NavigationManager NavigationManager { get; } = navigationManager;

        private void Navigate(Guid id)
        {
            NavigationManager.NavigateTo($"/tabview/{id}");
        }

        private int GetHeight()
            => 500;

        private int GetWidth()
            => 900;

    }
}
