using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.TabView.TabElements
{
    public partial class Notes
    {

        /// <summary>
        /// The Total Height of the Notes Section
        /// </summary>
        [Parameter]
        public int Height { get; set; } = 0;

        /// <summary>
        /// The Total Width of the Notes Section
        /// </summary>
        [Parameter]
        public int Width { get; set; } = 0;

        /// <summary>
        /// How much Padding to place at the Top of the Notes Section
        /// </summary>
        [Parameter]
        public int TopPadding { get; set; } = 0;

        /// <summary>
        /// How much Padding to place at the Left of the Notes Section
        /// </summary>
        [Parameter]
        public int LeftPadding { get; set; } = 10;

        /// <summary>
        /// How much of the string should be cutout when there is a
        /// note over it. This is a radius for a circle.
        /// </summary>
        [Parameter]
        public int NoteCutoutRadius { get; set; } = 7;
    }
}