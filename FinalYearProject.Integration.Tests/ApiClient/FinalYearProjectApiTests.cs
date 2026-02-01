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
            var response = await _api.RequestAnalysisAsync(request);

            Assert.NotNull(response);
            Assert.Equal(1.0f, response.NoteAccuracy);
        }
    }
}
