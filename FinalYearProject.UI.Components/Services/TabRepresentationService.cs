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

        public void LoadNewTuningScheme(TuningScheme newScheme)
        {
            // TODO: Add Validation to ensure the scheme is good
            Settings.TuningScheme = newScheme;
        }
    }
}