using FinalYearProject.EfCore.Models;
using FinalYearProject.Shared.Interfaces;

namespace FinalYearProject.Server.Repositories
{
    /// <summary>
    /// Simple Repository to simulate data storage for Pieces in-memory
    /// </summary>
    public class InMemoryPieceRepository : IRepository<PieceModel, Guid>
    {
        /// <summary>
        /// The Contents of this in-memory repository
        /// </summary>
        public List<PieceModel> Contents { get; set; } = [];

        public async Task<bool> CreateAsync(PieceModel entity)
        {
            Contents.Add(entity);

            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var exists = Contents.Any(p => p.Id == id);

            if (exists)
            {
                return false;
            }
            else
            {
                Contents.Remove(Contents.First(p => p.Id == id));
                return true;
            }
        }

        public async Task<ICollection<PieceModel>> GetAllAsync()
        {
            return Contents;
        }

        public async Task<PieceModel?> GetAsync(Guid id)
        {
            var exists = Contents.Any(p => p.Id == id);

            if (exists)
            {
                return Contents.First(
                    item => item.Id == id);
            }

            return null;

        }

        public async Task<PieceModel?> UpdateAsync(Guid id, PieceModel entity)
        {
            var exists = Contents.Any(p => p.Id == id);

            if (exists)
            {
                // Update
                var index = Contents.FindIndex(p => p.Id == id);
                Contents[index] = entity;

                return entity;
            }

            return null;
        }
    }
}
