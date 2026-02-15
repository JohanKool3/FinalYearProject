using FinalYearProject.Services.Interfaces;
using FinalYearProject.Shared.Models.UI;
using FinalYearProject.Shared.Enums;
using FinalYearProject.Shared.Helpers;
using FinalYearProject.Shared.Models.UI.Bar;
using FinalYearProject.Services.Helpers;

namespace FinalYearProject.Services.UI.TabLoaders
{
    /// <summary>
    /// Basic Tab Display Loader Service for testing and development 
    /// purposes
    /// </summary>
    public class BasicTabLoaderService : ITabLoaderService
    {
        private readonly TabInformation _currentTab = null!;

        public BasicTabLoaderService()
        {
            #region Example Data Creation

            List<NoteInformation> notes = [
            new(){
                FretNumber = 0,
                StringNumber = 6,
                StartPercentage = 0,
                EndPercentage = 25,
                Properties = new(){
                    Articulation = ArticulationType.PalmMute,
                    Type = NoteType.Normal,
                    IsGrouped = true,
                }
            },
            new(){
                FretNumber = 2,
                StringNumber = 5,
                StartPercentage = 0,
                EndPercentage = 25,
                Properties = new(){
                    Articulation = ArticulationType.PalmMute,
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
                    Articulation = ArticulationType.PalmMute,
                    Type = NoteType.Normal,
                    IsGrouped = true
                }
            },
            new()
            {
                FretNumber = 2,
                StringNumber = 5,
                StartPercentage = 25,
                EndPercentage = 50,
                Properties = new(){
                    Articulation = ArticulationType.PalmMute,
                    Type = NoteType.Normal,
                    IsGrouped = true
                }
            },
            new()
            {
                FretNumber = 0,
                StringNumber = 6,
                StartPercentage = 50,
                EndPercentage = 100,
                Properties = new(){
                    Articulation = ArticulationType.PalmMute,
                    Type = NoteType.Normal,
                    IsGrouped = true
                }
            },
            new()
            {
                FretNumber = 2,
                StringNumber = 5,
                StartPercentage = 50,
                EndPercentage = 100,
                Properties = new(){
                    Articulation = ArticulationType.PalmMute,
                    Type = NoteType.Normal,
                    IsGrouped = true
                }
            }];

            List<NoteInformation> notes2 = [
                new()
            {
                FretNumber = 0,
                StringNumber = 6,
                StartPercentage = 0,
                EndPercentage = 25,
                Properties = new()
                {
                    Articulation = ArticulationType.PalmMute,
                    Type = NoteType.Normal,
                    IsGrouped = true
                }
            },
            new()
            {
                FretNumber = 9,
                StringNumber = 5,
                StartPercentage = 0,
                EndPercentage = 25,
                Properties = new()
                {
                    Articulation = ArticulationType.PalmMute,
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
                Properties = new()
                {
                    Articulation = ArticulationType.PalmMute,
                    Type = NoteType.Normal,
                    IsGrouped = true
                }
            },
            new()
            {
                FretNumber = 9,
                StringNumber = 5,
                StartPercentage = 25,
                EndPercentage = 50,
                Properties = new()
                {
                    Articulation = ArticulationType.PalmMute,
                    Type = NoteType.Normal,
                    IsGrouped = true
                }
            },
            new()
            {
                FretNumber = 0,
                StringNumber = 6,
                StartPercentage = 50,
                EndPercentage = 100,
                Properties = new()
                {
                    Articulation = ArticulationType.PalmMute,
                    Type = NoteType.Normal,
                    IsGrouped = true
                }
            },
            new()
            {
                FretNumber = 9,
                StringNumber = 5,
                StartPercentage = 50,
                EndPercentage = 100,
                Properties = new()
                {
                    Articulation = ArticulationType.PalmMute,
                    Type = NoteType.Normal,
                    IsGrouped = true
                }
            }];

            List<NoteInformation> notes3 = [
                new()
            {
                FretNumber = 0,
                StringNumber = 6,
                StartPercentage = 0,
                EndPercentage = 25,
                Properties = new()
                {
                    Articulation = ArticulationType.PalmMute,
                    Type = NoteType.Normal,
                    IsGrouped = true
                }
            },
            new()
            {
                FretNumber = 10,
                StringNumber = 5,
                StartPercentage = 0,
                EndPercentage = 25,
                Properties = new()
                {
                    Articulation = ArticulationType.PalmMute,
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
                Properties = new()
                {
                    Articulation = ArticulationType.PalmMute,
                    Type = NoteType.Normal,
                    IsGrouped = true
                }
            },
            new()
            {
                FretNumber = 10,
                StringNumber = 5,
                StartPercentage = 25,
                EndPercentage = 50,
                Properties = new()
                {
                    Articulation = ArticulationType.PalmMute,
                    Type = NoteType.Normal,
                    IsGrouped = true
                }
            },
            new()
            {
                FretNumber = 0,
                StringNumber = 6,
                StartPercentage = 50,
                EndPercentage = 100,
                Properties = new()
                {
                    Articulation = ArticulationType.PalmMute,
                    Type = NoteType.Normal,
                    IsGrouped = true
                }
            },
            new()
            {
                FretNumber = 10,
                StringNumber = 5,
                StartPercentage = 50,
                EndPercentage = 100,
                Properties = new()
                {
                    Articulation = ArticulationType.PalmMute,
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
                    Bpm = 181,
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
                new()
                {
                    Bpm = 181,
                    TimeSignature = new(4,4),
                    NoteGroups = [
                        new(){
                            Notes = notes2,
                            BarStartPercentage = 0,
                            BarEndPercentage = 25
                        },
                        new(){
                            Notes = notes3,
                            BarStartPercentage = 25,
                            BarEndPercentage = 50
                        },
                        new(){
                            Notes = notes2,
                            BarStartPercentage = 50,
                            BarEndPercentage = 75
                        },
                        new(){
                            Notes = notes3,
                            BarStartPercentage = 75,
                            BarEndPercentage = 100
                        }
                        ],
                },

            };

            #endregion

            // Go Through each Bar and calculate positioning information
            exampleBars = BarPositioningHelper
                            .CalculateBarPositionsInTab(exampleBars);


            _currentTab = new TabInformation()
            {
                Bars = exampleBars,
                Author = "Gojira",
                Title = "Backbone Snippet",
                Description = "This is a sample tab for testing purposes. The limit of this desription must never exceed 400",
                TotalLengthInSeconds = 0
            };
        }

        /// <inheritdoc />
        public async Task<TabInformation?> GetTabAsync(Guid pieceId, CancellationToken cancellationToken)
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
                            Length = NoteHelper.GetNoteLength(note, group),
                            IsGrouped = note.Properties.IsGrouped,
                            Articulation = note.Properties.Articulation,
                            Type = note.Properties.Type,
                        };

                    }
                }

            }

            return _currentTab;
        }

        /// <inheritdoc />
        public bool IsTabLoaded()
            => _currentTab is not null;

        public void LoadTab(TabInformation information)
        {
            throw new NotImplementedException();
        }
    }
}
