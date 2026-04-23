using FinalYearProject.Shared.Models.Dtos;
using FinalYearProject.Shared.Services;
using FinalYearProject.UI.Components.Interfaces;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements.ToolbarWidgets
{
    public partial class UploadForAnalysisButton(NavigationManager navigationManager,
        IUserDataService dataService)
    {
        private readonly NavigationManager _navigationManager = navigationManager;
        private readonly IUserDataService _dataService = dataService;

        /// <summary>
        /// Notify the parent component that a change has occurred.
        /// </summary>
        [Parameter, EditorRequired]
        public Func<Task> NotifyParentOfChange { get; set; } = null!;

        private Task UploadAsync()
        {
            // Navigate to the Results Page

            return NotifyParentOfChange();
        }

        internal string GetLatestRecording()
        {
            var files = _dataService.GetFilesAtDirectoryByFileExtension(Guid.Empty, ".wav");

            return files.FirstOrDefault()
                ?? string.Empty;
        }
    }
}