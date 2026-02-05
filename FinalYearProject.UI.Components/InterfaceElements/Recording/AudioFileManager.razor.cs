using FinalYearProject.UI.Components.Interfaces;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements.Recording
{
    public partial class AudioFileManager(IUserDataStorage storage)
    {
        /// <summary>
        /// The Current Recording Session's Piece Id
        /// </summary>
        [Parameter, EditorRequired]
        public required Guid PieceId { get; set; }

        public IUserDataStorage Storage { get; } = storage;

        public Task SetIdAsync(Guid guid)
        {
            PieceId = guid;

            // Create the Folder Location 
            var location = Storage.GetPieceDirectory(guid);

            Console.WriteLine();

            return InvokeAsync(StateHasChanged);
        }

        internal string GetLatestRecording()
        {
            var files = Storage.GetFilesAtDirectoryByFileExtension(PieceId, ".wav");

            return files.FirstOrDefault()
                ?? string.Empty;
        }
    }
}