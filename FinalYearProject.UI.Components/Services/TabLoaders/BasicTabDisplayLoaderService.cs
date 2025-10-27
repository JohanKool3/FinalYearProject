using FinalYearProject.UI.Components.InterfaceElements.Bar;
using FinalYearProject.UI.Components.Interfaces;
using FinalYearProject.UI.Components.Models;
using FinalYearProject.UI.Components.Enums;
namespace FinalYearProject.UI.Components.Services.TabLoaders
{
    /// <summary>
    /// Basic Tab Display Loader Service for testing and development 
    /// purposes
    /// </summary>
    public class BasicTabDisplayLoaderService : ITabDisplayLoaderService
    {
        private readonly TabDisplayInformation _currentTab = null!;

        public BasicTabDisplayLoaderService()
        {
            #region Example Data Creation
            // In the Future, this can be loaded from a file or 
            // another source
            var exampleBars = new List<BarDisplayInformation>()
            {
                new()
                {
                    Bpm = 160,
                    TimeSignature = new(4,4),
                    NoteGroups = [
                        new(){
                            Notes = [
                                new(){
                                    NoteType = NoteType.Normal,
                                    FretNumber = 0,
                                    StringNumber = 6,
                                    BarPercentage = 0,
                                    ArticulationType= ArticulationType.None,
                                    },

                                new(){
                                    NoteType = NoteType.Normal,
                                    FretNumber = 1,
                                    StringNumber = 6,
                                    BarPercentage = 6,
                                    ArticulationType= ArticulationType.None,
                                    },
                                    new(){
                                    NoteType = NoteType.Normal,
                                    FretNumber = 3,
                                    StringNumber = 6,
                                    BarPercentage = 12,
                                    ArticulationType= ArticulationType.None,
                                    },
                                    new(){
                                    NoteType = NoteType.Normal,
                                    StringNumber = 5,
                                    FretNumber = 0,
                                    BarPercentage = 18,
                                    ArticulationType= ArticulationType.None,
                                    },
                                ]
                        }
                        ]
                }
            };

            #endregion

            _currentTab = new TabDisplayInformation()
            {
                Bars = exampleBars,
                Author = "John Doe",
                Title = "Sample Tab",
                Description = "This is a sample tab for testing purposes. The limit of this desription must never exceed 400"
            };
        }

        /// <inheritdoc />
        public TabDisplayInformation? GetCurrentTab()
            => _currentTab;

        /// <inheritdoc />
        public bool IsTabLoaded()
            => _currentTab is not null;

        public void LoadTabDisplayInformation(TabDisplayInformation information)
        {
            throw new NotImplementedException();
        }
    }
}
