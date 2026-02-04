using FinalYearProject.EfCore.Models;

namespace FinalYearProject.Server.Seeding
{
    public static class PieceDataHelper
    {
        /// <summary>
        /// Creates test data for the Piece Repository
        /// </summary>
        /// <returns></returns>
        public static List<PieceModel> GetData()
        {
            List<PieceModel> output = [];

            var newPiece = new PieceModel()
            {
                Id = Guid.Empty,
                TabInformationModel = new()
                {
                    Title = "C Major Scale",
                    Author = "Unknown",
                    Description = "A Short scale",
                    TotalLengthInSeconds = 4,
                    Bars = [
                        new(){
                            Bpm = 120,
                            TimeSignature = new(){
                                BeatsPerMeasure = 4,
                                BeatUnit = 4,

                            },
                            Position = new(){
                                StartTime = 0,
                                EndTime = 2,
                                Length = 2,
                            },
                            NoteGroups = [
                                new(){
                                    BarStartPercentage = 0,
                                    BarEndPercentage = 25,
                                    TotalGroupBeatLength = 1,
                                    Notes = [
                                        new(){
                                            FretNumber = 17,
                                            StringNumber = 3,
                                            StartPercentage = 0,
                                            EndPercentage = 100,
                                            Properties = new(){
                                                Length = 1
                                            }
                                        }
                                        ],
                                    Chords = []
                                },
                                new(){
                                    BarStartPercentage = 25,
                                    BarEndPercentage = 50,
                                    TotalGroupBeatLength = 1,
                                     Notes = [
                                        new(){
                                            FretNumber = 19,
                                            StringNumber = 3,
                                            StartPercentage = 0,
                                            EndPercentage = 100,
                                            Properties = new(){
                                                Length = 1
                                            }
                                        }
                                        ],
                                    Chords = []
                                },
                                new(){
                                    BarStartPercentage = 50,
                                    BarEndPercentage = 75,
                                    TotalGroupBeatLength = 1,
                                     Notes = [
                                        new(){
                                            FretNumber = 21,
                                            StringNumber = 3,
                                            StartPercentage = 0,
                                            EndPercentage = 100,
                                            Properties = new(){
                                                Length = 1
                                            }
                                        }
                                        ],
                                    Chords = []
                                },
                                new(){
                                    BarStartPercentage = 75,
                                    BarEndPercentage = 100,
                                    TotalGroupBeatLength = 1,
                                     Notes = [
                                        new(){
                                            FretNumber = 18,
                                            StringNumber = 2,
                                            StartPercentage = 0,
                                            EndPercentage = 100,
                                            Properties = new(){
                                                Length = 1
                                            }
                                        }
                                        ],
                                    Chords = []
                                }
                            ]
                        },
                        new(){
                            Bpm = 120,
                            TimeSignature = new(){
                                BeatsPerMeasure = 4,
                                BeatUnit = 4
                            },
                            Position = new(){
                                StartTime = 2,
                                EndTime = 4,
                                Length = 2,
                            },
                            NoteGroups = [
                                new(){
                                    BarStartPercentage = 0,
                                    BarEndPercentage = 25,
                                    TotalGroupBeatLength = 1,
                                     Notes = [
                                        new(){
                                            FretNumber = 20,
                                            StringNumber = 2,
                                            StartPercentage = 0,
                                            EndPercentage = 100,
                                            Properties = new(){
                                                Length = 1
                                            }
                                        }
                                        ],
                                    Chords = []
                                },
                                new(){
                                    BarStartPercentage = 25,
                                    BarEndPercentage = 50,
                                    TotalGroupBeatLength = 1,
                                     Notes = [
                                        new(){
                                            FretNumber = 22,
                                            StringNumber = 2,
                                            StartPercentage = 0,
                                            EndPercentage = 100,
                                            Properties = new(){
                                                Length = 1
                                            }
                                        }
                                        ],
                                    Chords = []
                                },
                                new(){
                                    BarStartPercentage = 50,
                                    BarEndPercentage = 75,
                                    TotalGroupBeatLength = 1,
                                     Notes = [
                                        new(){
                                            FretNumber = 19,
                                            StringNumber = 1,
                                            StartPercentage = 0,
                                            EndPercentage = 100,
                                            Properties = new(){
                                                Length = 1
                                            }
                                        }
                                        ],
                                    Chords = []
                                },
                                new(){
                                    BarStartPercentage = 75,
                                    BarEndPercentage = 100,
                                    TotalGroupBeatLength = 1,
                                    Notes = [
                                        new(){
                                            StartPercentage = 0,
                                            EndPercentage = 1,
                                            StringNumber = 1,
                                            FretNumber = 20,
                                            Properties = new(){
                                                Length = 1
                                            }
                                        }],
                                    Chords = []
                                },

                            ]
                        }
                    ]
                },
                
                
            };

            output.Add(newPiece);

            return output;
        }
    }
}
