using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements
{
    public partial class StaticProgressBar
    {

        /// <summary>
        /// Must be a value between 0 and 100
        /// </summary>
        [Parameter, EditorRequired]
        public int Value { get; set; }

        private int animatedValue = 0;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                int duration = 800; // ms (match CSS)
                int steps = Value;
                int delay = duration / steps;

                for (int i = 1; i <= Value; i++)
                {
                    animatedValue = i;
                    StateHasChanged();
                }
            }
        }
    }
}