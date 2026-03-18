using FinalYearProject.EfCore.Models;
using FinalYearProject.Shared.Enums;
using FinalYearProject.Shared.Models.TabRepresentation;

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

            var standardTimeSignature = new TimeSignatureModel()
            {
                BeatsPerMeasure = 4,
                BeatUnit = 4
            };

            // C Major Scale
            var newPiece_1 = new PieceModel()
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

            var newPiece_2 = new PieceModel()
            {
                Id = Guid.NewGuid(),
                TabInformationModel = new()
                {
                    Title = "Master of Puppets",
                    Author = "Metallica",
                    Description = "All down strokes",
                    TotalLengthInSeconds = 4.5283f,
                    Bars = [
                        // First Bar
                        new(){
                            Bpm = 212,
                            TimeSignature = standardTimeSignature,
                            Position = new(){
                                StartTime = 0,
                                EndTime = 1.132f,
                                Length = 2.264f
                            },
                            NoteGroups = [
                                new(){
                                    Chords = [],
                                    BarStartPercentage = 0,
                                    BarEndPercentage = 50,
                                    TotalGroupBeatLength = 2,
                                    Notes = [
                                        new(){
                                            StartPercentage = 0,
                                            EndPercentage = 25,
                                            FretNumber = 0,
                                            StringNumber = 6,
                                            Properties = new(){
                                                Articulation = ArticulationType.PalmMute,
                                                Length = 0.5f,
                                                Type = NoteType.Normal,
                                                IsGrouped = true
                                            }
                                        },
                                        new(){
                                            StartPercentage = 25,
                                            EndPercentage = 50,
                                            FretNumber = 0,
                                            StringNumber = 6,
                                            Properties = new(){
                                                Articulation = ArticulationType.PalmMute,
                                                Length = 0.5f,
                                                Type = NoteType.Normal,
                                                IsGrouped = true
                                            }
                                        },
                                        new(){
                                            StartPercentage = 50,
                                            EndPercentage = 75,
                                            FretNumber = 12,
                                            StringNumber = 6,
                                            Properties = new(){
                                                Articulation = ArticulationType.None,
                                                Length = 0.5f,
                                                Type = NoteType.Normal,
                                                IsGrouped = true
                                            }
                                        },
                                        new(){
                                            StartPercentage = 75,
                                            EndPercentage = 100,
                                            FretNumber = 0,
                                            StringNumber = 6,
                                            Properties = new(){
                                                Articulation = ArticulationType.PalmMute,
                                                Length = 0.5f,
                                                Type = NoteType.Normal,
                                                IsGrouped = true
                                            }
                                        }
                                        ]

                                },
                                new(){
                                    Chords = [],
                                    BarStartPercentage = 50,
                                    BarEndPercentage = 100,
                                    TotalGroupBeatLength = 2,
                                    Notes = [
                                        new(){
                                            StartPercentage = 0,
                                            EndPercentage = 25,
                                            FretNumber = 0,
                                            StringNumber = 6,
                                            Properties = new(){
                                                Articulation = ArticulationType.PalmMute,
                                                Length = 0.5f,
                                                Type = NoteType.Normal,
                                                IsGrouped = true
                                            }
                                        },
                                        new(){
                                            StartPercentage = 25,
                                            EndPercentage = 50,
                                            FretNumber = 11,
                                            StringNumber = 6,
                                            Properties = new(){
                                                Articulation = ArticulationType.None,
                                                Length = 0.5f,
                                                Type = NoteType.Normal,
                                                IsGrouped = true
                                            }
                                        },
                                        new(){
                                            StartPercentage = 50,
                                            EndPercentage = 75,
                                            FretNumber = 0,
                                            StringNumber = 6,
                                            Properties = new(){
                                                Articulation = ArticulationType.PalmMute,
                                                Length = 0.5f,
                                                Type = NoteType.Normal,
                                                IsGrouped = true
                                            }
                                        },
                                        new(){
                                            StartPercentage = 75,
                                            EndPercentage = 100,
                                            FretNumber = 0,
                                            StringNumber = 6,
                                            Properties = new(){
                                                Articulation = ArticulationType.PalmMute,
                                                Length = 0.5f,
                                                Type = NoteType.Normal,
                                                IsGrouped = true
                                            }
                                        }
                                        ]

                                },]

                        },
                        // Second Bar
                        new(){
                            Bpm = 212,
                            TimeSignature = standardTimeSignature,
                            Position = new(){
                                StartTime = 1.132f,
                                EndTime = 2.264f,
                                Length = 1.132f
                            },
                            NoteGroups = [
                                new(){
                                    Chords = [],
                                    BarStartPercentage = 0,
                                    BarEndPercentage = 25,
                                    TotalGroupBeatLength = 1,
                                    Notes = [
                                        new(){
                                            StartPercentage = 0,
                                            EndPercentage = 100,
                                            StringNumber = 6,
                                            FretNumber = 10,
                                            Properties = new(){
                                                Articulation = ArticulationType.None,
                                                IsGrouped = false,
                                                Length = 1,
                                                Type = NoteType.Normal
                                            }
                                        },
                                        new(){
                                            StartPercentage = 0,
                                            EndPercentage = 100,
                                            StringNumber = 5,
                                            FretNumber = 12,
                                            Properties = new(){
                                                Articulation = ArticulationType.None,
                                                IsGrouped = false,
                                                Length = 1,
                                                Type = NoteType.Normal
                                            }
                                        }
                                        ]
                                },
                                new(){
                                    Chords = [],
                                    BarStartPercentage = 25,
                                    BarEndPercentage = 50,
                                    TotalGroupBeatLength = 1,
                                    Notes = [
                                        new(){
                                            StartPercentage = 0,
                                            EndPercentage = 100,
                                            StringNumber = 6,
                                            FretNumber = 9,
                                            Properties = new(){
                                                Articulation = ArticulationType.None,
                                                IsGrouped = false,
                                                Length = 1,
                                                Type = NoteType.Normal
                                            }
                                        },
                                        new(){
                                            StartPercentage = 0,
                                            EndPercentage = 100,
                                            StringNumber = 5,
                                            FretNumber = 11,
                                            Properties = new(){
                                                Articulation = ArticulationType.None,
                                                IsGrouped = false,
                                                Length = 1,
                                                Type = NoteType.Normal
                                            }
                                        }
                                        ]
                                },
                            new(){
                                    Chords = [],
                                    BarStartPercentage = 50,
                                    BarEndPercentage = 100,
                                    TotalGroupBeatLength = 2,
                                    Notes = [
                                        new(){
                                            StartPercentage = 0,
                                            EndPercentage = 100,
                                            StringNumber = 6,
                                            FretNumber = 8,
                                            Properties = new(){
                                                Articulation = ArticulationType.None,
                                                IsGrouped = false,
                                                Length = 1,
                                                Type = NoteType.Normal
                                            }
                                        },
                                        new(){
                                            StartPercentage = 0,
                                            EndPercentage = 100,
                                            StringNumber = 5,
                                            FretNumber = 10,
                                            Properties = new(){
                                                Articulation = ArticulationType.None,
                                                IsGrouped = false,
                                                Length = 1,
                                                Type = NoteType.Normal
                                            }
                                        }
                                        ]
                                },]
                    }]
                },
            };

            output.Add(newPiece_1);
            output.Add(newPiece_2);

            return output;
        }
    }
}
