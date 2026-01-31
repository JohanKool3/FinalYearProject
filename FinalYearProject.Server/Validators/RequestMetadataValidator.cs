using FinalYearProject.EfCore.Models;
using FinalYearProject.Server.Interfaces;
using FinalYearProject.Server.Models;
using FinalYearProject.Shared.Interfaces;

namespace FinalYearProject.Server.Validators
{
    public class RequestMetadataValidator(
        IRepository<Piece, Guid> pieceRepository
        )
        : IDataValidator<AnalysisRequestMetadata>
    {

        public IRepository<Piece, Guid> PieceRepository { get; } = pieceRepository;

        public async Task<bool> ValidDataAsync(AnalysisRequestMetadata data)
        {
            // For now the only check is if the piece Id
            // is present in the database.

            // Later this can be extended to include checks
            // such as the last timestamp of a request for
            // audio analysis (to prevent Dos attacks)
            // and other relevant checks.

            var piece = await PieceRepository.GetAsync(data.PieceId);

            if(piece is null)
            {
                return false;
            }

            return true;
        }
    }
}
