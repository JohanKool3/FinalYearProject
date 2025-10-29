using FinalYearProject.Shared.Helpers;
using FinalYearProject.Shared.Models.UI.Bar;
using FinalYearProject.UI.Components.Models.Settings;

namespace FinalYearProject.UI.Components.Helpers
{
    /// <summary>
    /// Calculates dimensions for bars Dynamically
    /// </summary>
    public static class BarDimensionsHelper
    {
        /// <summary>
        /// Returns the dynamic width of a bar based on the notes it contains
        /// </summary>
        /// <param name="noteGroups"></param>
        /// <returns></returns>
        public static int GetBarWidth(List<NoteGroupInformation> noteGroups, 
            RepresentationSettings settings)
        {
            // Get the width of each note group, and sum them together
            int totalWidth = 0;

            foreach (var group in noteGroups)
            {
                totalWidth += NoteGroupRenderingHelper
                    .GetNoteGroupWidth(settings, group);
            }
            return  totalWidth;
        }

        /// <summary>
        /// Returns how tall the bar should be based on string count and Padding
        /// </summary>
        /// <returns></returns>
        public static int GetBarHeight(RepresentationSettings settings)
              => settings.Notes.TopPadding +
                   (settings.StringCount * settings.Notes.StringSpacing);

        /// <summary>
        /// Get the height of both the bar and the top bar
        /// </summary>
        /// <returns></returns>
        public static int GetTotalBarHeight(RepresentationSettings settings)
            => GetBarHeight(settings)
            + settings.TopBar.Height
            // Account for the Bottom Bar too
            + settings.BottomBar.Height
            + settings.BottomBar.TopPadding;


    }
}
