using FinalYearProject.Services.Interfaces;
using Microsoft.AspNetCore.Components.Web;
namespace FinalYearProject.UI.Components.Pages
{
    public partial class TabView(ITabLoaderService tabLoader)
    {
        private async Task LoadTabAsync(MouseEventArgs args)
        {
            var id = Guid.Empty;

            var tab = await tabLoader.GetTabAsync(id, CancellationToken.None);

            Console.WriteLine();
        }

    }
}
