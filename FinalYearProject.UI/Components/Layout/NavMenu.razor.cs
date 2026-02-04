using FinalYearProject.UI.Helpers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace FinalYearProject.UI.Components.Layout
{
    public partial class NavMenu(NavigationManager navigationManager)
    {
        public NavigationManager NavigationManager { get; } = navigationManager;


        #region Navigation

        private void NavigateHome(MouseEventArgs args)
        {
            NavigationManager.NavigateTo("/");
        }
        private void NavigateToSettings(MouseEventArgs args)
        {
            NavigationManager.NavigateTo("/settings");
        }
        private void NavigateToAccounts(MouseEventArgs args)
        {
            NavigationManager.NavigateTo("/account");
        }

        #endregion
    }
}