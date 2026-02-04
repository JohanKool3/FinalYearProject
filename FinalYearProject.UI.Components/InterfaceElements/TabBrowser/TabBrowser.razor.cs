using FinalYearProject.Shared.Models.Dtos;
using FinalYearProject.UI.Components.Interfaces;

namespace FinalYearProject.UI.Components.InterfaceElements.TabBrowser
{
    public partial class TabBrowser(IDataManager<PieceInformationDto> dataManager)
    {
        /// <summary>
        /// Determines whether data from the server has been loaded
        /// </summary>
        private bool DataLoaded;

        /// <summary>
        /// Holds the Piece Information that has been pulled from the server
        /// </summary>
        
        // TODO: Implement IMemoryCache for this
        private List<PieceInformationDto> localData { get; set; } = [];

        /// <summary>
        /// The Query that the user will search
        /// </summary>
        private string UserSearch = string.Empty;

        public IDataManager<PieceInformationDto> DataManager { get; } = dataManager;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                // Load Initial Data
                var response = await DataManager.GetAllAsync(CancellationToken.None);
                localData = [.. response];
                DataLoaded = true;
                await InvokeAsync(StateHasChanged);
            }

            await base.OnAfterRenderAsync(firstRender);
        }
    }
}
