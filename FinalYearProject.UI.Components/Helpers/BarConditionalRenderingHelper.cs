using FinalYearProject.Shared.Models.UI;

namespace FinalYearProject.UI.Components.Helpers
{
    /// <summary>
    /// Used to determine whether to render certain parts of a Bar
    /// </summary>
    internal static class BarConditionalRenderingHelper
    {
        /// <summary>
        /// Determines whether to render the time signature for the current bar
        /// </summary>
        /// <param name="previousBar"></param>
        /// <param name="currentBar"></param>
        /// <returns></returns>
        internal static bool RenderTimeSignature(BarInformation? previousBar,
            BarInformation currentBar)
        {
            // Always render if there is no previous bar
            if (previousBar == null)
            {
                return true;
            }

            // Render if the time signatures are different
            return !previousBar.TimeSignature.Equals(currentBar.TimeSignature);
        }

        /// <summary>
        /// Determines whether to render the BPM for the current bar.
        /// </summary>
        /// <param name="previousBar"></param>
        /// <param name="currentBar"></param>
        /// <returns></returns>
        /// <remarks>
        /// Will only render the Bpm marking if it is different from the previous bar's Bpm 
        /// or if there is no previous bar.
        /// </remarks>
        internal static bool RenderBpm(BarInformation? previousBar,
            BarInformation currentBar)
        {
            // Always render if there is no previous bar
            if (previousBar == null)
            {
                return true;
            }
            // Render if the BPMs are different
            return previousBar.Bpm != currentBar.Bpm;
        }
    }
}
