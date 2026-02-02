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
                .SeedDataAsync<PieceModel, Guid>(scope, GetPieceData());
        }

        /// <summary>
        /// Creates test data for the Piece Repository
        /// </summary>
        /// <returns></returns>
        private static List<PieceModel> GetPieceData()
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
                                BeatUnit = 4
                            }
                        },
                        new(){
                            Bpm = 120,
                            TimeSignature = new(){
                                BeatsPerMeasure = 4,
                                BeatUnit = 4
                            }
                        }
                    ]
                }
            };

            output.Add(newPiece);

            return output;
        }
    }
}
