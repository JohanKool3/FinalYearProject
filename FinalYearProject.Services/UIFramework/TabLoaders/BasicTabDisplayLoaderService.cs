using FinalYearProject.Services.Interfaces;
using FinalYearProject.Shared.Models.UI;
using FinalYearProject.Shared.Enums;
using FinalYearProject.Shared.Helpers;
using FinalYearProject.Shared.Models.UI.Bar;

namespace FinalYearProject.Services.UIFramework.TabLoaders
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

            List<NoteInformation> notes = [
            new(){
                FretNumber = 0,
                StringNumber = 6,
                StartPercentage = 0,
                EndPercentage = 25,
                Properties = new(){
                    Articulation = ArticulationType.None,
                    Type = NoteType.Normal,
                    IsGrouped = true
                }
            },
            new()
            {
                FretNumber = 0,
                StringNumber = 6,
                StartPercentage = 25,
                EndPercentage = 50,
                Properties = new(){
                    Articulation = ArticulationType.None,
                    Type = NoteType.Normal,
                    IsGrouped = true
                }
            },
            new()
            {
                FretNumber = 0,
                StringNumber = 6,
                StartPercentage = 50,
                EndPercentage = 75,
                Properties = new(){
                    Articulation = ArticulationType.None,
                    Type = NoteType.Normal,
                    IsGrouped = true
                }
            },
            new()
            {
                StringNumber = 6,
                FretNumber = 0,
                StartPercentage = 75,
                EndPercentage = 100,
                Properties = new(){
                    Articulation = ArticulationType.None,
                    Type = NoteType.Normal,
                    IsGrouped = true
                }
            }];

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
                            Notes = notes,
                            BarStartPercentage = 0,
                            BarEndPercentage = 25
                        },
                        new(){
                            Notes = notes,
                            BarStartPercentage = 25,
                            BarEndPercentage = 50
                        },
                        new(){
                            Notes = notes,
                            BarStartPercentage = 50,
                            BarEndPercentage = 75
                        },
                        new(){
                            Notes = notes,
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
                    foreach (var note in group.Notes)
                    {
                        note.Properties = new()
                        {
                            Length = NoteHelper.GetNoteLength(note, group)
                        };

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
