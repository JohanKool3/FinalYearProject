namespace FinalYearProject.Server.Interfaces
{
    /// <summary>
    /// Defines a generic repository interface for data access operations.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T, TId> where T : class
    {
        /// <summary>
        /// Gets an entity by its identifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetAsync(TId id);

        /// <summary>
        /// Returns all entities
        /// </summary>
        /// <returns></returns>
        Task<ICollection<T>> GetAllAsync();

        /// <summary>
        /// Creates a new entity and adds it to the underlying data store
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Whether the operation was successful or not</returns>
        Task<bool> CreateAsync(T entity);

        /// <summary>
        /// Updates an entity at a given identifier
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> UpdateAsync(TId id, T entity);

        /// <summary>
        /// Deletes an entity at a given ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Whether the operation was successful or not</returns>
        Task<bool> DeleteAsync(TId id);
    }
}
