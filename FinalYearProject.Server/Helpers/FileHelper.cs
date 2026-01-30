namespace FinalYearProject.Server.Helpers
{
    public static class FileHelper
    {

        public static string CreateTemporaryFolder(string baseFolder)
        {
            // Create unique GUID for folder
            var tempFolder = Guid.NewGuid().ToString();

            // Create Directory by combining baseFolder and tempFolder
            var directory = Path.Combine(baseFolder, tempFolder);

            return directory;
        }
    }
}
