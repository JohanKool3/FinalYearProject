using AutoMapper;
using FinalYearProject.Api;
using FinalYearProject.Services.Interfaces;
using FinalYearProject.Shared.Models.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalYearProject.Services.UI.TabLoaders
{
    public class TabLoaderService(
        FinalYearProjectApiClient apiClient,
        IMapper mapper) : ITabLoaderService
    {
        private readonly TabInformation _currentTab = null!;

        public FinalYearProjectApiClient ApiClient { get; } = apiClient;
        public IMapper Mapper { get; } = mapper;

        public async Task<TabInformation?> GetTabAsync(Guid pieceId, CancellationToken cancellationToken)
        {
            // Pull From API
            var response = await ApiClient.GetPieceByIdAsync(pieceId, cancellationToken);

            if(response is null)
            {
                return null;
            }

            var tabInformation = Mapper.Map<TabInformation>(response.TabInformation);

            return tabInformation;
        }

        public bool IsTabLoaded()
        {
            throw new NotImplementedException();
        }

        public void LoadTab(TabInformation information)
        {
            throw new NotImplementedException();
        }
    }
}
