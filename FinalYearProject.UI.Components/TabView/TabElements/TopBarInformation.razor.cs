using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.TabView.TabElements
{
    public partial class TopBarInformation
    {
        #region Parameters
        /// <summary>
        /// The Number of the bar to display.
        /// </summary>
        [Parameter]
        public int BarNumber { get; set; } = 0;

        [Parameter]
        public int LeftPadding { get; set; } = 5;

        [Parameter]
        public int TopPadding { get; set; } = 10;

        [Parameter]
        public int FontSize { get; set; } = 12;

        #endregion
    }
}