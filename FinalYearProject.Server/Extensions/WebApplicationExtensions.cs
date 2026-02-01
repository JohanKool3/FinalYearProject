using FinalYearProject.EfCore.Helpers;
using FinalYearProject.EfCore.Models;
using FinalYearProject.Shared.Models.Dtos;

namespace FinalYearProject.Server.Extensions
{
    public static class WebApplicationExtensions
    {
        public static async Task SeedRepositoriesAsync(this WebApplication app)
        {
            // Check if in Development
            if (!(app.Environment.IsDevelopment() || app.Environment.IsTest()))
            {
                return;
            }

            using var scope = app.Services.CreateScope();

            await DevelopmentRepositorySeeder
                .SeedDataAsync<Piece, Guid>(scope, GetPieceData());
        }

        /// <summary>
        /// Creates test data for the Piece Repository
        /// </summary>
        /// <returns></returns>
        private static List<Piece> GetPieceData()
        {
            List<Piece> output = [];

            // Add initial reference tab here
            var referenceTab = new ReferenceTabDto()
            {
                Bpm = 120,
                NoteGroups = [new() {
                    StartTime = 0.0,
                    EndTime = 0.5,
                    Notes = [new(){
                        Name = "C5"
                    }]
                },
                new() {
                    StartTime = 0.5,
                    EndTime = 1,
                    Notes = [new(){
                        Name = "D5"
                    }]
                },
                new() {
                    StartTime = 1,
                    EndTime = 1.5,
                    Notes = [new(){
                        Name = "E5"
                    }]
                },
                new() {
                    StartTime = 1.5,
                    EndTime = 2,
                    Notes = [new(){
                        Name = "F5"
                    }]
                },
                new() {
                    StartTime = 2,
                    EndTime = 2.5,
                    Notes = [new(){
                        Name = "G5"
                    }]
                },
                new() {
                    StartTime = 2.5,
                    EndTime = 3,
                    Notes = [new(){
                        Name = "A5"
                    }]
                },
                new() {
                    StartTime = 3,
                    EndTime = 3.5,
                    Notes = [new(){
                        Name = "B5"
                    }]
                },
                new() {
                    StartTime = 3.5,
                    EndTime = 4,
                    Notes = [new(){
                        Name = "C6"
                    }]
                },
                ]
            };

            var newPiece = new Piece()
            {
                Id = Guid.Empty,
                PieceName = "C Major Scale",
                ReferenceTab = referenceTab
            };

            output.Add(newPiece);

            return output;
        }
    }
}
