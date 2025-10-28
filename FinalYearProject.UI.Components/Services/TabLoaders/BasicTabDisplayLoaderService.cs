using FinalYearProject.UI.Components.Interfaces;
using FinalYearProject.UI.Components.Enums;
using FinalYearProject.UI.Components.Models.InterfaceElements;
using FinalYearProject.UI.Components.Models.InterfaceElements.Tab;
namespace FinalYearProject.UI.Components.Services.TabLoaders
{
    /// <summary>
    /// Basic Tab Display Loader Service for testing and development 
    /// purposes
    /// </summary>
    public class BasicTabDisplayLoaderService : ITabDisplayLoaderService
    {
        private readonly TabInformation _currentTab = null!;

        public BasicTabDisplayLoaderService()
        {
            #region Example Data Creation
            // In the Future, this can be loaded from a file or 
            // another source
            var exampleBars = new List<BarInformation>()
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
                                    StartPercentage = 0,
                                    ArticulationType= ArticulationType.None,
                                    },

                                new(){
                                    NoteType = NoteType.Normal,
                                    FretNumber = 1,
                                    StringNumber = 6,
                                    StartPercentage = 25,
                                    ArticulationType= ArticulationType.None,
                                    },
                                    new(){
                                    NoteType = NoteType.Normal,
                                    FretNumber = 3,
                                    StringNumber = 6,
                                    StartPercentage = 50,
                                    ArticulationType= ArticulationType.None,
                                    },
                                    new(){
                                    NoteType = NoteType.Normal,
                                    StringNumber = 5,
                                    FretNumber = 0,
                                    StartPercentage = 75,
                                    ArticulationType= ArticulationType.None,
                                    },
                                ],
                            BarStartPercentage = 0,
                            BarEndPercentage = 25
                        }
                        ]
                }
            };

            #endregion

            _currentTab = new TabInformation()
            {
                Bars = exampleBars,
                Author = "John Doe",
                Title = "Sample Tab",
                Description = "This is a sample tab for testing purposes. The limit of this desription must never exceed 400"
            };
        }

        /// <inheritdoc />
        public TabInformation? GetCurrentTab()
            => _currentTab;

        /// <inheritdoc />
        public bool IsTabLoaded()
            => _currentTab is not null;

        public void LoadTabDisplayInformation(TabInformation information)
        {
            throw new NotImplementedException();
        }
    }
}
