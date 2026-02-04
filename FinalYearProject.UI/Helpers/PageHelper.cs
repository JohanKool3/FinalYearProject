using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalYearProject.UI.Helpers
{
    public static class PageHelper
    {
        /// <summary>
        /// Determines whether the current page is the active page
        /// </summary>
        /// <param name="route"></param>
        /// <param name="navigationManager"></param>
        /// <returns></returns>
        public static bool IsActiveRoute(string route, NavigationManager navigationManager)
        {
            var current = navigationManager.ToBaseRelativePath(navigationManager.Uri);
            return current.StartsWith(route, StringComparison.OrdinalIgnoreCase);
        }
    }
}
