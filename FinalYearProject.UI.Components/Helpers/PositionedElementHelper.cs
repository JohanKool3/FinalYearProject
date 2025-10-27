using FinalYearProject.UI.Components.Interfaces;

namespace FinalYearProject.UI.Components.Helpers
{
    internal static class PositionedElementHelper
    {
        /// <summary>
        /// Get the X Coordinate for the positioned Element
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        public static int GetElementXPosition(IPositionedElement note, 
            int leftPadding,
            int width)
        {
            // Calculate the position based on the Start Percentage and Width
            return leftPadding + (int)(note.StartPercentage / 100.0 * width);
        }
    }
}
