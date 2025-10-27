using FinalYearProject.UI.Components.Interfaces;

namespace FinalYearProject.UI.Components.Helpers
{
    internal static class BarElementPositioningHelper
    {
        /// <summary>
        /// Get the X Coordinate for the positioned Element
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        public static int GetElementXPositionInBar(IPositionedElement note, 
            int leftPadding,
            int width)
        {
            // Calculate the position based on the BarPercentage and Width
            return leftPadding + (int)(note.BarPercentage / 100.0 * width);
        }
    }
}
