using FinalYearProject.Api;
using FinalYearProject.Shared.Models.Dtos;
using FinalYearProject.UI.Components.Interfaces;

namespace FinalYearProject.UI.Components.DataManagers
{
    public class TabBrowserDataManager(FinalYearProjectApiClient apiClient)
        : IDataManager<PieceInformationDto>
    {
        public FinalYearProjectApiClient ApiClient { get; } = apiClient;

        public async Task<IEnumerable<PieceInformationDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            // Get all the Piece Information from the API
            if(ApiClient is null)
            {
                return [];
            }

            return await ApiClient.GetAllPieceInformationAsync(cancellationToken);
        }
    }
}
