using FinalYearProject.Shared.Models.Dtos;
using FinalYearProject.UI.Components.Interfaces;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements.TabBrowser
{
    public partial class TabBrowser(IDataManager<PieceInformationDto> dataManager)
    {
        /// <summary>
        /// Height of the entire tab browser
        /// </summary>
        [Parameter]
        public int Height { get; set; } = 500;

        /// <summary>
        /// Width of the Tab Browser
        /// </summary>
        [Parameter]
        public int Width { get; set; } = 300;

        /// <summary>
        /// Navigate Action
        /// </summary>
        [Parameter, EditorRequired]
        public required Action<Guid> NavigateToPiece { get; set; }

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
