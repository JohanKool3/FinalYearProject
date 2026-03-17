using FinalYearProject.Api;
using FinalYearProject.Api.Models;
using FinalYearProject.Integration.Tests.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace FinalYearProject.Integration.Tests.ApiClient
{
    public class FinalYearProjectApiTests : IClassFixture<TestApiFactory>
    {
        private readonly FinalYearProjectApiClient _api;

        public FinalYearProjectApiTests(TestApiFactory factory)
        {
            var provider = TestSetupHelper.Create(factory);
            _api = provider.GetRequiredService<FinalYearProjectApiClient>();
        }

        [Fact]
        public async Task FinalYearProjectApi_RequestAnalysisAsync_ValidData_ReturnsExpectedResult()
        {
            // Arrange
            var request = new RequestAnalysisData
            {
                // C Major Scale has an empty GUID as its ID
                PieceId = Guid.Empty,
                FileName = "test.wav",
                AudioData = File.OpenRead("TestData/c-major-sine.wav")
            };

            // Act
            var response = await _api.RequestAnalysisAsync(request, CancellationToken.None);

            Assert.NotNull(response);
            Assert.Equal(1.0f, response.NoteAccuracy);
        }

        [Fact]
        public async Task FinalYearProjectApi_GetAllPieceInformationAsync_ReturnsExpectedPieces()
        {
            // Act
            var pieces = await _api.GetAllPieceInformationAsync(CancellationToken.None);
            
            // Assert
            Assert.NotNull(pieces);
            var pieceList = pieces.ToList();
            Assert.Contains(pieces.ToList(), p => p.PieceName == "C Major Scale");
        }

        [Fact]
        public async Task FinalYearProjectApi_GetPieceByIdAsync_ValidId_ReturnsExpectedPiece()
        {
            // Arrange
            var pieceId = Guid.Empty;
            
            // Act
            var piece = await _api.GetPieceInformationByIdAsync(pieceId, CancellationToken.None);
            
            // Assert
            Assert.NotNull(piece);
            Assert.Equal("C Major Scale", piece.PieceName);
        }

        [Fact]
        public async Task FinalYearProjectApi_GetPieceByIdAsync_ValidId_ReturnsExpected()
        {
            // Arrange
            var pieceId = Guid.Empty;
            
            // Act
            var piece = await _api.GetPieceByIdAsync(pieceId, CancellationToken.None);
            
            // Assert
            Assert.NotNull(piece);
            Assert.Equal("C Major Scale", piece!.TabInformation.Title);
        }
    }
}
