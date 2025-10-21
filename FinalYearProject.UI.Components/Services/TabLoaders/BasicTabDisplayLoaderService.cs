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
                    Notes =
                    [
                        new()
                        {
                            BarPercentage = 0,
                            FretNumber = 0,
                            StringNumber = 6,
                        },
                        new()
                        {
                            BarPercentage = 0,
                            FretNumber = 2,
                            StringNumber = 5,
                        },
                        new()
                        {
                            BarPercentage = 50,
                            FretNumber = 1,
                            StringNumber = 6,
                        },
                        new()
                        {
                            BarPercentage = 50,
                            FretNumber = 3,
                            StringNumber = 5,
                        },
                    ],
                
                    Chords =
                    [
                        new()
                        {
                            BarPercentage = 0,
                            ChordName = "E5"
                        },
                        new()
                        {
                            BarPercentage = 50,
                            ChordName = "F5"
                        },
                    ]
                },
                new()
                {
                    Bpm = 90,
                    TimeSignature = new(6,8),
                    Notes =
                    [
                        new()
                        {
                            BarPercentage = 0,
                            FretNumber = 0,
                            StringNumber = 6,
                        },
                        new()
                        {
                            BarPercentage = 16,
                            FretNumber = 1,
                            StringNumber = 6,
                        },
                        new()
                        {
                            BarPercentage = 32,
                            FretNumber = 3,
                            StringNumber = 6,
                        },
                        new()
                        {
                            BarPercentage = 48,
                            FretNumber = 0,
                            StringNumber = 5,
                        },
                        new()
                        {
                            BarPercentage = 60,
                            FretNumber = 0,
                            StringNumber = 5,
                            NoteType = NoteType.Grace
                        },
                        new()
                        {
                            BarPercentage = 64,
                            FretNumber = 2,
                            StringNumber = 5,
                        },
                        new()
                        {
                            BarPercentage = 80,
                            FretNumber = 3,
                            StringNumber = 5,
                        },
                    ],

                    Chords = [
                        new()
                        {
                            BarPercentage = 0,
                            ChordName = "E5"
                        }
                        ]
                },
                new()
                {
                    Bpm = 150,
                    TimeSignature = new(4,4),
                    Notes =
                    [
                        new()
                        {
                            BarPercentage = 0,
                            FretNumber = 0,
                            StringNumber = 6,
                        },
                        new()
                        {
                            BarPercentage = 0,
                            FretNumber = 2,
                            StringNumber = 5,
                        },
                        new()
                        {
                            BarPercentage = 50,
                            FretNumber = 1,
                            StringNumber = 6,
                        },
                        new()
                        {
                            BarPercentage = 50,
                            FretNumber = 3,
                            StringNumber = 5,
                        },
                    ],
                    Chords =
                    [
                        new()
                        {
                            BarPercentage = 0,
                            ChordName = "E5"
                        },
                        new()
                        {
                            BarPercentage = 50,
                            ChordName = "F5"
                        },
                    ]
                },
                new()
                {
                    TimeSignature = new(4,4),
                    Notes =
                    [
                        new()
                        {
                            BarPercentage = 0,
                            FretNumber = 0,
                            StringNumber = 6,
                        },
                        new()
                        {
                            BarPercentage = 0,
                            FretNumber = 2,
                            StringNumber = 4,
                        },
                        new()
                        {
                            BarPercentage = 33,
                            FretNumber = 1,
                            StringNumber = 6,
                        },
                        new()
                        {
                            BarPercentage = 33,
                            FretNumber = 3,
                            StringNumber = 4,
                        },
                        new()
                        {
                            BarPercentage = 66,
                            FretNumber = 3,
                            StringNumber = 6,
                        },
                        new()
                        {
                            BarPercentage = 66,
                            FretNumber = 5,
                            StringNumber = 4,
                        },

                    ],
                    Chords =
                    [
                        new()
                        {
                            BarPercentage = 0,
                            ChordName = "E5"
                        },
                        new()
                        {
                            BarPercentage = 33,
                            ChordName = "F5"
                        },
                        new()
                        {
                            BarPercentage = 66,
                            ChordName = "G5"
                        },
                    ]
                },
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
