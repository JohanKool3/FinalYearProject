namespace FinalYearProject.Server.Interfaces
{
    /// <summary>
    /// Outlines a component that will validate some information
    /// </summary>
    /// <typeparam name="T">The type that will be validated</typeparam>
    public interface IDataValidator<T> where T: class
    {
        /// <summary>
        /// Check the data and return whether it is valid or not.
        /// </summary>
        /// <param name="audioData"></param>
        /// <returns></returns>
        Task<bool> ValidDataAsync(T data);
    }
}
