using FinalYearProject.UI.Components.Interfaces;
using FinalYearProject.UI.Components.Enums;
using FinalYearProject.UI.Components.Models.InterfaceElements;
using FinalYearProject.UI.Components.Models.InterfaceElements.Tab;
using FinalYearProject.UI.Components.Helpers;
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
                                    NoteType = NoteType.Grouped,
                                    FretNumber = 0,
                                    StringNumber = 6,
                                    StartPercentage = 0,
                                    EndPercentage = 25,
                                    ArticulationType= ArticulationType.None,
                                    },

                                new(){
                                    NoteType = NoteType.Grouped,
                                    FretNumber = 0,
                                    StringNumber = 6,
                                    StartPercentage = 25,
                                    EndPercentage = 50,
                                    ArticulationType= ArticulationType.None,
                                    },
                                    new(){
                                    NoteType = NoteType.Grouped,
                                    FretNumber = 0,
                                    StringNumber = 6,
                                    StartPercentage = 50,
                                    EndPercentage = 75,
                                    ArticulationType= ArticulationType.None,
                                    },
                                    new(){
                                    NoteType = NoteType.Grouped,
                                    StringNumber = 6,
                                    FretNumber = 0,
                                    StartPercentage = 75,
                                    EndPercentage = 100,
                                    ArticulationType= ArticulationType.None,
                                    },
                                ],
                            BarStartPercentage = 0,
                            BarEndPercentage = 25
                        },
                        new(){
                            Notes = [
                                new(){
                                    NoteType = NoteType.Grouped,
                                    FretNumber = 0,
                                    StringNumber = 6,
                                    StartPercentage = 0,
                                    EndPercentage = 25,
                                    ArticulationType= ArticulationType.None,
                                    },

                                new(){
                                    NoteType = NoteType.Grouped,
                                    FretNumber = 0,
                                    StringNumber = 6,
                                    StartPercentage = 25,
                                    EndPercentage = 50,
                                    ArticulationType= ArticulationType.None,
                                    },
                                    new(){
                                    NoteType = NoteType.Grouped,
                                    FretNumber = 0,
                                    StringNumber = 6,
                                    StartPercentage = 50,
                                    EndPercentage = 75,
                                    ArticulationType= ArticulationType.None,
                                    },
                                    new(){
                                    NoteType = NoteType.Grouped,
                                    StringNumber = 6,
                                    FretNumber = 0,
                                    StartPercentage = 75,
                                    EndPercentage = 100,
                                    ArticulationType= ArticulationType.None,
                                    },
                                ],
                            BarStartPercentage = 25,
                            BarEndPercentage = 50
                        },
                        new(){
                            Notes = [
                                new(){
                                    NoteType = NoteType.Grouped,
                                    FretNumber = 0,
                                    StringNumber = 6,
                                    StartPercentage = 0,
                                    EndPercentage = 25,
                                    ArticulationType= ArticulationType.None,
                                    },

                                new(){
                                    NoteType = NoteType.Grouped,
                                    FretNumber = 0,
                                    StringNumber = 6,
                                    StartPercentage = 25,
                                    EndPercentage = 50,
                                    ArticulationType= ArticulationType.None,
                                    },
                                    new(){
                                    NoteType = NoteType.Grouped,
                                    FretNumber = 0,
                                    StringNumber = 6,
                                    StartPercentage = 50,
                                    EndPercentage = 75,
                                    ArticulationType= ArticulationType.None,
                                    },
                                    new(){
                                    NoteType = NoteType.Grouped,
                                    StringNumber = 6,
                                    FretNumber = 0,
                                    StartPercentage = 75,
                                    EndPercentage = 100,
                                    ArticulationType= ArticulationType.None,
                                    },
                                ],
                            BarStartPercentage = 50,
                            BarEndPercentage = 75
                        },
                        new(){
                            Notes = [
                                new(){
                                    NoteType = NoteType.Grouped,
                                    FretNumber = 0,
                                    StringNumber = 6,
                                    StartPercentage = 0,
                                    EndPercentage = 25,
                                    ArticulationType= ArticulationType.None,
                                    },

                                new(){
                                    NoteType = NoteType.Grouped,
                                    FretNumber = 0,
                                    StringNumber = 6,
                                    StartPercentage = 25,
                                    EndPercentage = 50,
                                    ArticulationType= ArticulationType.None,
                                    },
                                    new(){
                                    NoteType = NoteType.Grouped,
                                    FretNumber = 0,
                                    StringNumber = 6,
                                    StartPercentage = 50,
                                    EndPercentage = 75,
                                    ArticulationType= ArticulationType.None,
                                    },
                                    new(){
                                    NoteType = NoteType.Grouped,
                                    StringNumber = 6,
                                    FretNumber = 0,
                                    StartPercentage = 75,
                                    EndPercentage = 100,
                                    ArticulationType= ArticulationType.None,
                                    },
                                ],
                            BarStartPercentage = 75,
                            BarEndPercentage = 100
                        }
                        ],
                },

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
        {
            // TODO: This should be done in the future within a
            // Convertor Service that converts from a file format
            // To the Display Format leaving this method
            // purely for retrieving information

            foreach (var bar in _currentTab.Bars)
            {
                var timeSignature = bar.TimeSignature;

                foreach (var group in bar.NoteGroups)
                {
                    // Calculate each groups Beat Duration
                    group.TotalGroupBeatLength = 
                        NoteGroupHelper.GetNoteGroupTotalBeatLength(
                            timeSignature, group);

                    // Calculate each note within the groups Beat Duration
                    foreach(var note in group.Notes)
                    {
                        note.NoteLength = 
                            NoteHelper.GetNoteLength(
                                note, group);
                    }
                }

            }

            return _currentTab;
        }

        /// <inheritdoc />
        public bool IsTabLoaded()
            => _currentTab is not null;

        public void LoadTabDisplayInformation(TabInformation information)
        {
            throw new NotImplementedException();
        }
    }
}
