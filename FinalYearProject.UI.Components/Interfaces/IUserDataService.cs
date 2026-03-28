namespace FinalYearProject.UI.Components.Interfaces
{
    /// <summary>
    /// Defines a Service that can interact with the native
    /// device's File System
    /// </summary>
    public interface IUserDataService
    {
        /// <summary>
        /// Gets a Piece Directory by ID
        /// </summary>
        /// <param name="pieceId"></param>
        /// <returns></returns>
        string GetPieceDirectory(Guid pieceId);


        /// <summary>
        /// Creates a Path for a recording by ID
        /// </summary>
        /// <param name="pieceId"></param>
        /// <param name="timestamp"></param>
        /// <returns></returns>
        string CreateRecordingPath(Guid pieceId, DateTime timestamp);

        /// <summary>
        /// Returns a List of paths for files that are a part of a given piece Directory.
        /// </summary>
        /// <param name="pieceId"></param>
        /// <param name="extension"></param>
        /// <returns></returns>
        /// <remarks>The returned list will be sorted by creation date, with the
        /// latest created first.</remarks>
        List<string> GetFilesAtDirectoryByFileExtension(Guid pieceId, string extension);
    }
}
