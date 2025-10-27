using FinalYearProject.UI.Components.Models;
using FinalYearProject.UI.Components.Models.InterfaceElements.Bar;
using FinalYearProject.UI.Components.Models.Settings;

namespace FinalYearProject.UI.Components.Services
{
    /// <summary>
/// Holds settings related to the display
    /// </summary>
  public class TabRepresentationService
    {
    public RepresentationSettings Settings { get; private set; }
      = new();

        /// <summary>
        /// Returns the dynamic width of a bar based on the notes it contains
     /// </summary>
        /// <param name="noteGroups"></param>
        /// <returns></returns>
 public int GetBarWidth(List<NoteGroupInformation> noteGroups)
  {
// Get all the notes in each note Group
            var notes = noteGroups
     .SelectMany(x => x.Notes);

            // Calculate how many different start positions there are
            var distinctPositions = notes
    .Select(n => n.StartPercentage)
                .Distinct().Count();

  var leftPadding = Settings.NoteDisplaySettings.LeftPadding;
            
  // Multiply by 2 for start and  the end padding
         return 2 * leftPadding + (distinctPositions * Settings.NoteDisplaySettings.NoteSpacing);
        }

        /// <summary>
        /// Returns how tall the bar should be based on string count and Padding
     /// </summary>
        /// <returns></returns>
        public int GetBarHeight()
  => Settings.NoteDisplaySettings.TopPadding +
       (Settings.StringCount * Settings.NoteDisplaySettings.StringSpacing);

  /// <summary>
        /// Get the height of both the bar and the top bar
        /// </summary>
     /// <returns></returns>
        public int GetTotalBarHeight()
            => GetBarHeight() 
            + Settings.TopBarDisplaySettings.Height

   // Account for the Bottom Bar too
      + Settings.BottomBarDisplaySettings.Height
    + Settings.BottomBarDisplaySettings.TopPadding;

        public void LoadNewTuningScheme(TuningScheme newScheme)
    {
       // TODO: Add Validation to ensure the scheme is good
            Settings.TuningScheme = newScheme;
        }
  }
}