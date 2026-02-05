using FinalYearProject.UI.Components.Interfaces;
using Microsoft.Maui.Storage;

namespace FinalYearProject.UI.Components.Services
{
    /// <inheritdoc cref="IUserDataStorage" />
    public class UserDataStorage : IUserDataStorage
    {
        // TODO: Move this into configuration for ease of changes
        private readonly string _basePath =
            Path.Combine(FileSystem.AppDataDirectory, "FinalYearProject", "UserData", "Recordings");

        public string GetPieceDirectory(Guid pieceId)
        {
            var path = Path.Combine(_basePath, pieceId.ToString());
            Directory.CreateDirectory(path);
            return path;
        }

        public string CreateRecordingPath(Guid pieceId, DateTime timestamp)
        {
            var fileName = $"recording_{timestamp:yyyyMMdd_HHmmss}.wav";
            return Path.Combine(GetPieceDirectory(pieceId), fileName);
        }

        public List<string> GetFilesAtDirectoryByFileExtension(Guid pieceId, string extension)
        {
            var directory = GetPieceDirectory(pieceId);

            var output = Directory
                .GetFiles(directory, $"*{extension}")
                .OrderByDescending(File.GetCreationTimeUtc)
                .ToList();


            return output;
        }
    }
}

