using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements.Recording.Results
{
    public partial class ResultsGraphic
    {
        [Parameter, EditorRequired]
        public string Title { get; set; }


        [Parameter]
        public float Value { get; set; } // 0% ->  100%

        /// <summary>
        /// The Height and Width of the Graphic
        /// </summary>
        [Parameter]
        public float Size { get; set; } = 120;


        /// <summary>
        /// How big the Lines will be
        /// </summary>
        [Parameter]
        public float StrokeWidth { get; set; } = 12;

        private float Radius => (Size - StrokeWidth) / 2;
        
        private float Circumference => 2 * MathF.PI * Radius;

        private float ClampedValue => Math.Clamp(Value, 0f, 1f);


        private int GetCenterCoordinate()
            => (int)(Size / 2);
    }
}