namespace FinalYearProject.UI.Components.Interfaces
{
    /// <summary>
    /// Defines a Service that can interact with the native
    /// device's File System
    /// </summary>
    public interface IUserDataStorage
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
    }
}
