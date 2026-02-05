using FinalYearProject.UI.Components.Interfaces;

namespace FinalYearProject.UI.Components.InterfaceElements.Recording
{
    public partial class AudioFileManager(IUserDataStorage storage)
    {
        /// <summary>
        /// The Current Recording Session's Piece Id
        /// </summary>
        public required Guid? PieceId { get; set; }

        public IUserDataStorage Storage { get; } = storage;

        internal void SetId(Guid guid)
        {
            PieceId = guid;

            // Create the Folder Location 
            var location = Storage.GetPieceDirectory(guid);

            Console.WriteLine();
        }
    }
}