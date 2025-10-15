using FinalYearProject.Shared.Models.TabRepresentation;
using FinalYearProject.UI.Components.Services;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.Pages
{
    public partial class TabView(TabPlaybackService playbackService) : ComponentBase
    {
        public TabPlaybackService PlaybackService { get; set; } = playbackService;

        protected override void OnInitialized()
        {
            // Load example tab into the playback service
            FullPiece fullPiece = new()
            {
                Bars = [
                    new MusicalBar(){
                        Notes = [
                            new MusicalNote(6, 0, 0, 0.5),
                            new MusicalNote(6, 0, 0.5, 0.5),
                            new MusicalNote(6, 0, 1, 0.5),
                            new MusicalNote(6, 0, 1.5, 0.5),
                            new MusicalNote(6, 0, 2, 0.5),
                            new MusicalNote(6, 0, 2.5, 0.5),
                            new MusicalNote(6, 0, 3, 0.5),
                            new MusicalNote(6, 0, 3.5, 0.5),
                        ],
                        BarNumber = 1,
                        TimeSignature = new TimeSignature(4,4)
                    },
                //    new MusicalBar(){
                //            Notes = [
                //                new MusicalNote(6, 1, 0, 0.5),
                //                new MusicalNote(6, 1, 0.5, 0.5),
                //                new MusicalNote(6, 1, 1, 0.5),
                //                new MusicalNote(6, 1, 1.5, 0.5),
                //                new MusicalNote(6, 1, 2, 0.5),
                //                new MusicalNote(6, 1, 2.5, 0.5),
                //                new MusicalNote(6, 1, 3, 0.5),
                //                new MusicalNote(6, 1, 3.5, 0.5),
                //            ],
                //            BarNumber = 2,
                //            TimeSignature = new TimeSignature(4,4)
                //        },
                //new MusicalBar(){
                //        Notes = [
                //            new MusicalNote(6, 3, 0, 1),
                //            new MusicalNote(6, 3, 1, 1),
                //            new MusicalNote(6, 3, 2, 1),
                //            new MusicalNote(6, 3, 3, 1),
                //            new MusicalNote(6, 3, 4, 1),
                //            new MusicalNote(6, 3, 5, 1),
                //        ],
                //        BarNumber = 3,
                //        TimeSignature = new TimeSignature(6,8)
                //        },
                //new MusicalBar(){
                //    Notes = [
                //        new MusicalNote(4, 2, 0, 1),
                //        new MusicalNote(4, 2, 1, 1),
                //        new MusicalNote(4, 2, 2, 1),
                //        new MusicalNote(4, 2, 3, 1),
                //        new MusicalNote(4, 2, 4, 1),
                //        new MusicalNote(4, 2, 5, 1),
                //        new MusicalNote(4, 2, 6, 1),
                //        new MusicalNote(4, 2, 7, 1),
                //        new MusicalNote(4, 2, 8, 1),
                //        new MusicalNote(4, 2, 9, 1),
                //        new MusicalNote(4, 2, 10, 1),
                //        new MusicalNote(4, 2, 11, 1),
                //        new MusicalNote(4, 2, 12, 1),
                //    ],
                //    BarNumber = 4,
                //    TimeSignature = new TimeSignature(16,13)
                //},
                //new MusicalBar(){
                //    Notes = [
                //        new MusicalNote(6, 0, 0, 1),
                //        new MusicalNote(5, 1, 1, 1),
                //        new MusicalNote(4, 2, 2, 1),
                //        new MusicalNote(3, 3, 3, 1),
                //        new MusicalNote(2, 4, 4, 1),
                //    ],
                //    BarNumber = 5,
                //    TimeSignature = new TimeSignature(5,4)
                //},

                ]
            };

            PlaybackService.LoadPiece(fullPiece);
        }
    }
}